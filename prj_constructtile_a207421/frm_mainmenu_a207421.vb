Public Class frm_mainmenu_a207421

    Private Sub frm_mainmenu_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize database connection test
        If Not InitializeDatabase() Then
            MessageBox.Show("Warning: Database connection could not be established. Please ensure DB_CONSTRUCTTILE_A207421.accdb exists in the bin\Debug folder.", "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Dim productsForm As New frm_products_a207421()
        productsForm.ShowDialog()
    End Sub

    Private Sub btnStaff_Click(sender As Object, e As EventArgs) Handles btnStaff.Click
        Dim staffForm As New frm_staff_a207421()
        staffForm.ShowDialog()
    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Dim customersForm As New frm_customers_a207421()
        customersForm.ShowDialog()
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Dim ordersForm As New frm_orders_a207421()
        ordersForm.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit ConstructTile", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
