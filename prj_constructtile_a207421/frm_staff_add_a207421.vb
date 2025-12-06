Public Class frm_staff_add_a207421

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrWhiteSpace(txtStaffID.Text) Then
                MessageBox.Show("Staff ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtStaffID.Focus()
                Return
            End If

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

            If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
                If Not IsValidEmail(txtEmail.Text) Then
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtEmail.Focus()
                    Return
                End If
            End If

            Dim query As String = "INSERT INTO TBL_STAFF_A207421 " &
                                  "(FLD_STAFF_ID, FLD_STAFF_NAME, FLD_POSITION, FLD_EMAIL, FLD_PHONE) " &
                                  "VALUES ('" & txtStaffID.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtStaffName.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtPosition.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtEmail.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtPhone.Text.Trim().Replace("'", "''") & "')"

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Staff member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                txtStaffID.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error adding staff member: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a duplicate Staff ID or database constraint violation.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ClearFields()
        txtStaffID.Clear()
        txtStaffName.Clear()
        txtPosition.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
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
