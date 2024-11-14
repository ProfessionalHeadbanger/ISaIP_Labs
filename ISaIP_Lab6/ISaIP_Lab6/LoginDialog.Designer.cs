namespace ISaIP_Lab6
{
    partial class LoginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginButton = new Button();
            cancelButton = new Button();
            idLabel = new Label();
            userIdTextBox = new TextBox();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.DialogResult = DialogResult.OK;
            loginButton.Location = new Point(139, 112);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(30, 112);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(67, 26);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(48, 15);
            idLabel.TabIndex = 2;
            idLabel.Text = "Your ID:";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(67, 44);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(100, 23);
            userIdTextBox.TabIndex = 3;
            // 
            // LoginDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 147);
            Controls.Add(userIdTextBox);
            Controls.Add(idLabel);
            Controls.Add(cancelButton);
            Controls.Add(loginButton);
            Name = "LoginDialog";
            Text = "LoginDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private Button cancelButton;
        private Label idLabel;
        private TextBox userIdTextBox;
    }
}