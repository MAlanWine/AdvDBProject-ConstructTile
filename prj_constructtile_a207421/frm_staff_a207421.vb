Public Class frm_staff_a207421

    Private Sub frm_staff_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStaffData()
    End Sub

    Private Sub LoadStaffData()
        Try
            Dim dataTable As DataTable = ExecuteQuery("SELECT * FROM TBL_STAFF_A207421")

            ' Set friendly column names
            dataTable.Columns("FLD_STAFF_ID").ColumnName = "Staff ID"
            dataTable.Columns("FLD_STAFF_NAME").ColumnName = "Staff Name"
            dataTable.Columns("FLD_POSITION").ColumnName = "Position"
            dataTable.Columns("FLD_EMAIL").ColumnName = "Email"
            dataTable.Columns("FLD_PHONE").ColumnName = "Phone"

            dgvStaff.DataSource = dataTable
            dgvStaff.ReadOnly = True
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvStaff.MultiSelect = False
            dgvStaff.AllowUserToAddRows = False
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            lblRecordCount.Text = "Total Staff: " & dgvStaff.Rows.Count.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStaffData()
        MessageBox.Show("Staff data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addForm As New frm_staff_add_a207421()
        addForm.ShowDialog()
        LoadStaffData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvStaff.SelectedRows.Count > 0 Then
            Dim staffId As String = dgvStaff.SelectedRows(0).Cells("Staff ID").Value.ToString()
            Dim modifyForm As New frm_staff_modify_a207421(staffId)
            modifyForm.ShowDialog()
            LoadStaffData()
        Else
            MessageBox.Show("Please select a staff member to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class