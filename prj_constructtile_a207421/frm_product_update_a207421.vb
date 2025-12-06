Public Class frm_product_update_a207421

    Private currentProductID As String
    Private selectedImagePath As String = Nothing
    Private imageChanged As Boolean = False

    Public Sub New(productID As String)
        InitializeComponent()
        currentProductID = productID
    End Sub

    Private Sub frm_product_update_a207421_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbType.Items.AddRange(New String() {"Floor", "Wall", "Roof"})

        LoadProductData()

        LoadProductImage()
    End Sub

    Private Sub LoadProductImage()
        Try
            If picProduct.Image IsNot Nothing Then
                picProduct.Image.Dispose()
                picProduct.Image = Nothing
            End If

            Dim picturesPath As String = System.IO.Path.Combine(Application.StartupPath, "pictures")
            Dim imagePath As String = System.IO.Path.Combine(picturesPath, currentProductID & ".jpg")
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
                imageChanged = True
            Catch ex As Exception
                MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadProductData()
        Try
            Dim query As String = "SELECT * FROM TBL_PRODUCTS_A207421 WHERE FLD_PRODUCT_ID = '" & currentProductID.Replace("'", "''") & "'"
            Dim dataTable As DataTable = ExecuteQuery(query)

            If dataTable.Rows.Count > 0 Then
                Dim row As DataRow = dataTable.Rows(0)

                txtProductID.Text = row("FLD_PRODUCT_ID").ToString()
                txtProductName.Text = row("FLD_PRODUCT_NAME").ToString()
                txtPrice.Text = row("FLD_PRICE").ToString()
                txtBrand.Text = row("FLD_BRAND").ToString()
                cmbType.SelectedItem = row("FLD_TYPE").ToString()
                txtMaterial.Text = row("FLD_MATERIAL").ToString()
                txtSize.Text = row("FLD_SIZE").ToString()
                txtQuantity.Text = row("FLD_QUANTITY").ToString()

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

            Dim query As String = "UPDATE TBL_PRODUCTS_A207421 SET " &
                                  "FLD_PRODUCT_NAME = '" & txtProductName.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_PRICE = " & txtPrice.Text.Trim() & ", " &
                                  "FLD_BRAND = '" & txtBrand.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_TYPE = '" & cmbType.SelectedItem.ToString() & "', " &
                                  "FLD_MATERIAL = '" & txtMaterial.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_SIZE = '" & txtSize.Text.Trim().Replace("'", "''") & "', " &
                                  "FLD_QUANTITY = " & txtQuantity.Text.Trim() & " " &
                                  "WHERE FLD_PRODUCT_ID = '" & currentProductID.Replace("'", "''") & "'"

            If ExecuteNonQuery(query) Then
                If imageChanged AndAlso Not String.IsNullOrEmpty(selectedImagePath) AndAlso picProduct.Image IsNot Nothing Then
                    Try
                        Dim picturesPath As String = System.IO.Path.Combine(Application.StartupPath, "pictures")
                        If Not System.IO.Directory.Exists(picturesPath) Then
                            System.IO.Directory.CreateDirectory(picturesPath)
                        End If

                        Dim destinationPath As String = System.IO.Path.Combine(picturesPath, currentProductID & ".jpg")

                        If System.IO.File.Exists(destinationPath) Then
                            System.IO.File.Delete(destinationPath)
                        End If

                        picProduct.Image.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Catch imgEx As Exception
                        MessageBox.Show("Product updated but image save failed: " & imgEx.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If

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
