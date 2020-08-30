Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports System.IO.File
Imports System.IO.Path
Imports System.Globalization
Imports System.Xml.Schema
Imports Microsoft.VisualBasic.Compatibility
Imports System.ComponentModel

Public Class frmTimeChg
#Disable Warning CA1031, CA1305 ' 一般的な例外の種類はキャッチしません
    Private Const DATEFMT As String = "yyyy/MM/dd hh:mm:ss"
    Private Const DATEFMTJ As String = "gyy年"
    Private oldstate As CheckState
    Private toolTip1 As ToolTip = New ToolTip()
    ' カルチャの「言語-国/地域」を「日本語-日本」に設定
    Dim ci As New CultureInfo("ja-JP")
    ' 和暦を表すクラス
    Dim jp As New JapaneseCalendar
    Private Sub frmTimeChg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 現在のカルチャで使用する暦を、和暦に設定
        ci.DateTimeFormat.Calendar = jp
        Me.AllowDrop = True
        oldstate = CheckBox3.CheckState
        DataGridView1.AllowDrop = True
        Dim args() As String = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            Dim filenames(args.Length - 2) As String
            'Array.Copy(args, 1, filenames, 0, filenames.Length - 1) 配列の部分コピーできねー
            For i = 1 To args.Length - 1
                filenames(i - 1) = args(i)
            Next
            addList(filenames)
        End If
        toolTip1.AutoPopDelay = 3000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        toolTip1.ShowAlways = True
    End Sub

    Private Sub frmTimeChg_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        'ドロップされたすべてのファイル名を取得する
        Dim strMsg As String = ""
        Dim fileNames As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        addList(fileNames)
    End Sub

    Private Sub obj_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter, DataGridView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            'string型でなければ受け入れない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop
        'ドロップされたすべてのファイル名を取得する
        Dim fileNames As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        addList(fileNames)
    End Sub

    Private Function addList(ByVal filenames() As String) As Boolean
        Dim strMsg As String = ""
        Dim intCnt As Integer = 0
        If filenames.Length >= 1 Then
            For i As Integer = 0 To filenames.Length - 1
                Dim filename As String = filenames(i)
                If System.IO.File.Exists(filename) Then
                    If Not CheckExist(filename) Then
                        Dim strCreateDate As String = GetCreationTime(filename).ToString(DATEFMT)
                        Dim strModefyDate As String = GetLastWriteTime(filename).ToString(DATEFMT)
                        Dim s() As String = {True, GetDirectoryName(filename), GetFileName(filename),
                        strCreateDate, strModefyDate,
                        strCreateDate, strModefyDate} '復元用
                        DataGridView1.Rows.Add(s)
                    Else
                        intCnt += 1
                        If intCnt < 10 Then
                            strMsg &= (vbCrLf & filename)
                        ElseIf intCnt = 10 Then
                            strMsg &= (vbCrLf & "他")
                        End If
                    End If
                End If
            Next
        End If
        CheckMark()
        If strMsg.Length > 0 Then
            MsgBox("以下のファイルは重複しています。" & strMsg, MsgBoxStyle.Exclamation, Me.Text)
        End If
        Return True
    End Function

    Private Function CheckExist(ByVal fileName As String) As Boolean
        Dim strPath As String = System.IO.Path.GetDirectoryName(fileName)
        Dim strFile As String = System.IO.Path.GetFileName(fileName)
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Item(1, i).Value = strPath AndAlso DataGridView1.Item(2, i).Value = strFile Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        With DataGridView1
            If Not IsNothing(.CurrentRow) AndAlso .CurrentRow.Index >= 0 Then
                LabelCDate.Text = .Item(5, .CurrentRow.Index).Value.ToString
                LabelMDate.Text = .Item(6, .CurrentRow.Index).Value.ToString
                TextBoxCDate.Text = .Item(3, .CurrentRow.Index).Value.ToString
                TextBoxMDate.Text = .Item(4, .CurrentRow.Index).Value.ToString
            End If
        End With
    End Sub

    Private Sub ButtonExec_Click(sender As Object, e As EventArgs) Handles ButtonExec.Click
        If CheckBox1.Checked Or CheckBox2.Checked Then
            If IsDate(TextBoxCDate.Text) And IsDate(TextBoxMDate.Text) Then
                Dim newdate = CDate(TextBoxCDate.Text)
                Dim moddate = CDate(TextBoxMDate.Text)
                Dim flg As Boolean = False
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Item(0, i).Value = True Then
                        Dim filename As String = DataGridView1.Item(1, i).Value & "\" & DataGridView1.Item(2, i).Value
                        If CheckBox1.Checked Then
                            Try
                                System.IO.File.SetCreationTime(filename, newdate)
                                DataGridView1.Item(3, i).Value = newdate.ToString(DATEFMT)
                            Catch ex As Exception
                                MsgBox("変更に失敗しました。" & vbCrLf & filename, MsgBoxStyle.Critical, Me.Text)
                                Exit Sub
                            End Try
                            flg = True
                        End If
                        If CheckBox2.Checked Then
                            Try
                                System.IO.File.SetLastWriteTime(filename, moddate)
                                DataGridView1.Item(4, i).Value = moddate.ToString(DATEFMT)
                            Catch ex As Exception
                                MsgBox("変更に失敗しました。" & vbCrLf & filename, MsgBoxStyle.Critical, Me.Text)
                                Exit Sub
                            End Try
                            flg = True
                        End If
                    End If
                Next
                If flg Then
                    MsgBox("設定しました", MsgBoxStyle.Information, Me.Text)
                    BtnRedo.Enabled = True
                Else
                    MsgBox("ファイルが未チェックです", MsgBoxStyle.Exclamation, Me.Text)
                End If
            Else
                MsgBox("設定日が正しくないようです", MsgBoxStyle.Exclamation, Me.Text)
            End If
        Else
            MsgBox("変更日が未チェックです", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBoxCDate.Enabled = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        TextBoxMDate.Enabled = CheckBox2.Checked
    End Sub

    Private Sub BtnRedo_Click(sender As Object, e As EventArgs) Handles BtnRedo.Click
        If CheckBox1.Checked Or CheckBox2.Checked Then
            Dim newdate As Date
            Dim moddate As Date
            Dim flg As Boolean = False
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Item(0, i).Value = True Then
                    Dim filename As String = DataGridView1.Item(1, i).Value & "\" & DataGridView1.Item(2, i).Value
                    If CheckBox1.Checked Then
                        newdate = CDate(DataGridView1.Item(5, i).Value)
                        System.IO.File.SetCreationTime(filename, newdate)
                        DataGridView1.Item(3, i).Value = DataGridView1.Item(5, i).Value
                        flg = True
                    End If
                    If CheckBox2.Checked Then
                        moddate = CDate(DataGridView1.Item(6, i).Value)
                        System.IO.File.SetLastWriteTime(filename, moddate)
                        DataGridView1.Item(4, i).Value = DataGridView1.Item(6, i).Value
                        flg = True
                    End If
                End If
            Next
            If flg Then
                flg = False
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Item(3, i).Value <> DataGridView1.Item(5, i).Value Or DataGridView1.Item(3, i).Value <> DataGridView1.Item(5, i).Value Then
                        flg = True
                    End If
                Next
                BtnRedo.Enabled = flg
                MsgBox("復元しました", MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("ファイルが未チェックです", MsgBoxStyle.Exclamation, Me.Text)
            End If
        Else
            MsgBox("内部エラーです", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        If CheckBox3.CheckState = CheckState.Checked Then
            CheckBox3.CheckState = CheckState.Unchecked
        ElseIf CheckBox3.CheckState = CheckState.Unchecked Then
            CheckBox3.CheckState = CheckState.Checked
        End If
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Item(0, i).Value = CheckBox3.Checked
        Next
    End Sub

    Private Function CheckMark() As CheckState
        Dim iRet As CheckState = CheckState.Unchecked
        Dim iCnt As Integer = 0
        CheckBox3.Enabled = False

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Item(0, i).Value = True Then
                iCnt += 1
            End If
        Next
        If iCnt = DataGridView1.Rows.Count Then
            iRet = CheckState.Checked
        ElseIf iCnt > 0 Then
            iRet = CheckState.Indeterminate
        End If
        CheckBox3.Tag = If(iRet = 1, "Edit", "")
        'CheckBox3.Checked = If(iRet = 0, False, True)
        CheckBox3.CheckState = iRet
        CheckBox3.Enabled = True
        Return iRet
    End Function


    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.CurrentCellAddress.X = 0 AndAlso DataGridView1.IsCurrentCellDirty Then
            'コミットする
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = If(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = True, False, True)
                CheckMark()
            End If
            DataGridView1_SelectionChanged(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If DataGridView1.SelectedRows.Count >= 1 Then
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            End If
        End If
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        '右クリックなら削除メニューを表示
        If DataGridView1.SelectedRows.Count >= 1 AndAlso e.Button = MouseButtons.Right Then
            ContextMenus.Show()
            ContextMenus.Top = Me.Top + DataGridView1.Top + e.Location.Y + 20
            ContextMenus.Left = Me.Left + DataGridView1.Left + e.Location.X
        End If
    End Sub

    '右クリックメニューの選択
    Private Sub ContextMenus_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenus.ItemClicked
        If e.ClickedItem Is ContextMenus.Items(0) Then
            ' 選択されている行をデータグリッドからすべて削除
            For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
                Me.DataGridView1.Rows.Remove(row)
            Next
            CheckMark()
        End If
    End Sub

    Private Sub LabelCDate_TextChanged(sender As Object, e As EventArgs) Handles LabelCDate.TextChanged
        toolTip1.SetToolTip(sender, CDate(sender.Text).ToString(DATEFMTJ, ci))
    End Sub

    Private Sub LabelMDate_TextChanged(sender As Object, e As EventArgs) Handles LabelMDate.TextChanged
        toolTip1.SetToolTip(sender, CDate(sender.Text).ToString(DATEFMTJ, ci))
    End Sub

    Private Sub TextBoxCDate_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCDate.TextChanged
        If IsDate(sender.Text) Then
            toolTip1.SetToolTip(sender, CDate(sender.Text).ToString(DATEFMTJ, ci))
        Else
            toolTip1.SetToolTip(sender, Nothing) 'hide効かねーでやんの
        End If
    End Sub

    Private Sub TextBoxMDate_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMDate.TextChanged
        If IsDate(sender.Text) Then
            toolTip1.SetToolTip(sender, CDate(sender.Text).ToString(DATEFMTJ, ci))
        Else
            toolTip1.SetToolTip(sender, Nothing)
        End If
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        Dim s As String = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
        If e.ColumnIndex > 2 And IsDate(s) Then
            toolTip1.SetToolTip(sender, CDate(s).ToString(DATEFMTJ, ci))
        Else
            toolTip1.SetToolTip(sender, Nothing)
        End If
    End Sub

    Private Sub frmTimeChg_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        toolTip1.Dispose()
    End Sub
End Class
