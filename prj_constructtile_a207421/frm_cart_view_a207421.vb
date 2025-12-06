Public Class frm_cart_view_a207421

    Private cartItems As List(Of frm_orders_purchase_a207421.CartItem)

    Public Sub New(items As List(Of frm_orders_purchase_a207421.CartItem))
        InitializeComponent()
        cartItems = items
    End Sub

    Private Sub frm_cart_view_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyButtonTheme(btnClose)
        ApplyButtonTheme(btnDeleteOrder)

        ApplyDataGridViewTheme(dgvCart)

        LoadCartItems()

        CalculateTotal()
    End Sub

    Private Sub ApplyDataGridViewTheme(dgv As DataGridView)
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(&H1, &H57, &H9B)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.ColumnHeadersHeight = 35

        dgv.RowsDefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.RowsDefaultCellStyle.ForeColor = Color.Black
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(&HE1, &HF5, &HFE)

        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(&H81, &HD4, &HFA)
        dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(&H1, &H57, &H9B)

        dgv.GridColor = Color.FromArgb(&HB3, &HE5, &HFC)
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

        dgv.RowTemplate.Height = 30
    End Sub

    Private Sub LoadCartItems()
        Dim dt As New DataTable()
        dt.Columns.Add("Product ID", GetType(String))
        dt.Columns.Add("Product Name", GetType(String))
        dt.Columns.Add("Price (RM)", GetType(Decimal))
        dt.Columns.Add("Quantity", GetType(Integer))
        dt.Columns.Add("Subtotal (RM)", GetType(Decimal))

        For Each item As frm_orders_purchase_a207421.CartItem In cartItems
            dt.Rows.Add(item.ProductID, item.ProductName, item.Price, item.Quantity, item.Subtotal)
        Next

        dgvCart.DataSource = dt

        If dgvCart.Columns.Contains("Price (RM)") Then
            dgvCart.Columns("Price (RM)").DefaultCellStyle.Format = "N2"
            dgvCart.Columns("Price (RM)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If dgvCart.Columns.Contains("Subtotal (RM)") Then
            dgvCart.Columns("Subtotal (RM)").DefaultCellStyle.Format = "N2"
            dgvCart.Columns("Subtotal (RM)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If dgvCart.Columns.Contains("Quantity") Then
            dgvCart.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub CalculateTotal()
        Dim total As Decimal = cartItems.Sum(Function(item) item.Subtotal)
        lblTotalAmount.Text = "RM " & total.ToString("N2")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvCart.SelectedRows(0)
        Dim productID As String = selectedRow.Cells("Product ID").Value.ToString()
        Dim productName As String = selectedRow.Cells("Product Name").Value.ToString()

        Dim confirmMsg As String = "Are you sure you want to delete this item from your cart?" & vbCrLf & vbCrLf &
                                   "Product: " & productName & vbCrLf &
                                   "Product ID: " & productID

        Dim result As DialogResult = MessageBox.Show(confirmMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        Dim itemToRemove As frm_orders_purchase_a207421.CartItem = cartItems.FirstOrDefault(Function(item) item.ProductID = productID)

        If itemToRemove IsNot Nothing Then
            cartItems.Remove(itemToRemove)

            LoadCartItems()

            CalculateTotal()

            MessageBox.Show("Item removed from cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If cartItems.Count = 0 Then
                MessageBox.Show("Your cart is now empty. Closing cart view.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Else
            MessageBox.Show("Error: Item not found in cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
