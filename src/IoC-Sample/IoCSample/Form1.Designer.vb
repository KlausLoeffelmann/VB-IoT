<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ColorTextBox4 = New WinFormsApp.ColorTextBox()
        Me.ColorTextBox3 = New WinFormsApp.ColorTextBox()
        Me.ColorTextBox2 = New WinFormsApp.ColorTextBox()
        Me.ColorTextBox1 = New WinFormsApp.ColorTextBox()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(484, 51)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(252, 228)
        Me.ListBox1.TabIndex = 4
        '
        'ColorTextBox4
        '
        Me.ColorTextBox4.FocusColor = System.Drawing.Color.Yellow
        Me.ColorTextBox4.Location = New System.Drawing.Point(89, 138)
        Me.ColorTextBox4.Name = "ColorTextBox4"
        Me.ColorTextBox4.Size = New System.Drawing.Size(288, 22)
        Me.ColorTextBox4.TabIndex = 3
        '
        'ColorTextBox3
        '
        Me.ColorTextBox3.FocusColor = System.Drawing.Color.Yellow
        Me.ColorTextBox3.Location = New System.Drawing.Point(89, 110)
        Me.ColorTextBox3.Name = "ColorTextBox3"
        Me.ColorTextBox3.Size = New System.Drawing.Size(288, 22)
        Me.ColorTextBox3.TabIndex = 2
        '
        'ColorTextBox2
        '
        Me.ColorTextBox2.FocusColor = System.Drawing.Color.Yellow
        Me.ColorTextBox2.Location = New System.Drawing.Point(89, 82)
        Me.ColorTextBox2.Name = "ColorTextBox2"
        Me.ColorTextBox2.Size = New System.Drawing.Size(288, 22)
        Me.ColorTextBox2.TabIndex = 1
        '
        'ColorTextBox1
        '
        Me.ColorTextBox1.FocusColor = System.Drawing.Color.Yellow
        Me.ColorTextBox1.Location = New System.Drawing.Point(89, 54)
        Me.ColorTextBox1.Name = "ColorTextBox1"
        Me.ColorTextBox1.Size = New System.Drawing.Size(288, 22)
        Me.ColorTextBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ColorTextBox4)
        Me.Controls.Add(Me.ColorTextBox3)
        Me.Controls.Add(Me.ColorTextBox2)
        Me.Controls.Add(Me.ColorTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColorTextBox1 As ColorTextBox
    Friend WithEvents ColorTextBox2 As ColorTextBox
    Friend WithEvents ColorTextBox3 As ColorTextBox
    Friend WithEvents ColorTextBox4 As ColorTextBox
    Friend WithEvents ListBox1 As ListBox
End Class
