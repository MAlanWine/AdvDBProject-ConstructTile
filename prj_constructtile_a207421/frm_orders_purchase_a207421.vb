Imports System.Data.OleDb

Public Class frm_orders_purchase_a207421

    ' Shopping cart structure
    Public Class CartItem
        Public ProductID As String
        Public ProductName As String
        Public Price As Decimal
        Public Quantity As Integer
        Public StockAvailable As Integer
        Public Subtotal As Decimal
    End Class

    ' Shopping cart list (stored in memory)
    Private shoppingCart As New List(Of CartItem)

    Private Sub frm_orders_purchase_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply theme to buttons
        ApplyButtonTheme(btnAddToCart)
        ApplyButtonTheme(btnViewCart)
        ApplyButtonTheme(btnPlaceOrder)
        ApplyButtonTheme(btnClearCart)

        ' Apply DataGridView theme
        ApplyDataGridViewTheme(dgvProducts)

        ' Load customers and staff
        LoadCustomers()
        LoadStaff()

        ' Load products
        LoadProducts()
    End Sub

    Private Sub LoadCustomers()
        Try
            Dim query As String = "SELECT FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME FROM TBL_CUSTOMERS_A207421"
            Dim dt As DataTable = ExecuteQuery(query)

            cmbCustomer.DataSource = dt
            cmbCustomer.DisplayMember = "FLD_CUSTOMER_NAME"
            cmbCustomer.ValueMember = "FLD_CUSTOMER_ID"
        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStaff()
        Try
            Dim query As String = "SELECT FLD_STAFF_ID, FLD_STAFF_NAME FROM TBL_STAFF_A207421"
            Dim dt As DataTable = ExecuteQuery(query)

            cmbStaff.DataSource = dt
            cmbStaff.DisplayMember = "FLD_STAFF_NAME"
            cmbStaff.ValueMember = "FLD_STAFF_ID"
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProducts()
        Try
            Dim query As String = "SELECT FLD_PRODUCT_ID AS [Product ID], FLD_PRODUCT_NAME AS [Product Name], " &
                                  "FLD_PRICE AS [Price], FLD_BRAND AS [Brand], FLD_TYPE AS [Type], " &
                                  "FLD_MATERIAL AS [Material], FLD_SIZE AS [Size], FLD_QUANTITY AS [Stock] " &
                                  "FROM TBL_PRODUCTS_A207421 WHERE FLD_QUANTITY > 0 ORDER BY FLD_TYPE, FLD_PRODUCT_NAME"
            Dim dt As DataTable = ExecuteQuery(query)
            dgvProducts.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyDataGridViewTheme(dgv As DataGridView)
        ' Header style
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(&H1, &H57, &H9B)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.ColumnHeadersHeight = 35

        ' Row style
        dgv.RowsDefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.RowsDefaultCellStyle.ForeColor = Color.Black
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(&HE1, &HF5, &HFE)

        ' Selection style
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(&H81, &HD4, &HFA)
        dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(&H1, &H57, &H9B)

        ' Grid lines
        dgv.GridColor = Color.FromArgb(&HB3, &HE5, &HFC)
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

        dgv.RowTemplate.Height = 30
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get quantity from numeric control
        Dim orderQuantity As Integer = CInt(numQuantity.Value)

        ' Validate quantity
        If orderQuantity <= 0 Then
            MessageBox.Show("Quantity must be greater than 0!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get selected row
        Dim selectedRow As DataGridViewRow = dgvProducts.SelectedRows(0)

        ' Get product information
        Dim productID As String = selectedRow.Cells("Product ID").Value.ToString()
        Dim productName As String = selectedRow.Cells("Product Name").Value.ToString()
        Dim price As Decimal = CDec(selectedRow.Cells("Price").Value)
        Dim stock As Integer = CInt(selectedRow.Cells("Stock").Value)

        ' Check if quantity exceeds stock
        If orderQuantity > stock Then
            MessageBox.Show("Order quantity (" & orderQuantity & ") exceeds available stock (" & stock & ")!" & vbCrLf &
                          "Please reduce your order quantity.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if product already exists in cart
        Dim existingItem As CartItem = shoppingCart.FirstOrDefault(Function(item) item.ProductID = productID)

        If existingItem IsNot Nothing Then
            ' Check if new total quantity exceeds stock
            Dim newTotalQuantity As Integer = existingItem.Quantity + orderQuantity
            If newTotalQuantity > stock Then
                MessageBox.Show("Adding this quantity would exceed available stock!" & vbCrLf &
                              "Current cart quantity: " & existingItem.Quantity & vbCrLf &
                              "Requested quantity: " & orderQuantity & vbCrLf &
                              "Available stock: " & stock, "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Update quantity
            existingItem.Quantity = newTotalQuantity
            existingItem.Subtotal = existingItem.Price * existingItem.Quantity

            MessageBox.Show("Product quantity updated in cart!" & vbCrLf &
                          "Product: " & productName & vbCrLf &
                          "New Quantity: " & newTotalQuantity, "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Add new item to cart
            Dim newItem As New CartItem With {
                .ProductID = productID,
                .ProductName = productName,
                .Price = price,
                .Quantity = orderQuantity,
                .StockAvailable = stock,
                .Subtotal = price * orderQuantity
            }

            shoppingCart.Add(newItem)

            MessageBox.Show("Product added to cart!" & vbCrLf &
                          "Product: " & productName & vbCrLf &
                          "Quantity: " & orderQuantity & vbCrLf &
                          "Subtotal: RM " & newItem.Subtotal.ToString("N2"), "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Reset quantity to 1
        numQuantity.Value = 1
    End Sub

    Private Sub btnViewCart_Click(sender As Object, e As EventArgs) Handles btnViewCart.Click
        If shoppingCart.Count = 0 Then
            MessageBox.Show("Your cart is empty!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Open cart view form
        Dim cartForm As New frm_cart_view_a207421(shoppingCart)
        cartForm.ShowDialog()
    End Sub

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        If shoppingCart.Count = 0 Then
            MessageBox.Show("Your cart is empty! Please add items before placing an order.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbCustomer.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a customer!", "Missing Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbStaff.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a staff member!", "Missing Staff", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm order placement
        Dim totalAmount As Decimal = shoppingCart.Sum(Function(item) item.Subtotal)
        Dim confirmMsg As String = "Are you sure you want to place this order?" & vbCrLf & vbCrLf &
                                   "Customer: " & cmbCustomer.Text & vbCrLf &
                                   "Staff: " & cmbStaff.Text & vbCrLf &
                                   "Total Items: " & shoppingCart.Count & vbCrLf &
                                   "Total Amount: RM " & totalAmount.ToString("N2")

        Dim result As DialogResult = MessageBox.Show(confirmMsg, "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        ' Process order
        Try
            Dim conn As New OleDbConnection(dbConnectionString)
            conn.Open()

            ' Start transaction
            Dim transaction As OleDbTransaction = conn.BeginTransaction()

            Try
                ' Generate order ID
                Dim orderID As String = GenerateOrderID(conn, transaction)

                ' Insert order
                Dim orderQuery As String = "INSERT INTO TBL_ORDERS_A207421 (FLD_ORDER_ID, FLD_CUSTOMER_ID, FLD_STAFF_ID, FLD_ORDER_DATE, FLD_TOTAL_AMOUNT) " &
                                          "VALUES (?, ?, ?, ?, ?)"
                Dim cmdOrder As New OleDbCommand(orderQuery, conn, transaction)
                cmdOrder.Parameters.Add("?", OleDbType.VarChar).Value = orderID
                cmdOrder.Parameters.Add("?", OleDbType.VarChar).Value = cmbCustomer.SelectedValue.ToString()
                cmdOrder.Parameters.Add("?", OleDbType.VarChar).Value = cmbStaff.SelectedValue.ToString()
                cmdOrder.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now
                cmdOrder.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
                cmdOrder.ExecuteNonQuery()

                ' Insert order details and update stock
                For Each item As CartItem In shoppingCart
                    ' Insert order detail
                    Dim detailQuery As String = "INSERT INTO TBL_ORDERDETAILS_A207421 (FLD_ORDER_ID, FLD_PRODUCT_ID, FLD_QUANTITY, FLD_SUBTOTAL) " &
                                               "VALUES (?, ?, ?, ?)"
                    Dim cmdDetail As New OleDbCommand(detailQuery, conn, transaction)
                    cmdDetail.Parameters.Add("?", OleDbType.VarChar).Value = orderID
                    cmdDetail.Parameters.Add("?", OleDbType.VarChar).Value = item.ProductID
                    cmdDetail.Parameters.Add("?", OleDbType.Integer).Value = item.Quantity
                    cmdDetail.Parameters.Add("?", OleDbType.Currency).Value = item.Subtotal
                    cmdDetail.ExecuteNonQuery()

                    ' Update product stock
                    Dim updateStockQuery As String = "UPDATE TBL_PRODUCTS_A207421 SET FLD_QUANTITY = FLD_QUANTITY - ? WHERE FLD_PRODUCT_ID = ?"
                    Dim cmdUpdateStock As New OleDbCommand(updateStockQuery, conn, transaction)
                    cmdUpdateStock.Parameters.Add("?", OleDbType.Integer).Value = item.Quantity
                    cmdUpdateStock.Parameters.Add("?", OleDbType.VarChar).Value = item.ProductID
                    cmdUpdateStock.ExecuteNonQuery()
                Next

                ' Commit transaction
                transaction.Commit()

                MessageBox.Show("Order placed successfully!" & vbCrLf &
                              "Order ID: " & orderID & vbCrLf &
                              "Total Amount: RM " & totalAmount.ToString("N2"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear cart
                shoppingCart.Clear()

                ' Reload products
                LoadProducts()

            Catch ex As Exception
                ' Rollback on error
                transaction.Rollback()
                MessageBox.Show("Error placing order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateOrderID(conn As OleDbConnection, transaction As OleDbTransaction) As String
        ' Get the latest order ID
        Dim query As String = "SELECT TOP 1 FLD_ORDER_ID FROM TBL_ORDERS_A207421 ORDER BY FLD_ORDER_ID DESC"
        Dim cmd As New OleDbCommand(query, conn, transaction)
        Dim result As Object = cmd.ExecuteScalar()

        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
            Dim lastID As String = result.ToString()
            Dim numPart As Integer = Integer.Parse(lastID.Substring(1))
            Return "O" & (numPart + 1).ToString("D3")
        Else
            Return "O001"
        End If
    End Function

    Private Sub btnClearCart_Click(sender As Object, e As EventArgs) Handles btnClearCart.Click
        If shoppingCart.Count = 0 Then
            MessageBox.Show("Your cart is already empty!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Confirm clear cart
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear your cart?" & vbCrLf &
                                                     "This will remove all items (" & shoppingCart.Count & " items).",
                                                     "Confirm Clear Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            shoppingCart.Clear()
            MessageBox.Show("Cart cleared successfully!", "Cart Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class