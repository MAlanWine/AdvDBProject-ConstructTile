Public Class frm_mainmenu_a207421

    Private Sub frm_mainmenu_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not InitializeDatabase() Then
            MessageBox.Show("Warning: Database connection could not be established. Please ensure DB_CONSTRUCTTILE_A207421.accdb exists in the bin\Debug folder.", "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Set background image for the entire form
        Try
            Dim backgroundPath As String = System.IO.Path.Combine(Application.StartupPath, "background.png")
            If System.IO.File.Exists(backgroundPath) Then
                Me.BackgroundImage = Image.FromFile(backgroundPath)
                Me.BackgroundImageLayout = ImageLayout.Stretch
            End If
        Catch ex As Exception
            ' If background image fails to load, just continue with the default background color
        End Try

        ' Make panels transparent to show the background
        panelButtons.BackColor = Color.Transparent
        panelHeader.BackColor = Color.FromArgb(128, 179, 229, 252) ' 50% opacity light blue
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
