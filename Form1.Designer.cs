namespace C__project
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            UsernameTB = new TextBox();
            PasswordTB = new TextBox();
            icon = new PictureBox();
            Login_Button = new Button();
            TB_Username = new TextBox();
            TB_Password = new TextBox();
            PictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // UsernameTB
            // 
            UsernameTB.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            UsernameTB.ForeColor = Color.Black;
            UsernameTB.Location = new Point(227, 139);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.Size = new Size(292, 25);
            UsernameTB.TabIndex = 2;
            UsernameTB.Enter += UsernameTB_Enter;
            UsernameTB.Leave += UsernameTB_Leave;
            // 
            // PasswordTB
            // 
            PasswordTB.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordTB.ForeColor = Color.Black;
            PasswordTB.Location = new Point(227, 208);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PasswordChar = '*';
            PasswordTB.Size = new Size(292, 25);
            PasswordTB.TabIndex = 3;
            PasswordTB.Enter += PasswordTB_Enter;
            PasswordTB.Leave += PasswordTB_Leave;
            // 
            // icon
            // 
            icon.BackColor = Color.White;
            icon.Image = (Image)resources.GetObject("icon.Image");
            icon.Location = new Point(501, 208);
            icon.Name = "icon";
            icon.Size = new Size(18, 25);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.TabIndex = 7;
            icon.TabStop = false;
            icon.Click += icon_Click;
            // 
            // Login_Button
            // 
            Login_Button.BackColor = Color.LightSkyBlue;
            Login_Button.FlatStyle = FlatStyle.Popup;
            Login_Button.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Login_Button.ForeColor = Color.DarkSlateGray;
            Login_Button.Image = (Image)resources.GetObject("Login_Button.Image");
            Login_Button.ImageAlign = ContentAlignment.MiddleLeft;
            Login_Button.Location = new Point(289, 293);
            Login_Button.Margin = new Padding(3, 4, 3, 4);
            Login_Button.Name = "Login_Button";
            Login_Button.Size = new Size(171, 67);
            Login_Button.TabIndex = 8;
            Login_Button.Text = "LOGIN";
            Login_Button.UseVisualStyleBackColor = false;
            Login_Button.Click += Login_Button_Click;
            Login_Button.MouseEnter += Login_Button_MouseEnter;
            Login_Button.MouseLeave += Login_Button_MouseLeave;
            // 
            // TB_Username
            // 
            TB_Username.BackColor = Color.LightGray;
            TB_Username.BorderStyle = BorderStyle.None;
            TB_Username.Enabled = false;
            TB_Username.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            TB_Username.ForeColor = Color.DarkSlateGray;
            TB_Username.Location = new Point(0, 142);
            TB_Username.Name = "TB_Username";
            TB_Username.Size = new Size(221, 20);
            TB_Username.TabIndex = 11;
            TB_Username.Text = "Username :";
            TB_Username.TextAlign = HorizontalAlignment.Right;
            // 
            // TB_Password
            // 
            TB_Password.BackColor = Color.LightGray;
            TB_Password.BorderStyle = BorderStyle.None;
            TB_Password.Enabled = false;
            TB_Password.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            TB_Password.ForeColor = Color.DarkSlateGray;
            TB_Password.Location = new Point(0, 212);
            TB_Password.Name = "TB_Password";
            TB_Password.Size = new Size(221, 20);
            TB_Password.TabIndex = 12;
            TB_Password.Text = "Password :";
            TB_Password.TextAlign = HorizontalAlignment.Right;
            // 
            // PictureBox
            // 
            PictureBox.Enabled = false;
            PictureBox.Image = (Image)resources.GetObject("PictureBox.Image");
            PictureBox.Location = new Point(331, 30);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(96, 62);
            PictureBox.TabIndex = 13;
            PictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(702, 445);
            Controls.Add(PictureBox);
            Controls.Add(TB_Password);
            Controls.Add(TB_Username);
            Controls.Add(Login_Button);
            Controls.Add(icon);
            Controls.Add(PasswordTB);
            Controls.Add(UsernameTB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += LoginForm_FormClosing;
            KeyDown += LoginForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox UsernameTB;
        private TextBox PasswordTB;
        private PictureBox icon;
        private Button Login_Button;
        private TextBox TB_Username;
        private TextBox TB_Password;
        private PictureBox PictureBox;
    }
}