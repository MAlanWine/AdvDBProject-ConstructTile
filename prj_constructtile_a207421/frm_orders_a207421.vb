Public Class frm_orders_a207421

    Private Sub frm_orders_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrdersData()
    End Sub

    Private Sub LoadOrdersData()
        Try
            Dim query As String = "SELECT O.FLD_ORDER_ID AS [Order ID], " &
                                  "C.FLD_CUSTOMER_NAME AS [Customer Name], " &
                                  "S.FLD_STAFF_NAME AS [Staff Name], " &
                                  "O.FLD_ORDER_DATE AS [Order Date], " &
                                  "O.FLD_TOTAL_AMOUNT AS [Total Amount (RM)] " &
                                  "FROM (TBL_ORDERS_A207421 AS O " &
                                  "INNER JOIN TBL_CUSTOMERS_A207421 AS C ON O.FLD_CUSTOMER_ID = C.FLD_CUSTOMER_ID) " &
                                  "INNER JOIN TBL_STAFF_A207421 AS S ON O.FLD_STAFF_ID = S.FLD_STAFF_ID"
            Dim dataTable As DataTable = ExecuteQuery(query)

            dgvOrders.DataSource = dataTable
            dgvOrders.ReadOnly = True
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvOrders.MultiSelect = False
            dgvOrders.AllowUserToAddRows = False
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            lblRecordCount.Text = "Total Orders: " & dgvOrders.Rows.Count.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadOrdersData()
        MessageBox.Show("Orders data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class