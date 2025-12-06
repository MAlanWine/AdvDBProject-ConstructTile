Public Class frm_customers_add_a207421

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrWhiteSpace(txtCustomerID.Text) Then
                MessageBox.Show("Customer ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerID.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("Customer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Return
            End If

            Dim query As String = "INSERT INTO TBL_CUSTOMERS_A207421 " &
                                  "(FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME, FLD_EMAIL, FLD_PHONE, FLD_ADDRESS) " &
                                  "VALUES ('" & txtCustomerID.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtCustomerName.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtEmail.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtPhone.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtAddress.Text.Trim().Replace("'", "''") & "')"

            If ExecuteNonQuery(query) Then
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                txtCustomerID.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error adding customer: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a duplicate Customer ID or database constraint violation.",
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
        txtCustomerID.Clear()
        txtCustomerName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
    End Sub

End Class
