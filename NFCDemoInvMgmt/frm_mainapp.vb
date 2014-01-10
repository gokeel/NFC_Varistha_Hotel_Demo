﻿Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports VB = Microsoft.VisualBasic


Public Class frm_mainapp
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim sql As String
    Dim cmd As MySqlCommand
    Dim rs As MySqlDataReader

    Private Sub tp_add_asset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_add_asset.Click

    End Sub
    Public Function conn_mysql() As MySqlConnection
        Try
            'Dim conn As MySqlConnection
            'conn = New MySqlConnection()
            conn.ConnectionString = "server=localhost; user id=root; password=ockytika; database=varistha_inv"
            Try
                conn.Open()
                Return conn
            Catch myerror As MySqlException
                MsgBox("Connection to the Database Failed")
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

    Private Sub tp_all_assets_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp_all_assets.Enter
        retriveDataToDataGrid(grid_assets)

    End Sub

    Private Sub TabControl1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Enter
        retriveDataToDataGrid(grid_assets_2)
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

        port = GlobalVariables.Port
        baud = GlobalVariables.Baudrate
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

    Sub verify_inserted_data()
        ' 1: asset id, 2: asset name, 4: asset type, 5: asset model, 6: asset purchase, 8: asset vendor
        Dim all_data As String
        Dim a_id, a_name, a_type, a_model, a_purchase, a_vendor As String

        rtb_verifydata.AppendText("--------------------------")
        rtb_verifydata.AppendText("--------------------------")
        rtb_verifydata.AppendText(read_data_human("Asset id: ", 1) & Environment.NewLine)
        rtb_verifydata.AppendText(read_data_human("Asset name: ", 2) & Environment.NewLine)
        rtb_verifydata.AppendText(read_data_human("Asset type: ", 4) & Environment.NewLine)
        rtb_verifydata.AppendText(read_data_human("Asset model: ", 5) & Environment.NewLine)
        rtb_verifydata.AppendText(read_data_human("Purchase year: ", 6) & Environment.NewLine)
        rtb_verifydata.AppendText(read_data_human("Vendor: ", 8) & Environment.NewLine)

        rf_halt(0)
        'lb_log.Items.Add("Comport is closed.")
    End Sub

    Function read_data_human(ByVal field As String, ByVal block As Integer) As String
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

        result = field & in_human

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

        Catch myerror As MySqlException
            MsgBox(myerror)
            conn.Close()
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
    End Sub

    Private Sub get_db_config()
        Dim strFile As String = "database.ini"
        Dim sr As New StreamReader(strFile)
        Dim InputString, config As String

        While sr.Peek <> -1
            InputString = sr.ReadLine()
            config = checkIfContains(InputString)
            InputString = String.Empty
        End While
        sr.Close()
        'MsgBox(config)
    End Sub

    Private Function checkIfContains(ByVal inputString As String) As String
        Dim m1, m2, m3, m4 As Match
        Dim server As String = "server=(\S+)"
        Dim userid As String = "userid=(\S+)"
        Dim passwd As String = "password=(\S+)"
        Dim db As String = "database=(\S+)"
        Dim result As String = ""

        m1 = Regex.Match(inputString, server, _
                        RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m2 = Regex.Match(inputString, userid, _
                        RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m3 = Regex.Match(inputString, passwd, _
                        RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        m4 = Regex.Match(inputString, db, _
                        RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        Do While m1.Success
            result = result & m1.Value & ";"
            m1 = m1.NextMatch()
        Loop
        MsgBox(result)
        Do While m2.Success
            result = result & m2.Value & ";"
            m2 = m2.NextMatch()
        Loop
        MsgBox(result)
        Do While m3.Success
            result = result & m3.Value & ";"
            m3 = m3.NextMatch()
        Loop
        MsgBox(result)
        Do While m4.Success
            result = result & m4.Value
            m4 = m4.NextMatch()
        Loop
        MsgBox(result)
        Return result
    End Function

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        get_db_config()

    End Sub
End Class