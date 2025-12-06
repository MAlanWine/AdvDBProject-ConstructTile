Public Class frm_customers_a207421

    Private Sub frm_customers_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomersData()
    End Sub

    Private Sub LoadCustomersData()
        Try
            Dim dataTable As DataTable = ExecuteQuery("SELECT * FROM TBL_CUSTOMERS_A207421")

            dataTable.Columns("FLD_CUSTOMER_ID").ColumnName = "Customer ID"
            dataTable.Columns("FLD_CUSTOMER_NAME").ColumnName = "Customer Name"
            dataTable.Columns("FLD_EMAIL").ColumnName = "Email"
            dataTable.Columns("FLD_PHONE").ColumnName = "Phone"
            dataTable.Columns("FLD_ADDRESS").ColumnName = "Address"

            dgvCustomers.DataSource = dataTable
            dgvCustomers.ReadOnly = True
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvCustomers.MultiSelect = False
            dgvCustomers.AllowUserToAddRows = False
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            lblRecordCount.Text = "Total Customers: " & dgvCustomers.Rows.Count.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadCustomersData()
        MessageBox.Show("Customers data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addForm As New frm_customers_add_a207421()
        addForm.ShowDialog()
        LoadCustomersData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvCustomers.SelectedRows.Count > 0 Then
            Dim customerId As String = dgvCustomers.SelectedRows(0).Cells("Customer ID").Value.ToString()
            Dim modifyForm As New frm_customers_modify_a207421(customerId)
            modifyForm.ShowDialog()
            LoadCustomersData()
        Else
            MessageBox.Show("Please select a customer to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvCustomers.SelectedRows.Count > 0 Then
            Dim customerId As String = dgvCustomers.SelectedRows(0).Cells("Customer ID").Value.ToString()
            Dim customerName As String = dgvCustomers.SelectedRows(0).Cells("Customer Name").Value.ToString()

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete customer '" & customerName & "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Try
                    Dim sql As String = "DELETE FROM TBL_CUSTOMERS_A207421 WHERE FLD_CUSTOMER_ID = '" & customerId & "'"
                    ExecuteNonQuery(sql)
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomersData()
                Catch ex As Exception
                    MessageBox.Show("Error deleting customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class
