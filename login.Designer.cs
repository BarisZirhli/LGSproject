namespace LGS_Tracking_Application
{
    partial class login
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(105, 176);
            button1.Name = "button1";
            button1.Size = new Size(185, 48);
            button1.TabIndex = 0;
            button1.Text = "Giriş yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(41, 32);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(41, 101);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 2;
            label2.Text = "Parola";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(154, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 250);
            panel1.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(167, 92);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(142, 30);
            txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(167, 24);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(142, 29);
            txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(242, 9);
            label3.Name = "label3";
            label3.Size = new Size(248, 32);
            label3.TabIndex = 5;
            label3.Text = "Kullanıcı Giriş Paneli";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(398, 58);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 6;
            label4.Text = "label4";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(705, 410);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            Name = "login";
            Text = "Login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label3;
        private Label label4;
    }
}
