Public Class frm_customers_modify_a207421

    Private currentCustomerID As String

    ' Constructor to receive the Customer ID to update
    Public Sub New(customerID As String)
        InitializeComponent()
        currentCustomerID = customerID
    End Sub

    Private Sub frm_customers_modify_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomerData()
    End Sub

    Private Sub LoadCustomerData()
        Try
            Dim query As String = "SELECT * FROM TBL_CUSTOMERS_A207421 WHERE FLD_CUSTOMER_ID = '" & currentCustomerID.Replace("'", "''") & "'"
            Dim dataTable As DataTable = ExecuteQuery(query)

            If dataTable.Rows.Count > 0 Then
                Dim row As DataRow = dataTable.Rows(0)

                ' Populate the fields with existing data
                txtCustomerID.Text = row("FLD_CUSTOMER_ID").ToString()
                txtCustomerName.Text = row("FLD_CUSTOMER_NAME").ToString()
                txtAddress.Text = row("FLD_ADDRESS").ToString()
                txtPhone.Text = row("FLD_PHONE").ToString()

                ' Disable Customer ID field (Primary Key should not be editable)
                txtCustomerID.ReadOnly = True
                txtCustomerID.BackColor = Color.LightGray
            Else
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading customer data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
                MessageBox.Show("Customer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Return
            End If

            ' Build UPDATE query
            Dim query As String = "UPDATE TBL_CUSTOMERS_A207421 SET " &
                                  "FLD_CUSTOMER_NAME = '" & txtCustomerName.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_ADDRESS = '" & txtAddress.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_PHONE = '" & txtPhone.Text.Trim().Replace("'", "''") & "' " &
                                  "WHERE FLD_CUSTOMER_ID = '" & currentCustomerID.Replace("'", "''") & "'"

            ' Execute query
            If ExecuteNonQuery(query) Then
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating customer: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a database constraint violation.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtCustomerName.Clear()
        txtAddress.Clear()
        txtPhone.Clear()
        txtCustomerName.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class