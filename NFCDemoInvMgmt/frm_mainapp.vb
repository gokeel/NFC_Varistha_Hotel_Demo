Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports VB = Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Text


Public Class frm_mainapp

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, _
            ByVal lpKeyName As String, _
            ByVal lpDefault As String, _
            ByVal lpReturnedString As StringBuilder, _
            ByVal nSize As Integer, _
            ByVal lpFileName As String) As Integer

    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim sql As String
    Dim cmd As MySqlCommand
    Dim rs As MySqlDataReader

    Public Function conn_mysql() As MySqlConnection
        Try
            'Dim conn As MySqlConnection
            'conn = New MySqlConnection()
            'conn.ConnectionString = "server=localhost; user id=root; password=ockytika; database=varistha_inv"
            conn.ConnectionString = get_db_config()

            Try
                conn.Open()
                Return conn
            Catch myerror As MySqlException
                MsgBox("Connection to the Database Failed - " & myerror.Message)
                GoTo a
            End Try

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
a:
    End Function

    Sub retriveDataToDataGrid(ByVal grid_name As DataGridView)
        Try
            'Dim conn As MySqlConnection
            conn = conn_mysql()

            sql = "SELECT * FROM assets"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim ds As New DataSet()

            If da.Fill(ds) Then
                grid_name.DataSource = ds.Tables(0)
            End If

            conn.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
a:
    End Sub

    Private Sub tp_add_asset_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_add_asset.Enter
        rtb_verifydata.Visible = True
    End Sub

    Private Sub tp_all_assets_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_all_assets.Enter
        retriveDataToDataGrid(grid_assets)

    End Sub

    Sub Check_Numeric_Textbox(ByVal tb As TextBox)
        If Not (IsNumeric(tb.Text)) And tb.Text <> "" Then
            MsgBox("Use numeric only.")
        End If
    End Sub

    Private Sub tb_asset_id_1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_asset_id_1.Leave
        Check_Numeric_Textbox(tb_asset_id_1)
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_purchase_year_1.Leave
        Check_Numeric_Textbox(tb_purchase_year_1)
    End Sub

    Private Sub read_uuid()
        Dim port, i, baud As Integer
        Dim j As Short
        Dim buf1(200) As Byte
        Dim b1 As Byte
        Dim s1 As String

        port = get_comport_config("port")
        baud = get_comport_config("baudrate")
        'Open Port
        i = rf_init_com(port, baud)
        If (i <> 0) Then
            status_label_nfc.Text = "Open Port Failed!"

            Exit Sub
        End If
        'Request
        i = rf_request(0, &H52S, j)
        If (i <> 0) Then
            status_label_nfc.Text = "Request Failed!"
            Exit Sub
        End If
        'Anticollision
        i = rf_anticoll(0, 4, buf1(0), b1)
        If (i <> 0) Then
            status_label_nfc.Text = "Anticollision Failed!"
            Exit Sub
        End If
        s1 = ""
        For i = 0 To b1 - 1
            s1 = s1 & VB.Right("00" & Hex(buf1(i)), 2)
        Next i
        'MsgBox(s1) 'popup serial number
        'Select card
        i = rf_select(0, buf1(0), 4, b1)
        If (i <> 0) Then
            status_label_nfc.Text = "Select card failed!"
            Exit Sub
        End If
        'status_label_nfc.Text = "Select card succeed!"

        status_label_nfc.Text = "UUID = " & s1
        'Return s1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        read_uuid()
        MsgBox(read_block(1))

    End Sub

    Sub write_block(ByVal blok As Integer, ByVal data_input As String)
        Dim i As Integer
        Dim buf1(200) As Byte
        Dim buf2(200) As Byte
        Dim keyA As String = "FFFFFFFFFFFF"
        Dim byte_keyA As Byte = &H60S
        Dim byte_keyB As Byte = &H61S
        Dim byte_out As Byte

        If (Len(keyA) <> 12) Then
            status_label_nfc.Text = "Wrong Key Length!"
            'lb_log.Items.Add("Wrong Key Length!")
            Exit Sub
        End If
        For i = 0 To 5
            buf1(i) = Val("&H" & Mid(keyA, i * 2 + 1, 2))
        Next i

        If (blok = 0) Then
            status_label_nfc.Text = "Select Block Please!"
            'lb_log.Items.Add("Select Block Please!")
            Exit Sub
        End If

        'using byte Key A


        If (Len(data_input) <> 32) Then
            status_label_nfc.Text = "Wrong Data length "
            'lb_log.Items.Add("Wrong Data length ")
            Exit Sub
        End If
        For i = 0 To 15
            buf2(i) = Val("&H" & Mid(data_input, i * 2 + 1, 2))
        Next i
        'Authentication
        byte_out = CByte(blok)
        i = rf_M1_authentication2(0, byte_keyA, byte_out, buf1(0))
        If (i <> 0) Then
            status_label_nfc.Text = "Authentication Fail!"
            'lb_log.Items.Add("Authentication Fail!")
            Exit Sub
        End If
        'Write card
        i = rf_M1_write(0, byte_out, buf2(0))
        If (i <> 0) Then
            status_label_nfc.Text = "Write Card Fail"
            'lb_log.Items.Add("Write Card Fail")
            Exit Sub
        End If

        status_label_nfc.Text = "Write Succeed!"
        'lb_log.Items.Add("Write Succeed!")

    End Sub

    Sub Write_Data(ByVal field As String, ByVal data As String, ByVal block As Integer)
        'lb_log.Items.Add("Writing data " & field)
        'checking block first
        If block = 0 Then
            status_label_nfc.Text = "Data tidak boleh ditulis di blok 0."
            'lb_log.Items.Add("Data tidak boleh ditulis di blok 0.")
            Exit Sub
        End If
        For i As Integer = 0 To 15
            If block = i * 4 + 3 Then
                status_label_nfc.Text = "Data tidak boleh ditulis di blok key."
                'lb_log.Items.Add("Data tidak boleh ditulis di blok key.")
                Exit Sub
            End If
        Next i

        Dim m_no_hex As String = StrToHex(data)
        'MsgBox(m_no_hex)
        Dim pjg As Integer = m_no_hex.Length
        Dim add_F, fix_hex As String

        If pjg < 32 Then
            For cnt As Integer = (pjg + 1) To 32
                add_F = add_F & "F"
            Next
        ElseIf pjg > 32 Then
            status_label_nfc.Text = "Field " & field & " terlalu panjang."
            'lb_log.Items.Add("Field " & field & " terlalu panjang.")
            Exit Sub
        End If
        fix_hex = m_no_hex & add_F
        read_uuid()
        write_block(block, fix_hex)
    End Sub

    Function read_block(ByVal block As Integer) As String
        Dim keyA As String = "FFFFFFFFFFFF"
        Dim byte_keyA As Byte = &H60S
        Dim byte_keyB As Byte = &H61S
        Dim byte_out, byte_block As Byte

        Dim i As Integer
        Dim buf1(200) As Byte
        Dim buf2(200) As Byte
        Dim result As String

        If (Len(keyA) <> 12) Then
            status_label_nfc.Text = "Wrong Key Length!"
            'lb_log.Items.Add("Wrong Key Length!")
            Exit Function
        End If
        For i = 0 To 5
            buf1(i) = Val("&H" & Mid(keyA, i * 2 + 1, 2))
        Next i

        If (block = 0) Then
            status_label_nfc.Text = "Select Block Please!"
            'lb_log.Items.Add("Select Block Please!")
            Exit Function
        End If

        byte_block = CByte(block)
        'Authentication
        i = rf_M1_authentication2(0, byte_keyA, byte_block, buf1(0))
        If (i <> 0) Then
            status_label_nfc.Text = "Authentication Fail"
            'lb_log.Items.Add("Authentication Fail")
            Exit Function
        End If
        'Read card
        i = rf_M1_read(0, byte_block, buf2(0), byte_out)
        If (i <> 0) Then
            status_label_nfc.Text = "Read Card Fail!"
            'lb_log.Items.Add("Read Card Fail!")
            Exit Function
        End If
        result = ""
        For i = 0 To byte_out - 1
            result = result & VB.Right("00" & Hex(buf2(i)), 2)
        Next i

        status_label_nfc.Text = "Read Succeed!"
        'lb_log.Items.Add("Read Succeed!")

        read_block = result
        Exit Function
    End Function

    Sub verify_inserted_data(ByVal output As String)
        ' 1: asset id, 2: asset name, 4: asset type, 5: asset model, 6: asset purchase, 8: asset vendor
        'Dim all_data As String
        'Dim a_id, a_name, a_type, a_model, a_purchase, a_vendor As String
        clear_textbox("find")
        read_uuid()
        If output = "rtb" Then
            rtb_verifydata.AppendText("--------------------------" & Environment.NewLine)
            rtb_verifydata.AppendText("VERIFY RESULT" & Environment.NewLine)
            rtb_verifydata.AppendText("--------------------------" & Environment.NewLine)
            rtb_verifydata.AppendText("Asset id: " & read_data_human(1) & Environment.NewLine)
            rtb_verifydata.AppendText("Asset name: " & read_data_human(2) & Environment.NewLine)
            rtb_verifydata.AppendText("Asset type: " & read_data_human(4) & Environment.NewLine)
            rtb_verifydata.AppendText("Asset model: " & read_data_human(5) & Environment.NewLine)
            rtb_verifydata.AppendText("Purchase year: " & read_data_human(6) & Environment.NewLine)
            rtb_verifydata.AppendText("Vendor: " & read_data_human(8) & Environment.NewLine)
        ElseIf output = "textbox" Then
            tb_asset_id_2.Text = read_data_human(1)
            tb_asset_name_2.Text = read_data_human(2)
            tb_asset_type_1.Text = read_data_human(4)
            tb_asset_model_1.Text = read_data_human(5)
            tb_purchase_year_2.Text = read_data_human(6)
            tb_vendor_2.Text = read_data_human(8)
        End If
        

        rf_halt(0)
        'lb_log.Items.Add("Comport is closed.")
    End Sub

    Function read_data_human(ByVal block As Integer) As String
        Dim result, in_human, in_convert As String
        Dim indexChar As Integer = 0

        'lb_log.Items.Add("Reading data " & field)
        result = ""
        in_convert = HexToStr(read_block(block))
        indexChar = in_convert.IndexOf(Chr(255))
        If indexChar > 0 Then
            in_human = in_convert.Substring(0, (indexChar))
        Else
            in_human = in_convert
        End If

        result = in_human

        Return result
    End Function

    Public Function StrToHex(ByRef Data As String) As String
        Dim sVal As String
        Dim sHex As String = ""
        'Dim i As Long

        'For i = 1 To Data.Length
        'sVal = Hex(Asc(Mid(Data, i, 1)))
        'If sVal.Length < 2 Then
        'sVal = "0" & sVal
        'End If
        'sHex = sHex & Space(1) & sVal
        'Next i
        While Data.Length > 0
            sVal = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()))
            Data = Data.Substring(1, Data.Length - 1)
            sHex = sHex & sVal

        End While
        Return sHex

    End Function

    Public Function HexToStr(ByRef Data As String) As String
        Dim sHex As String
        Dim sVal As String = ""
        Dim i As Long
        For i = 1 To Data.Length Step 2
            sHex = Chr(Val("&H" & Mid(Data, i, 2)))
            sVal = sVal & sHex
        Next i
        Return sVal
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a_id, a_name, a_type, a_model, a_purchase, a_vendor As String
        a_id = tb_asset_id_1.Text
        a_type = tb_asset_type_1.Text
        a_name = tb_asset_name_1.Text
        a_purchase = tb_purchase_year_1.Text
        a_vendor = tb_vendor_1.Text
        a_model = tb_asset_model_1.Text
        Try
            conn_mysql()

            sql = "insert into assets values ('" & a_id & "','" & a_name & "','" & a_model & "','" & a_type & "','" & a_purchase & "','" & a_vendor & "')"
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            status_label_db.Text = "Data inserted into database."
            conn.Close()
            Button1.Enabled = False
        Catch myerror As MySqlException
            MsgBox(myerror.Message)
            GoTo a
        End Try
a:
    End Sub

    Sub clear_textbox(ByVal grup As String)
        If grup = "add" Then
            tb_asset_id_1.Clear()
            tb_asset_name_1.Clear()
            tb_asset_model_1.Clear()
            tb_asset_type_1.Clear()
            tb_purchase_year_1.Clear()
            tb_vendor_1.Clear()
        ElseIf grup = "find" Then
            tb_asset_id_2.Clear()
            tb_asset_name_2.Clear()
            tb_asset_model_2.Clear()
            tb_asset_type_2.Clear()
            tb_purchase_year_2.Clear()
            tb_vendor_2.Clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("Please tap the tag until data have been written.")
        Dim a_id, a_name, a_type, a_model, a_purchase, a_vendor As String
        a_id = tb_asset_id_1.Text 'blok 1
        a_name = tb_asset_name_1.Text 'blok 2
        a_type = tb_asset_type_1.Text 'blok 4
        a_model = tb_asset_model_1.Text 'blok 5
        a_purchase = tb_purchase_year_1.Text 'blok 6
        a_vendor = tb_vendor_1.Text 'blok 8

        Write_Data("", a_id, 1)
        Write_Data("", a_name, 2)
        Write_Data("", a_type, 4)
        Write_Data("", a_model, 5)
        Write_Data("", a_purchase, 6)
        Write_Data("", a_vendor, 8)

        clear_textbox("add")
        Button1.Enabled = True

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_verify_data.Click
        rtb_verifydata.Clear()
        verify_inserted_data("rtb")

    End Sub

    Private Function get_db_config() As String
        Dim res As Integer
        Dim server, userid, passwd, db As StringBuilder
        Dim strPath, result As String
        strPath = Application.StartupPath

        result = ""
        server = New StringBuilder(500)
        res = GetPrivateProfileString("database", "server", "", server, server.Capacity, strPath & "\config.ini")
        result = result & "server=" & server.ToString & ";"

        userid = New StringBuilder(500)
        res = GetPrivateProfileString("database", "userid", "", userid, userid.Capacity, strPath & "\config.ini")
        result = result & "user id=" & userid.ToString & ";"

        passwd = New StringBuilder(500)
        res = GetPrivateProfileString("database", "password", "", passwd, passwd.Capacity, strPath & "\config.ini")
        result = result & "password=" & passwd.ToString & ";"

        db = New StringBuilder(500)
        res = GetPrivateProfileString("database", "database", "", db, db.Capacity, strPath & "\config.ini")
        result = result & "database=" & db.ToString

        Return result
        'MsgBox("GetPrivateProfileStrng returned : " & res.ToString())
        'MsgBox("KeyName is : " & sb.ToString())
        'Console.WriteLine("GetPrivateProfileStrng returned : " & res.ToString())
        'Console.WriteLine("KeyName is : " & sb.ToString())
        'Console.ReadLine();
    End Function

    Private Function get_comport_config(ByVal par As String) As Integer
        Dim res As Integer
        Dim param As StringBuilder
        Dim strPath As String
        Dim result As Integer

        strPath = Application.StartupPath

        param = New StringBuilder(500)
        res = GetPrivateProfileString("comport", par, "", param, param.Capacity, strPath & "\config.ini")
        result = Convert.ToInt32(param.ToString)
        Return result

    End Function

    
    Private Sub tp_find_asset_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_find_asset.Enter
        rtb_verifydata.Visible = False
    End Sub

    
    Private Sub btn_scan_tag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_scan_tag.Click
        verify_inserted_data("textbox")
    End Sub

End Class