<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeChg
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColumnCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColumPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnCDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnMDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hideCreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hideModefyDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TextBoxCDate = New System.Windows.Forms.TextBox()
        Me.TextBoxMDate = New System.Windows.Forms.TextBox()
        Me.LabelCDate = New System.Windows.Forms.Label()
        Me.LabelMDate = New System.Windows.Forms.Label()
        Me.ButtonExec = New System.Windows.Forms.Button()
        Me.BtnRedo = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnCheck, Me.ColumPath, Me.ColumFile, Me.ColumnCDate, Me.ColumnMDate, Me.hideCreateDate, Me.hideModefyDate})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(32, 22)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(743, 358)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'ColumnCheck
        '
        Me.ColumnCheck.FalseValue = "False"
        Me.ColumnCheck.HeaderText = ""
        Me.ColumnCheck.Name = "ColumnCheck"
        Me.ColumnCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnCheck.TrueValue = "True"
        Me.ColumnCheck.Width = 40
        '
        'ColumPath
        '
        Me.ColumPath.HeaderText = "パス名"
        Me.ColumPath.Name = "ColumPath"
        Me.ColumPath.Width = 250
        '
        'ColumFile
        '
        Me.ColumFile.HeaderText = "ファイル名"
        Me.ColumFile.Name = "ColumFile"
        Me.ColumFile.Width = 150
        '
        'ColumnCDate
        '
        Me.ColumnCDate.HeaderText = "作成日"
        Me.ColumnCDate.Name = "ColumnCDate"
        Me.ColumnCDate.Width = 150
        '
        'ColumnMDate
        '
        Me.ColumnMDate.HeaderText = "更新日"
        Me.ColumnMDate.Name = "ColumnMDate"
        Me.ColumnMDate.Width = 150
        '
        'hideCreateDate
        '
        Me.hideCreateDate.HeaderText = "隠し作成日"
        Me.hideCreateDate.Name = "hideCreateDate"
        Me.hideCreateDate.Visible = False
        Me.hideCreateDate.Width = 5
        '
        'hideModefyDate
        '
        Me.hideModefyDate.HeaderText = "隠し更新日"
        Me.hideModefyDate.Name = "hideModefyDate"
        Me.hideModefyDate.Visible = False
        Me.hideModefyDate.Width = 5
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(37, 399)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "作成日"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(37, 421)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "変更日"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBoxCDate
        '
        Me.TextBoxCDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCDate.Location = New System.Drawing.Point(113, 399)
        Me.TextBoxCDate.Name = "TextBoxCDate"
        Me.TextBoxCDate.Size = New System.Drawing.Size(148, 19)
        Me.TextBoxCDate.TabIndex = 3
        '
        'TextBoxMDate
        '
        Me.TextBoxMDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMDate.Location = New System.Drawing.Point(113, 421)
        Me.TextBoxMDate.Name = "TextBoxMDate"
        Me.TextBoxMDate.Size = New System.Drawing.Size(148, 19)
        Me.TextBoxMDate.TabIndex = 4
        '
        'LabelCDate
        '
        Me.LabelCDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelCDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCDate.Location = New System.Drawing.Point(284, 399)
        Me.LabelCDate.Name = "LabelCDate"
        Me.LabelCDate.Size = New System.Drawing.Size(148, 19)
        Me.LabelCDate.TabIndex = 5
        Me.LabelCDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelMDate
        '
        Me.LabelMDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelMDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelMDate.Location = New System.Drawing.Point(284, 422)
        Me.LabelMDate.Name = "LabelMDate"
        Me.LabelMDate.Size = New System.Drawing.Size(148, 19)
        Me.LabelMDate.TabIndex = 6
        Me.LabelMDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonExec
        '
        Me.ButtonExec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExec.Location = New System.Drawing.Point(687, 398)
        Me.ButtonExec.Name = "ButtonExec"
        Me.ButtonExec.Size = New System.Drawing.Size(88, 38)
        Me.ButtonExec.TabIndex = 7
        Me.ButtonExec.Text = "実行"
        Me.ButtonExec.UseVisualStyleBackColor = True
        '
        'BtnRedo
        '
        Me.BtnRedo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRedo.Enabled = False
        Me.BtnRedo.Location = New System.Drawing.Point(593, 398)
        Me.BtnRedo.Name = "BtnRedo"
        Me.BtnRedo.Size = New System.Drawing.Size(88, 38)
        Me.BtnRedo.TabIndex = 8
        Me.BtnRedo.Text = "復元"
        Me.BtnRedo.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoCheck = False
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(47, 27)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 9
        Me.CheckBox3.ThreeState = True
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'frmTimeChg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 446)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.BtnRedo)
        Me.Controls.Add(Me.ButtonExec)
        Me.Controls.Add(Me.LabelMDate)
        Me.Controls.Add(Me.LabelCDate)
        Me.Controls.Add(Me.TextBoxMDate)
        Me.Controls.Add(Me.TextBoxCDate)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmTimeChg"
        Me.Text = "TimeChg"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents TextBoxCDate As TextBox
    Friend WithEvents TextBoxMDate As TextBox
    Friend WithEvents LabelCDate As Label
    Friend WithEvents LabelMDate As Label
    Friend WithEvents ButtonExec As Button
    Friend WithEvents BtnRedo As Button
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents ColumnCheck As DataGridViewCheckBoxColumn
    Friend WithEvents ColumPath As DataGridViewTextBoxColumn
    Friend WithEvents ColumFile As DataGridViewTextBoxColumn
    Friend WithEvents ColumnCDate As DataGridViewTextBoxColumn
    Friend WithEvents ColumnMDate As DataGridViewTextBoxColumn
    Friend WithEvents hideCreateDate As DataGridViewTextBoxColumn
    Friend WithEvents hideModefyDate As DataGridViewTextBoxColumn
End Class
