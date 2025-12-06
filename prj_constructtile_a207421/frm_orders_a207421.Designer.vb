<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_orders_a207421
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnQueryOrders = New System.Windows.Forms.Button()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.panelHeader.SuspendLayout()
        Me.panelFooter.SuspendLayout()
        Me.SuspendLayout()
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(550, 70)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Orders Management"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(220, 10)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 35)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(550, 70)
        Me.panelHeader.TabIndex = 1
        Me.panelFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.panelFooter.Controls.Add(Me.btnClose)
        Me.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelFooter.Location = New System.Drawing.Point(0, 320)
        Me.panelFooter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Size = New System.Drawing.Size(550, 55)
        Me.panelFooter.TabIndex = 6
        Me.btnPurchase.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.btnPurchase.FlatAppearance.BorderSize = 2
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchase.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnPurchase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.btnPurchase.Location = New System.Drawing.Point(100, 130)
        Me.btnPurchase.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(350, 60)
        Me.btnPurchase.TabIndex = 7
        Me.btnPurchase.Text = "Purchase Products"
        Me.btnPurchase.UseVisualStyleBackColor = False
        Me.btnQueryOrders.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnQueryOrders.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQueryOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.btnQueryOrders.FlatAppearance.BorderSize = 2
        Me.btnQueryOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQueryOrders.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnQueryOrders.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.btnQueryOrders.Location = New System.Drawing.Point(100, 210)
        Me.btnQueryOrders.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnQueryOrders.Name = "btnQueryOrders"
        Me.btnQueryOrders.Size = New System.Drawing.Size(350, 60)
        Me.btnQueryOrders.TabIndex = 8
        Me.btnQueryOrders.Text = "Query Orders"
        Me.btnQueryOrders.UseVisualStyleBackColor = False
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(100, 85)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(350, 25)
        Me.lblSubtitle.TabIndex = 9
        Me.lblSubtitle.Text = "Please select an option:"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(550, 375)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.btnQueryOrders)
        Me.Controls.Add(Me.btnPurchase)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_orders_a207421"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConstructTile - Orders Menu"
        Me.panelHeader.ResumeLayout(False)
        Me.panelFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelFooter As Panel
    Friend WithEvents btnPurchase As Button
    Friend WithEvents btnQueryOrders As Button
    Friend WithEvents lblSubtitle As Label
End Class
