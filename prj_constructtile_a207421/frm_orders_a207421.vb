Public Class frm_orders_a207421

    Private Sub frm_orders_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        Dim purchaseForm As New frm_orders_purchase_a207421()
        purchaseForm.ShowDialog()
    End Sub

    Private Sub btnQueryOrders_Click(sender As Object, e As EventArgs) Handles btnQueryOrders.Click
        Dim queryForm As New frm_orders_query_a207421()
        queryForm.ShowDialog()
    End Sub

End Class
