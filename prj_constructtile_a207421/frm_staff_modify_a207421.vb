Public Class frm_staff_modify_a207421

    Private currentStaffID As String

    ' Constructor to receive the Staff ID to update
    Public Sub New(staffID As String)
        InitializeComponent()
        currentStaffID = staffID
    End Sub

    Private Sub frm_staff_modify_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStaffData()
    End Sub

    Private Sub LoadStaffData()
        Try
            Dim query As String = "SELECT * FROM TBL_STAFF_A207421 WHERE FLD_STAFF_ID = '" & currentStaffID.Replace("'", "''") & "'"
            Dim dataTable As DataTable = ExecuteQuery(query)

            If dataTable.Rows.Count > 0 Then
                Dim row As DataRow = dataTable.Rows(0)

                ' Populate the fields with existing data
                txtStaffID.Text = row("FLD_STAFF_ID").ToString()
                txtStaffName.Text = row("FLD_STAFF_NAME").ToString()
                txtPosition.Text = row("FLD_POSITION").ToString()
                txtEmail.Text = row("FLD_EMAIL").ToString()
                txtPhone.Text = row("FLD_PHONE").ToString()

                ' Disable Staff ID field (Primary Key should not be editable)
                txtStaffID.ReadOnly = True
                txtStaffID.BackColor = Color.LightGray
            Else
                MessageBox.Show("Staff member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading staff data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtStaffName.Text) Then
                MessageBox.Show("Staff Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtStaffName.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtPosition.Text) Then
                MessageBox.Show("Position is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPosition.Focus()
                Return
            End If

            ' Email validation if provided
            If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
                If Not IsValidEmail(txtEmail.Text) Then
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtEmail.Focus()
                    Return
                End If
            End If

            ' Build UPDATE query
            Dim query As String = "UPDATE TBL_STAFF_A207421 SET " &
                                  "FLD_STAFF_NAME = '" & txtStaffName.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_POSITION = '" & txtPosition.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_EMAIL = '" & txtEmail.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_PHONE = '" & txtPhone.Text.Trim().Replace("'", "''") & "' " &
                                  "WHERE FLD_STAFF_ID = '" & currentStaffID.Replace("'", "''") & "'"

            ' Execute query
            If ExecuteNonQuery(query) Then
                MessageBox.Show("Staff member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating staff member: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a database constraint violation.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtStaffName.Clear()
        txtPosition.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtStaffName.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

End Class