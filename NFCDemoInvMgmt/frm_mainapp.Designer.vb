<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mainapp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tp_add_asset = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tb_vendor_1 = New System.Windows.Forms.TextBox()
        Me.tb_purchase_year_1 = New System.Windows.Forms.TextBox()
        Me.tb_asset_model_1 = New System.Windows.Forms.TextBox()
        Me.tb_asset_type_1 = New System.Windows.Forms.TextBox()
        Me.tb_asset_name_1 = New System.Windows.Forms.TextBox()
        Me.tb_asset_id_1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tp_find_asset = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tb_vendor_2 = New System.Windows.Forms.TextBox()
        Me.tb_purchase_year_2 = New System.Windows.Forms.TextBox()
        Me.tb_asset_model_2 = New System.Windows.Forms.TextBox()
        Me.tb_asset_type_2 = New System.Windows.Forms.TextBox()
        Me.tb_asset_name_2 = New System.Windows.Forms.TextBox()
        Me.tb_asset_id_2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tp_all_assets = New System.Windows.Forms.TabPage()
        Me.grid_assets = New System.Windows.Forms.DataGridView()
        Me.tp_update_asset = New System.Windows.Forms.TabPage()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.grid_assets_2 = New System.Windows.Forms.DataGridView()
        Me.status_label = New System.Windows.Forms.StatusStrip()
        Me.status_label_nfc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.status_label_db = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rtb_verifydata = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.tp_add_asset.SuspendLayout()
        Me.tp_find_asset.SuspendLayout()
        Me.tp_all_assets.SuspendLayout()
        CType(Me.grid_assets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_update_asset.SuspendLayout()
        CType(Me.grid_assets_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.status_label.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fixed Assets - Varistha Hotel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(302, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inventory System"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tp_add_asset)
        Me.TabControl1.Controls.Add(Me.tp_find_asset)
        Me.TabControl1.Controls.Add(Me.tp_all_assets)
        Me.TabControl1.Controls.Add(Me.tp_update_asset)
        Me.TabControl1.Location = New System.Drawing.Point(55, 140)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(678, 350)
        Me.TabControl1.TabIndex = 4
        '
        'tp_add_asset
        '
        Me.tp_add_asset.Controls.Add(Me.Button6)
        Me.tp_add_asset.Controls.Add(Me.Button2)
        Me.tp_add_asset.Controls.Add(Me.Button1)
        Me.tp_add_asset.Controls.Add(Me.tb_vendor_1)
        Me.tp_add_asset.Controls.Add(Me.tb_purchase_year_1)
        Me.tp_add_asset.Controls.Add(Me.tb_asset_model_1)
        Me.tp_add_asset.Controls.Add(Me.tb_asset_type_1)
        Me.tp_add_asset.Controls.Add(Me.tb_asset_name_1)
        Me.tp_add_asset.Controls.Add(Me.tb_asset_id_1)
        Me.tp_add_asset.Controls.Add(Me.Label8)
        Me.tp_add_asset.Controls.Add(Me.Label7)
        Me.tp_add_asset.Controls.Add(Me.Label6)
        Me.tp_add_asset.Controls.Add(Me.Label5)
        Me.tp_add_asset.Controls.Add(Me.Label4)
        Me.tp_add_asset.Controls.Add(Me.Label3)
        Me.tp_add_asset.Location = New System.Drawing.Point(4, 22)
        Me.tp_add_asset.Name = "tp_add_asset"
        Me.tp_add_asset.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_add_asset.Size = New System.Drawing.Size(670, 324)
        Me.tp_add_asset.TabIndex = 0
        Me.tp_add_asset.Text = "Add Asset"
        Me.tp_add_asset.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(500, 267)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(111, 51)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Verify Data"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(367, 267)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 51)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Send Data to NFC Tag"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(237, 267)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 51)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Register Asset to Database"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tb_vendor_1
        '
        Me.tb_vendor_1.Location = New System.Drawing.Point(481, 109)
        Me.tb_vendor_1.Name = "tb_vendor_1"
        Me.tb_vendor_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_vendor_1.TabIndex = 11
        '
        'tb_purchase_year_1
        '
        Me.tb_purchase_year_1.Location = New System.Drawing.Point(481, 73)
        Me.tb_purchase_year_1.Name = "tb_purchase_year_1"
        Me.tb_purchase_year_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_purchase_year_1.TabIndex = 10
        '
        'tb_asset_model_1
        '
        Me.tb_asset_model_1.Location = New System.Drawing.Point(481, 35)
        Me.tb_asset_model_1.Name = "tb_asset_model_1"
        Me.tb_asset_model_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_model_1.TabIndex = 9
        '
        'tb_asset_type_1
        '
        Me.tb_asset_type_1.Location = New System.Drawing.Point(136, 109)
        Me.tb_asset_type_1.Name = "tb_asset_type_1"
        Me.tb_asset_type_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_type_1.TabIndex = 8
        '
        'tb_asset_name_1
        '
        Me.tb_asset_name_1.Location = New System.Drawing.Point(136, 73)
        Me.tb_asset_name_1.Name = "tb_asset_name_1"
        Me.tb_asset_name_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_name_1.TabIndex = 7
        '
        'tb_asset_id_1
        '
        Me.tb_asset_id_1.Location = New System.Drawing.Point(136, 35)
        Me.tb_asset_id_1.Name = "tb_asset_id_1"
        Me.tb_asset_id_1.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_id_1.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(389, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Vendor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(389, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Purchase Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(389, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Asset Model"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Asset Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Asset Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Asset ID"
        '
        'tp_find_asset
        '
        Me.tp_find_asset.Controls.Add(Me.Button3)
        Me.tp_find_asset.Controls.Add(Me.Button4)
        Me.tp_find_asset.Controls.Add(Me.tb_vendor_2)
        Me.tp_find_asset.Controls.Add(Me.tb_purchase_year_2)
        Me.tp_find_asset.Controls.Add(Me.tb_asset_model_2)
        Me.tp_find_asset.Controls.Add(Me.tb_asset_type_2)
        Me.tp_find_asset.Controls.Add(Me.tb_asset_name_2)
        Me.tp_find_asset.Controls.Add(Me.tb_asset_id_2)
        Me.tp_find_asset.Controls.Add(Me.Label9)
        Me.tp_find_asset.Controls.Add(Me.Label10)
        Me.tp_find_asset.Controls.Add(Me.Label11)
        Me.tp_find_asset.Controls.Add(Me.Label12)
        Me.tp_find_asset.Controls.Add(Me.Label13)
        Me.tp_find_asset.Controls.Add(Me.Label14)
        Me.tp_find_asset.Location = New System.Drawing.Point(4, 22)
        Me.tp_find_asset.Name = "tp_find_asset"
        Me.tp_find_asset.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_find_asset.Size = New System.Drawing.Size(670, 324)
        Me.tp_find_asset.TabIndex = 1
        Me.tp_find_asset.Text = "Find Assets"
        Me.tp_find_asset.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(391, 253)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 51)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "Send Data to NFC Tag"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(261, 253)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(111, 51)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "Register Asset to Database"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tb_vendor_2
        '
        Me.tb_vendor_2.Location = New System.Drawing.Point(505, 95)
        Me.tb_vendor_2.Name = "tb_vendor_2"
        Me.tb_vendor_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_vendor_2.TabIndex = 25
        '
        'tb_purchase_year_2
        '
        Me.tb_purchase_year_2.Location = New System.Drawing.Point(505, 59)
        Me.tb_purchase_year_2.Name = "tb_purchase_year_2"
        Me.tb_purchase_year_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_purchase_year_2.TabIndex = 24
        '
        'tb_asset_model_2
        '
        Me.tb_asset_model_2.Location = New System.Drawing.Point(505, 21)
        Me.tb_asset_model_2.Name = "tb_asset_model_2"
        Me.tb_asset_model_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_model_2.TabIndex = 23
        '
        'tb_asset_type_2
        '
        Me.tb_asset_type_2.Location = New System.Drawing.Point(160, 95)
        Me.tb_asset_type_2.Name = "tb_asset_type_2"
        Me.tb_asset_type_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_type_2.TabIndex = 22
        '
        'tb_asset_name_2
        '
        Me.tb_asset_name_2.Location = New System.Drawing.Point(160, 59)
        Me.tb_asset_name_2.Name = "tb_asset_name_2"
        Me.tb_asset_name_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_name_2.TabIndex = 21
        '
        'tb_asset_id_2
        '
        Me.tb_asset_id_2.Location = New System.Drawing.Point(160, 21)
        Me.tb_asset_id_2.Name = "tb_asset_id_2"
        Me.tb_asset_id_2.Size = New System.Drawing.Size(142, 20)
        Me.tb_asset_id_2.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(413, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Vendor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(413, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Purchase Year"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(413, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Asset Model"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(59, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Asset Type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(59, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Asset Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(59, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Asset ID"
        '
        'tp_all_assets
        '
        Me.tp_all_assets.Controls.Add(Me.grid_assets)
        Me.tp_all_assets.Location = New System.Drawing.Point(4, 22)
        Me.tp_all_assets.Name = "tp_all_assets"
        Me.tp_all_assets.Size = New System.Drawing.Size(670, 324)
        Me.tp_all_assets.TabIndex = 2
        Me.tp_all_assets.Text = "All Assets"
        Me.tp_all_assets.UseVisualStyleBackColor = True
        '
        'grid_assets
        '
        Me.grid_assets.AllowUserToAddRows = False
        Me.grid_assets.AllowUserToDeleteRows = False
        Me.grid_assets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_assets.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grid_assets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_assets.Location = New System.Drawing.Point(18, 20)
        Me.grid_assets.Name = "grid_assets"
        Me.grid_assets.Size = New System.Drawing.Size(675, 301)
        Me.grid_assets.TabIndex = 0
        '
        'tp_update_asset
        '
        Me.tp_update_asset.Controls.Add(Me.btn_delete)
        Me.tp_update_asset.Controls.Add(Me.btn_update)
        Me.tp_update_asset.Controls.Add(Me.grid_assets_2)
        Me.tp_update_asset.Location = New System.Drawing.Point(4, 22)
        Me.tp_update_asset.Name = "tp_update_asset"
        Me.tp_update_asset.Size = New System.Drawing.Size(670, 324)
        Me.tp_update_asset.TabIndex = 3
        Me.tp_update_asset.Text = "Update Asset"
        Me.tp_update_asset.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(151, 292)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(110, 22)
        Me.btn_delete.TabIndex = 2
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(24, 292)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(110, 22)
        Me.btn_update.TabIndex = 1
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'grid_assets_2
        '
        Me.grid_assets_2.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grid_assets_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_assets_2.Location = New System.Drawing.Point(14, 15)
        Me.grid_assets_2.Name = "grid_assets_2"
        Me.grid_assets_2.Size = New System.Drawing.Size(676, 274)
        Me.grid_assets_2.TabIndex = 0
        '
        'status_label
        '
        Me.status_label.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status_label_nfc, Me.status_label_db})
        Me.status_label.Location = New System.Drawing.Point(0, 486)
        Me.status_label.Name = "status_label"
        Me.status_label.Size = New System.Drawing.Size(939, 22)
        Me.status_label.TabIndex = 5
        '
        'status_label_nfc
        '
        Me.status_label_nfc.Name = "status_label_nfc"
        Me.status_label_nfc.Size = New System.Drawing.Size(0, 17)
        '
        'status_label_db
        '
        Me.status_label_db.Name = "status_label_db"
        Me.status_label_db.Size = New System.Drawing.Size(0, 17)
        '
        'rtb_verifydata
        '
        Me.rtb_verifydata.Location = New System.Drawing.Point(740, 160)
        Me.rtb_verifydata.Name = "rtb_verifydata"
        Me.rtb_verifydata.Size = New System.Drawing.Size(187, 319)
        Me.rtb_verifydata.TabIndex = 6
        Me.rtb_verifydata.Text = ""
        '
        'frm_mainapp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 508)
        Me.Controls.Add(Me.rtb_verifydata)
        Me.Controls.Add(Me.status_label)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_mainapp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_mainapp"
        Me.TabControl1.ResumeLayout(False)
        Me.tp_add_asset.ResumeLayout(False)
        Me.tp_add_asset.PerformLayout()
        Me.tp_find_asset.ResumeLayout(False)
        Me.tp_find_asset.PerformLayout()
        Me.tp_all_assets.ResumeLayout(False)
        CType(Me.grid_assets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_update_asset.ResumeLayout(False)
        CType(Me.grid_assets_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.status_label.ResumeLayout(False)
        Me.status_label.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tp_add_asset As System.Windows.Forms.TabPage
    Friend WithEvents tp_find_asset As System.Windows.Forms.TabPage
    Friend WithEvents tp_all_assets As System.Windows.Forms.TabPage
    Friend WithEvents tp_update_asset As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tb_vendor_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_purchase_year_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_model_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_type_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_name_1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_id_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents tb_vendor_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_purchase_year_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_model_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_type_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_name_2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_asset_id_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents grid_assets As System.Windows.Forms.DataGridView
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents grid_assets_2 As System.Windows.Forms.DataGridView
    Friend WithEvents status_label As System.Windows.Forms.StatusStrip
    Friend WithEvents status_label_nfc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents status_label_db As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rtb_verifydata As System.Windows.Forms.RichTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
