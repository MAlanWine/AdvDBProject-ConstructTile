<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_product_update_a207421
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblProductID = New System.Windows.Forms.Label()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.txtMaterial = New System.Windows.Forms.TextBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(560, 40)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Update Product"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProductID
        '
        Me.lblProductID.AutoSize = True
        Me.lblProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductID.Location = New System.Drawing.Point(50, 70)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(91, 17)
        Me.lblProductID.TabIndex = 1
        Me.lblProductID.Text = "Product ID:"
        '
        'txtProductID
        '
        Me.txtProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductID.Location = New System.Drawing.Point(180, 67)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(350, 23)
        Me.txtProductID.TabIndex = 2
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(50, 110)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(109, 17)
        Me.lblProductName.TabIndex = 3
        Me.lblProductName.Text = "Product Name:"
        '
        'txtProductName
        '
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(180, 107)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(350, 23)
        Me.txtProductName.TabIndex = 4
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(50, 150)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(78, 17)
        Me.lblPrice.TabIndex = 5
        Me.lblPrice.Text = "Price (RM):"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(180, 147)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(350, 23)
        Me.txtPrice.TabIndex = 6
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.Location = New System.Drawing.Point(50, 190)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(51, 17)
        Me.lblBrand.TabIndex = 7
        Me.lblBrand.Text = "Brand:"
        '
        'txtBrand
        '
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(180, 187)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(350, 23)
        Me.txtBrand.TabIndex = 8
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(50, 230)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(44, 17)
        Me.lblType.TabIndex = 9
        Me.lblType.Text = "Type:"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(180, 227)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(350, 24)
        Me.cmbType.TabIndex = 10
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.Location = New System.Drawing.Point(50, 270)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(65, 17)
        Me.lblMaterial.TabIndex = 11
        Me.lblMaterial.Text = "Material:"
        '
        'txtMaterial
        '
        Me.txtMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterial.Location = New System.Drawing.Point(180, 267)
        Me.txtMaterial.Name = "txtMaterial"
        Me.txtMaterial.Size = New System.Drawing.Size(350, 23)
        Me.txtMaterial.TabIndex = 12
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(50, 310)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(40, 17)
        Me.lblSize.TabIndex = 13
        Me.lblSize.Text = "Size:"
        '
        'txtSize
        '
        Me.txtSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(180, 307)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(350, 23)
        Me.txtSize.TabIndex = 14
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(50, 350)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(68, 17)
        Me.lblQuantity.TabIndex = 15
        Me.lblQuantity.Text = "Quantity:"
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(180, 347)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(350, 23)
        Me.txtQuantity.TabIndex = 16
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(100, Byte), CType(180, Byte), CType(230, Byte))
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(80, 400)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(130, 45)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(173, Byte), CType(216, Byte), CType(230, Byte))
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(230, 400)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(130, 45)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(173, Byte), CType(216, Byte), CType(230, Byte))
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(380, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 45)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frm_product_update_a207421
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(242, Byte), CType(255, Byte))
        Me.ClientSize = New System.Drawing.Size(584, 471)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.txtMaterial)
        Me.Controls.Add(Me.lblMaterial)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.txtProductID)
        Me.Controls.Add(Me.lblProductID)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_product_update_a207421"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Product - ConstructTile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblProductID As Label
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents lblProductName As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblBrand As Label
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents lblType As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents lblMaterial As Label
    Friend WithEvents txtMaterial As TextBox
    Friend WithEvents lblSize As Label
    Friend WithEvents txtSize As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
End Class
