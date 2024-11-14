namespace ISaIP_Lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            loginLabel = new Label();
            loginButton = new Button();
            accessMatrixGridView = new DataGridView();
            accessContextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)accessMatrixGridView).BeginInit();
            SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(12, 9);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(43, 15);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "You're:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(12, 44);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 1;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // accessMatrixGridView
            // 
            accessMatrixGridView.AllowUserToAddRows = false;
            accessMatrixGridView.AllowUserToDeleteRows = false;
            accessMatrixGridView.AllowUserToResizeColumns = false;
            accessMatrixGridView.AllowUserToResizeRows = false;
            accessMatrixGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accessMatrixGridView.Location = new Point(142, 44);
            accessMatrixGridView.Name = "accessMatrixGridView";
            accessMatrixGridView.ReadOnly = true;
            accessMatrixGridView.Size = new Size(543, 299);
            accessMatrixGridView.TabIndex = 2;
            accessMatrixGridView.CellMouseClick += accessMatrixGridView_CellMouseClick;
            // 
            // accessContextMenu
            // 
            accessContextMenu.Name = "contextMenuStrip1";
            accessContextMenu.Size = new Size(181, 26);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(accessMatrixGridView);
            Controls.Add(loginButton);
            Controls.Add(loginLabel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)accessMatrixGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loginLabel;
        private Button loginButton;
        private DataGridView accessMatrixGridView;
        private ContextMenuStrip accessContextMenu;
    }
}
