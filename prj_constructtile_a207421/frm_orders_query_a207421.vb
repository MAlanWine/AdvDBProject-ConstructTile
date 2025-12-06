Public Class frm_orders_query_a207421

    Private Sub frm_orders_query_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrders()
    End Sub

    Private Sub LoadOrders()
        Try
            Dim query As String = "SELECT O.FLD_ORDER_ID AS [Order ID], " &
                                  "C.FLD_CUSTOMER_NAME AS [Customer Name], " &
                                  "S.FLD_STAFF_NAME AS [Staff Name], " &
                                  "O.FLD_ORDER_DATE AS [Order Date], " &
                                  "O.FLD_TOTAL_AMOUNT AS [Total Amount (RM)] " &
                                  "FROM (TBL_ORDERS_A207421 AS O " &
                                  "INNER JOIN TBL_CUSTOMERS_A207421 AS C ON O.FLD_CUSTOMER_ID = C.FLD_CUSTOMER_ID) " &
                                  "INNER JOIN TBL_STAFF_A207421 AS S ON O.FLD_STAFF_ID = S.FLD_STAFF_ID " &
                                  "ORDER BY O.FLD_ORDER_DATE DESC"
            Dim dt As DataTable = ExecuteQuery(query)

            dgvOrders.DataSource = dt
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            lblRecordCount.Text = $"Total Orders: {dgvOrders.Rows.Count}"
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewOrder_Click(sender As Object, e As EventArgs) Handles btnViewOrder.Click
        Try
            If dgvOrders.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select an order first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim orderId As String = dgvOrders.SelectedRows(0).Cells("Order ID").Value.ToString()

            Dim orderQuery As String = "SELECT O.FLD_ORDER_ID, O.FLD_ORDER_DATE, O.FLD_TOTAL_AMOUNT, " &
                                       "C.FLD_CUSTOMER_NAME, C.FLD_EMAIL AS CUST_EMAIL, C.FLD_PHONE AS CUST_PHONE, C.FLD_ADDRESS, " &
                                       "S.FLD_STAFF_NAME, S.FLD_POSITION " &
                                       "FROM (TBL_ORDERS_A207421 AS O " &
                                       "INNER JOIN TBL_CUSTOMERS_A207421 AS C ON O.FLD_CUSTOMER_ID = C.FLD_CUSTOMER_ID) " &
                                       "INNER JOIN TBL_STAFF_A207421 AS S ON O.FLD_STAFF_ID = S.FLD_STAFF_ID " &
                                       $"WHERE O.FLD_ORDER_ID = '{orderId}'"
            Dim orderDt As DataTable = ExecuteQuery(orderQuery)

            If orderDt.Rows.Count = 0 Then
                MessageBox.Show("Order not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim orderRow As DataRow = orderDt.Rows(0)

            Dim detailsQuery As String = "SELECT P.FLD_PRODUCT_NAME AS [Product Name], " &
                                         "OD.FLD_QUANTITY AS [Quantity], " &
                                         "P.FLD_PRICE AS [Price (RM)], " &
                                         "OD.FLD_SUBTOTAL AS [Subtotal (RM)] " &
                                         "FROM TBL_ORDERDETAILS_A207421 AS OD " &
                                         "INNER JOIN TBL_PRODUCTS_A207421 AS P ON OD.FLD_PRODUCT_ID = P.FLD_PRODUCT_ID " &
                                         $"WHERE OD.FLD_ORDER_ID = '{orderId}'"
            Dim detailsDt As DataTable = ExecuteQuery(detailsQuery)

            Dim orderInfo As String = "========== ORDER DETAILS ==========" & vbCrLf & vbCrLf
            orderInfo &= $"Order ID: {orderRow("FLD_ORDER_ID")}" & vbCrLf
            orderInfo &= $"Order Date: {Convert.ToDateTime(orderRow("FLD_ORDER_DATE")):yyyy-MM-dd HH:mm:ss}" & vbCrLf & vbCrLf

            orderInfo &= "--- CUSTOMER INFORMATION ---" & vbCrLf
            orderInfo &= $"Name: {orderRow("FLD_CUSTOMER_NAME")}" & vbCrLf
            orderInfo &= $"Email: {orderRow("CUST_EMAIL")}" & vbCrLf
            orderInfo &= $"Phone: {orderRow("CUST_PHONE")}" & vbCrLf
            orderInfo &= $"Address: {orderRow("FLD_ADDRESS")}" & vbCrLf & vbCrLf

            orderInfo &= "--- STAFF INFORMATION ---" & vbCrLf
            orderInfo &= $"Name: {orderRow("FLD_STAFF_NAME")}" & vbCrLf
            orderInfo &= $"Position: {orderRow("FLD_POSITION")}" & vbCrLf & vbCrLf

            orderInfo &= "--- ORDER ITEMS ---" & vbCrLf
            For Each row As DataRow In detailsDt.Rows
                orderInfo &= $"• {row("Product Name")}" & vbCrLf
                orderInfo &= $"  Quantity: {row("Quantity")} | Price: RM {Convert.ToDecimal(row("Price (RM)")):N2} | Subtotal: RM {Convert.ToDecimal(row("Subtotal (RM)")):N2}" & vbCrLf
            Next
            orderInfo &= vbCrLf

            orderInfo &= $"TOTAL AMOUNT: RM {Convert.ToDecimal(orderRow("FLD_TOTAL_AMOUNT")):N2}" & vbCrLf
            orderInfo &= "===================================="

            MessageBox.Show(orderInfo, "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error viewing order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        Try
            If dgvOrders.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select an order first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim orderId As String = dgvOrders.SelectedRows(0).Cells("Order ID").Value.ToString()
            Dim customerName As String = dgvOrders.SelectedRows(0).Cells("Customer Name").Value.ToString()
            Dim totalAmount As Decimal = Convert.ToDecimal(dgvOrders.SelectedRows(0).Cells("Total Amount (RM)").Value)

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this order?" & vbCrLf & vbCrLf &
                                                          $"Order ID: {orderId}" & vbCrLf &
                                                          $"Customer: {customerName}" & vbCrLf &
                                                          $"Total Amount: RM {totalAmount:N2}" & vbCrLf & vbCrLf &
                                                          "This action cannot be undone!",
                                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim detailsDeleteQuery As String = $"DELETE FROM TBL_ORDERDETAILS_A207421 WHERE FLD_ORDER_ID = '{orderId}'"
                ExecuteNonQuery(detailsDeleteQuery)

                Dim orderDeleteQuery As String = $"DELETE FROM TBL_ORDERS_A207421 WHERE FLD_ORDER_ID = '{orderId}'"
                If ExecuteNonQuery(orderDeleteQuery) Then
                    MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadOrders()
                Else
                    MessageBox.Show("Failed to delete order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadOrders()
        MessageBox.Show("Orders refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class