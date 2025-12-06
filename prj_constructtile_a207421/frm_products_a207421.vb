Public Class frm_products_a207421

    Private Sub frm_products_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductsData()
    End Sub

    Private Sub LoadProductsData()
        Try
            Dim dataTable As DataTable = ExecuteQuery("SELECT * FROM TBL_PRODUCTS_A207421")

            dataTable.Columns("FLD_PRODUCT_ID").ColumnName = "Product ID"
            dataTable.Columns("FLD_PRODUCT_NAME").ColumnName = "Product Name"
            dataTable.Columns("FLD_PRICE").ColumnName = "Price (RM)"
            dataTable.Columns("FLD_BRAND").ColumnName = "Brand"
            dataTable.Columns("FLD_TYPE").ColumnName = "Type"
            dataTable.Columns("FLD_MATERIAL").ColumnName = "Material"
            dataTable.Columns("FLD_SIZE").ColumnName = "Size"
            dataTable.Columns("FLD_QUANTITY").ColumnName = "Quantity"

            dgvProducts.DataSource = dataTable
            dgvProducts.ReadOnly = True
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvProducts.MultiSelect = False
            dgvProducts.AllowUserToAddRows = False
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            lblRecordCount.Text = "Total Products: " & dgvProducts.Rows.Count.ToString()
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadProductsData()
        MessageBox.Show("Products data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim insertForm As New frm_product_insert_a207421()
        insertForm.ShowDialog()
        LoadProductsData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim productId As String = dgvProducts.SelectedRows(0).Cells("Product ID").Value.ToString()
            Dim updateForm As New frm_product_update_a207421(productId)
            updateForm.ShowDialog()
            LoadProductsData()
        Else
            MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                LoadProductsData()
            Else
                Dim searchText As String = txtSearch.Text.Trim()
                Dim query As String = "SELECT * FROM TBL_PRODUCTS_A207421 WHERE " &
                    "FLD_PRODUCT_NAME LIKE '%" & searchText & "%' OR " &
                    "FLD_BRAND LIKE '%" & searchText & "%' OR " &
                    "FLD_TYPE LIKE '%" & searchText & "%' OR " &
                    "FLD_MATERIAL LIKE '%" & searchText & "%'"
                Dim dataTable As DataTable = ExecuteQuery(query)

                dataTable.Columns("FLD_PRODUCT_ID").ColumnName = "Product ID"
                dataTable.Columns("FLD_PRODUCT_NAME").ColumnName = "Product Name"
                dataTable.Columns("FLD_PRICE").ColumnName = "Price (RM)"
                dataTable.Columns("FLD_BRAND").ColumnName = "Brand"
                dataTable.Columns("FLD_TYPE").ColumnName = "Type"
                dataTable.Columns("FLD_MATERIAL").ColumnName = "Material"
                dataTable.Columns("FLD_SIZE").ColumnName = "Size"
                dataTable.Columns("FLD_QUANTITY").ColumnName = "Quantity"

                dgvProducts.DataSource = dataTable
                lblRecordCount.Text = "Total Products: " & dgvProducts.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim productId As String = dgvProducts.SelectedRows(0).Cells("Product ID").Value.ToString()
            LoadProductImage(productId)
        End If
    End Sub

    Private Sub LoadProductImage(productId As String)
        Try
            If picProduct.Image IsNot Nothing Then
                picProduct.Image.Dispose()
                picProduct.Image = Nothing
            End If

            Dim picturesPath As String = System.IO.Path.Combine(Application.StartupPath, "pictures")
            Dim imagePath As String = System.IO.Path.Combine(picturesPath, productId & ".jpg")
            Dim noImagePath As String = System.IO.Path.Combine(picturesPath, "no_img.jpg")

            Dim pathToLoad As String = Nothing
            If System.IO.File.Exists(imagePath) Then
                pathToLoad = imagePath
            ElseIf System.IO.File.Exists(noImagePath) Then
                pathToLoad = noImagePath
            End If

            If pathToLoad IsNot Nothing Then
                Using fs As New System.IO.FileStream(pathToLoad, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    Using tempImage As Image = Image.FromStream(fs)
                        picProduct.Image = New Bitmap(tempImage)
                    End Using
                End Using
            End If
        Catch ex As Exception
            picProduct.Image = Nothing
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim productId As String = dgvProducts.SelectedRows(0).Cells("Product ID").Value.ToString()
            Dim productName As String = dgvProducts.SelectedRows(0).Cells("Product Name").Value.ToString()

            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to delete the product '" & productName & "' (ID: " & productId & ")?" & vbCrLf & vbCrLf &
                "This action cannot be undone and will also delete the associated image file.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Try
                    Dim query As String = "DELETE FROM TBL_PRODUCTS_A207421 WHERE FLD_PRODUCT_ID = '" & productId.Replace("'", "''") & "'"

                    If ExecuteNonQuery(query) Then
                        If picProduct.Image IsNot Nothing Then
                            picProduct.Image.Dispose()
                            picProduct.Image = Nothing
                        End If

                        Dim picturesPath As String = System.IO.Path.Combine(Application.StartupPath, "pictures")
                        Dim imagePath As String = System.IO.Path.Combine(picturesPath, productId & ".jpg")

                        If System.IO.File.Exists(imagePath) Then
                            System.IO.File.Delete(imagePath)
                        End If

                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadProductsData()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class
