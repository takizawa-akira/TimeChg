﻿Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class frmTimeChg
    Private Const DATEFMT As String = "yyyy/MM/dd hh:mm:ss"
    Dim oldstate As CheckState
    Private Sub frmTimeChg_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.AllowDrop = True
        oldstate = CheckBox3.CheckState
        DataGridView1.AllowDrop = True
        Dim fileName() As String = Environment.GetCommandLineArgs
        For i As Integer = 1 To fileName.Length - 1
            If System.IO.File.Exists(fileName(i)) Then
                If Not CheckExist(fileName(i)) Then
                    Dim s() As String = {True, System.IO.Path.GetDirectoryName(fileName(i)), System.IO.Path.GetFileName(fileName(i)),
                        System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT),
                        System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT)}
                    DataGridView1.Rows.Add(s)
                End If
            End If
        Next
        CheckMark()
    End Sub

    Private Sub frmTimeChg_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        'ドロップされたすべてのファイル名を取得する
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length >= 1 Then
            For i As Integer = 0 To fileName.Length - 1
                If System.IO.File.Exists(fileName(i)) Then
                    If Not CheckExist(fileName(i)) Then
                        Dim s() As String = {True, System.IO.Path.GetDirectoryName(fileName(i)), System.IO.Path.GetFileName(fileName(i)),
                            System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT),
                            System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT)}
                        DataGridView1.Rows.Add(s)
                    End If
                End If
            Next
        End If
        CheckMark()
    End Sub

    Private Sub obj_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter, DataGridView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            'string型でなければ受け入れない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop
        'ドロップされたすべてのファイル名を取得する
        Dim fileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If fileName.Length >= 1 Then
            For i As Integer = 0 To fileName.Length - 1
                If System.IO.File.Exists(fileName(i)) Then
                    If Not CheckExist(fileName(i)) Then
                        Dim s() As String = {True, System.IO.Path.GetDirectoryName(fileName(i)), System.IO.Path.GetFileName(fileName(i)),
                        System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT),
                        System.IO.File.GetCreationTime(fileName(i)).ToString(DATEFMT), System.IO.File.GetLastWriteTime(fileName(i)).ToString(DATEFMT)}
                        DataGridView1.Rows.Add(s)
                    End If
                End If
            Next
        End If
        CheckMark()
    End Sub

    Private Function CheckExist(fileName As String) As Boolean
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
        If DataGridView1.CurrentRow.Index >= 0 Then
            LabelCDate.Text = DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value.ToString
            LabelMDate.Text = DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value.ToString
            TextBoxCDate.Text = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value.ToString
            TextBoxMDate.Text = DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value.ToString
        End If
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
                            System.IO.File.SetCreationTime(filename, newdate)
                            DataGridView1.Item(3, i).Value = newdate.ToString(DATEFMT)
                            flg = True
                        End If
                        If CheckBox2.Checked Then
                            System.IO.File.SetLastWriteTime(filename, moddate)
                            DataGridView1.Item(4, i).Value = moddate.ToString(DATEFMT)
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

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
    End Sub
    Private Sub CheckBox3_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckStateChanged
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

    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.CurrentCellAddress.X = 0 AndAlso DataGridView1.IsCurrentCellDirty Then
            'コミットする
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        '列のインデックスを確認する
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            'CheckMark()
        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = If(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value = True, False, True)
            CheckMark()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


End Class
