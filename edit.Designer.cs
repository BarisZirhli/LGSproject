namespace LGS_Tracking_Application
{
    partial class edit
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            button3 = new Button();
            panel3 = new Panel();
            textBox3 = new TextBox();
            label6 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            listView1 = new ListView();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(0, 170);
            label1.Name = "label1";
            label1.Size = new Size(370, 32);
            label1.TabIndex = 0;
            label1.Text = "Silinecek Ögrenci Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.Location = new Point(241, 34);
            label2.Name = "label2";
            label2.Size = new Size(251, 32);
            label2.TabIndex = 1;
            label2.Text = "Ögrenci Silme Ekranı\r\n";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            textBox1.Location = new Point(405, 167);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 39);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button1.Location = new Point(268, 291);
            button1.Name = "button1";
            button1.Size = new Size(159, 72);
            button1.TabIndex = 3;
            button1.Text = "Sil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(28, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(711, 401);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(listView1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(774, 26);
            panel2.Name = "panel2";
            panel2.Size = new Size(724, 401);
            panel2.TabIndex = 5;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonHighlight;
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button3.Location = new Point(329, 303);
            button3.Name = "button3";
            button3.Size = new Size(159, 72);
            button3.TabIndex = 4;
            button3.Text = "Ara";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(299, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(380, 186);
            panel3.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox3.Location = new Point(162, 125);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(187, 29);
            textBox3.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(30, 125);
            label6.Name = "label6";
            label6.Size = new Size(57, 21);
            label6.TabIndex = 10;
            label6.Text = "Şifresi";
            label6.Click += label6_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox2.Location = new Point(162, 34);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(187, 29);
            textBox2.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(30, 77);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 9;
            label5.Text = "Sınıfı";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox4.Location = new Point(162, 77);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(187, 29);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(30, 34);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 8;
            label4.Text = "Kullanıcı Adı";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button2.Location = new Point(520, 303);
            button2.Name = "button2";
            button2.Size = new Size(159, 72);
            button2.TabIndex = 4;
            button2.Text = "Güncelle";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Info;
            listView1.Location = new Point(44, 81);
            listView1.Name = "listView1";
            listView1.Size = new Size(218, 294);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(201, 22);
            label3.Name = "label3";
            label3.Size = new Size(317, 32);
            label3.TabIndex = 0;
            label3.Text = "Ögrenci Düzenleme Ekranı";
            // 
            // edit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1529, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "edit";
            Text = "edit";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private ListView listView1;
        private Label label3;
        private Button button2;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Panel panel3;
        private Button button3;
    }
}