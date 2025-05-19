namespace LGS_Tracking_Application
{
    partial class admin
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
            panel1 = new Panel();
            txtTGID = new TextBox();
            label7 = new Label();
            txtUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtGrade = new TextBox();
            txtLastName = new TextBox();
            txtName = new TextBox();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ExamFile = new OpenFileDialog();
            button4 = new Button();
            button5 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(txtTGID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtGrade);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(txtName);
            panel1.Location = new Point(26, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 313);
            panel1.TabIndex = 0;
            // 
            // txtTGID
            // 
            txtTGID.Location = new Point(152, 261);
            txtTGID.Name = "txtTGID";
            txtTGID.Size = new Size(100, 23);
            txtTGID.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label7.Location = new Point(32, 261);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 10;
            label7.Text = "TC Kimlik No";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(152, 211);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(31, 210);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 8;
            label5.Text = "Kullanıcı Adı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(31, 168);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 7;
            label4.Text = "Şifresi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(31, 124);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 6;
            label3.Text = "Sınıfı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(32, 88);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 5;
            label2.Text = "Soyadı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(32, 45);
            label1.Name = "label1";
            label1.Size = new Size(29, 20);
            label1.TabIndex = 4;
            label1.Text = "Ad";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(152, 172);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(152, 125);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(100, 23);
            txtGrade.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(152, 81);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(152, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(325, 24);
            label6.Name = "label6";
            label6.Size = new Size(585, 40);
            label6.TabIndex = 1;
            label6.Text = "Ögrenci Ekleme/Silme/Güncelleme Paneli";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(415, 107);
            button1.Name = "button1";
            button1.Size = new Size(159, 65);
            button1.TabIndex = 2;
            button1.Text = "Ögrenci Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(415, 221);
            button2.Name = "button2";
            button2.Size = new Size(159, 65);
            button2.TabIndex = 3;
            button2.Text = "Ögrenci Güncelle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.Location = new Point(415, 332);
            button3.Name = "button3";
            button3.Size = new Size(159, 65);
            button3.TabIndex = 4;
            button3.Text = "Ögrenci Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ExamFile
            // 
            ExamFile.FileName = "openFileDialog1";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button4.Location = new Point(697, 158);
            button4.Name = "button4";
            button4.Size = new Size(186, 76);
            button4.TabIndex = 5;
            button4.Text = "Sınav Sonuçları Yükle";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.Location = new Point(680, 299);
            button5.Name = "button5";
            button5.Size = new Size(213, 76);
            button5.TabIndex = 6;
            button5.Text = "Ögrenci Sonuçları Getir";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1149, 471);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(panel1);
            Name = "admin";
            Text = "admin";
            Load += admin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtGrade;
        private TextBox txtLastName;
        private TextBox txtName;
        private TextBox txtUsername;
        private Label label6;
        private Button button1;
        private Button button2;
        private Button button3;
        private OpenFileDialog ExamFile;
        private Button button4;
        private TextBox txtTGID;
        private Label label7;
        private Button button5;
    }
}