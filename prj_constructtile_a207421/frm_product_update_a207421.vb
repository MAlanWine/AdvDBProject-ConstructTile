Public Class frm_product_update_a207421

    Private currentProductID As String

    ' Constructor to receive the Product ID to update
    Public Sub New(productID As String)
        InitializeComponent()
        currentProductID = productID
    End Sub

    Private Sub frm_product_update_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate Type ComboBox
        cmbType.Items.AddRange(New String() {"Floor", "Wall", "Roof"})

        ' Load the product data for the given Product ID
        LoadProductData()
    End Sub

    Private Sub LoadProductData()
        Try
            Dim query As String = "SELECT * FROM TBL_PRODUCTS_A207421 WHERE FLD_PRODUCT_ID = '" & currentProductID.Replace("'", "''") & "'"
            Dim dataTable As DataTable = ExecuteQuery(query)

            If dataTable.Rows.Count > 0 Then
                Dim row As DataRow = dataTable.Rows(0)

                ' Populate the fields with existing data
                txtProductID.Text = row("FLD_PRODUCT_ID").ToString()
                txtProductName.Text = row("FLD_PRODUCT_NAME").ToString()
                txtPrice.Text = row("FLD_PRICE").ToString()
                txtBrand.Text = row("FLD_BRAND").ToString()
                cmbType.SelectedItem = row("FLD_TYPE").ToString()
                txtMaterial.Text = row("FLD_MATERIAL").ToString()
                txtSize.Text = row("FLD_SIZE").ToString()
                txtQuantity.Text = row("FLD_QUANTITY").ToString()

                ' Disable Product ID field (Primary Key should not be editable)
                txtProductID.ReadOnly = True
                txtProductID.BackColor = Color.LightGray
            Else
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading product data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtProductName.Text) Then
                MessageBox.Show("Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtPrice.Text) OrElse Not IsNumeric(txtPrice.Text) Then
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPrice.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not IsNumeric(txtQuantity.Text) Then
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQuantity.Focus()
                Return
            End If

            ' Build UPDATE query
            Dim query As String = "UPDATE TBL_PRODUCTS_A207421 SET " &
                                  "FLD_PRODUCT_NAME = '" & txtProductName.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_PRICE = " & txtPrice.Text.Trim() & ", " &
                                  "FLD_BRAND = '" & txtBrand.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_TYPE = '" & cmbType.SelectedItem.ToString() & "', " &
                                  "FLD_MATERIAL = '" & txtMaterial.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_SIZE = '" & txtSize.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_QUANTITY = " & txtQuantity.Text.Trim() & " " &
                                  "WHERE FLD_PRODUCT_ID = '" & currentProductID.Replace("'", "''") & "'"

            ' Execute query
            If ExecuteNonQuery(query) Then
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a database constraint violation.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' For update form, clear all editable fields (not Product ID)
        txtProductName.Clear()
        txtPrice.Clear()
        txtBrand.Clear()
        cmbType.SelectedIndex = 0
        txtMaterial.Clear()
        txtSize.Clear()
        txtQuantity.Clear()
        txtProductName.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
