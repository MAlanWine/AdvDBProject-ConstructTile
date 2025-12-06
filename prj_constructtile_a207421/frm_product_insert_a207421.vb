Public Class frm_product_insert_a207421

    Private selectedImagePath As String = Nothing

    Private Sub frm_product_insert_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbType.Items.AddRange(New String() {"Floor", "Wall", "Roof"})
        cmbType.SelectedIndex = 0
    End Sub

    Private Sub btnUploadImage_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        openFileDialog.Title = "Select Product Image"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                If picProduct.Image IsNot Nothing Then
                    picProduct.Image.Dispose()
                    picProduct.Image = Nothing
                End If

                selectedImagePath = openFileDialog.FileName
                Using fs As New System.IO.FileStream(selectedImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    Using tempImage As Image = Image.FromStream(fs)
                        picProduct.Image = New Bitmap(tempImage)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
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

            If ExecuteNonQuery(query) Then
                If Not String.IsNullOrEmpty(selectedImagePath) AndAlso picProduct.Image IsNot Nothing Then
                    Try
                        Dim picturesPath As String = System.IO.Path.Combine(Application.StartupPath, "pictures")
                        If Not System.IO.Directory.Exists(picturesPath) Then
                            System.IO.Directory.CreateDirectory(picturesPath)
                        End If

                        Dim destinationPath As String = System.IO.Path.Combine(picturesPath, txtProductID.Text.Trim() & ".jpg")

                        picProduct.Image.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Catch imgEx As Exception
                        MessageBox.Show("Product inserted but image save failed: " & imgEx.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If

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

        If picProduct.Image IsNot Nothing Then
            picProduct.Image.Dispose()
            picProduct.Image = Nothing
        End If
        selectedImagePath = Nothing
    End Sub

End Class
