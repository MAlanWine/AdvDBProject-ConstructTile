Public Class frm_product_insert_a207421

    Private Sub frm_product_insert_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate Type ComboBox
        cmbType.Items.AddRange(New String() {"Floor", "Wall", "Roof"})
        cmbType.SelectedIndex = 0
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtProductID.Text) Then
                MessageBox.Show("Product ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductID.Focus()
                Return
            End If

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

            ' Build INSERT query
            Dim query As String = "INSERT INTO TBL_PRODUCTS_A207421 " &
                                  "(FLD_PRODUCT_ID, FLD_PRODUCT_NAME, FLD_PRICE, FLD_BRAND, FLD_TYPE, FLD_MATERIAL, FLD_SIZE, FLD_QUANTITY) " &
                                  "VALUES ('" & txtProductID.Text.Trim() & "', " &
                                  "'" & txtProductName.Text.Trim().Replace("'", "''") & "', " &
                                  txtPrice.Text.Trim() & ", " &
                                  "'" & txtBrand.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & cmbType.SelectedItem.ToString() & "', " &
                                  "'" & txtMaterial.Text.Trim().Replace("'", "''") & "', " &
                                  "'" & txtSize.Text.Trim().Replace("'", "''") & "', " &
                                  txtQuantity.Text.Trim() & ")"

            ' Execute query
            If ExecuteNonQuery(query) Then
                MessageBox.Show("Product inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
                txtProductID.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error inserting product: " & ex.Message & vbCrLf & vbCrLf &
                          "This may be due to a duplicate Product ID or database constraint violation.",
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ClearFields()
        txtProductID.Clear()
        txtProductName.Clear()
        txtPrice.Clear()
        txtBrand.Clear()
        cmbType.SelectedIndex = 0
        txtMaterial.Clear()
        txtSize.Clear()
        txtQuantity.Clear()
    End Sub

End Class