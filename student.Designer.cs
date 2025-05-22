
namespace LGS_Tracking_Application
{
    partial class student
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            upload_btn = new Button();
            tarih_lbl = new Label();
            panel1 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button3 = new Button();
            txtExam = new TextBox();
            button2 = new Button();
            button1 = new Button();
            listView1 = new ListView();
            label2 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            label6 = new Label();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            label3 = new Label();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            textBox2 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // upload_btn
            // 
            upload_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            upload_btn.Location = new Point(386, 359);
            upload_btn.Name = "upload_btn";
            upload_btn.Size = new Size(86, 50);
            upload_btn.TabIndex = 0;
            upload_btn.Text = "Yükle";
            upload_btn.UseVisualStyleBackColor = true;
            upload_btn.Click += upload_btn_Click;
            // 
            // tarih_lbl
            // 
            tarih_lbl.AutoSize = true;
            tarih_lbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tarih_lbl.Location = new Point(388, 13);
            tarih_lbl.Name = "tarih_lbl";
            tarih_lbl.Size = new Size(65, 25);
            tarih_lbl.TabIndex = 1;
            tarih_lbl.Text = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(chart1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(txtExam);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(upload_btn);
            panel1.Controls.Add(tarih_lbl);
            panel1.Location = new Point(12, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(1550, 555);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(916, 54);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(598, 445);
            chart1.TabIndex = 24;
            chart1.Text = "chart1";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button3.Location = new Point(497, 449);
            button3.Name = "button3";
            button3.Size = new Size(151, 50);
            button3.TabIndex = 23;
            button3.Text = "Sınav Grafigim";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtExam
            // 
            txtExam.Location = new Point(681, 467);
            txtExam.Name = "txtExam";
            txtExam.Size = new Size(100, 23);
            txtExam.TabIndex = 22;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(690, 357);
            button2.Name = "button2";
            button2.Size = new Size(208, 50);
            button2.TabIndex = 21;
            button2.Text = "Sonuçlarımı PDF Al";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(478, 357);
            button1.Name = "button1";
            button1.Size = new Size(206, 50);
            button1.TabIndex = 20;
            button1.Text = "Sonuçlarımı Getir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(405, 61);
            listView1.Name = "listView1";
            listView1.Size = new Size(470, 276);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(115, 13);
            label2.Name = "label2";
            label2.Size = new Size(169, 21);
            label2.TabIndex = 18;
            label2.Text = "Bireysel Sınav Girdisi";
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox11);
            panel2.Controls.Add(textBox12);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox9);
            panel2.Controls.Add(textBox10);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(textBox8);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(16, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 450);
            panel2.TabIndex = 17;
            panel2.Paint += panel2_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(24, 386);
            label7.Name = "label7";
            label7.Size = new Size(40, 21);
            label7.TabIndex = 28;
            label7.Text = "AİİT";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(276, 388);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(34, 23);
            textBox11.TabIndex = 27;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(150, 384);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(34, 23);
            textBox12.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(25, 326);
            label6.Name = "label6";
            label6.Size = new Size(75, 21);
            label6.TabIndex = 25;
            label6.Text = "İngilizce";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(277, 328);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(34, 23);
            textBox9.TabIndex = 24;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(151, 324);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(34, 23);
            textBox10.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(24, 272);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 22;
            label3.Text = "Din";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(276, 274);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(34, 23);
            textBox7.TabIndex = 21;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(150, 270);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(34, 23);
            textBox8.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(231, 12);
            label10.Name = "label10";
            label10.Size = new Size(103, 21);
            label10.TabIndex = 19;
            label10.Text = "Yanlış Sayısı";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.Location = new Point(99, 12);
            label9.Name = "label9";
            label9.Size = new Size(106, 21);
            label9.TabIndex = 18;
            label9.Text = "Dogru Sayısı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(24, 82);
            label5.Name = "label5";
            label5.Size = new Size(60, 21);
            label5.TabIndex = 7;
            label5.Text = "Türkçe";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(34, 23);
            textBox1.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(24, 210);
            label8.Name = "label8";
            label8.Size = new Size(37, 21);
            label8.TabIndex = 15;
            label8.Text = "Fen";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(276, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(34, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(276, 208);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(34, 23);
            textBox5.TabIndex = 14;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(150, 208);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(34, 23);
            textBox6.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(150, 146);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(34, 23);
            textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(276, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(34, 23);
            textBox3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(24, 148);
            label4.Name = "label4";
            label4.Size = new Size(93, 21);
            label4.TabIndex = 11;
            label4.Text = "Matematik";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(724, 19);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 4;
            label1.Text = "Ögrenci Ana Ekranı";
            // 
            // student
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1603, 639);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "student";
            Text = "student";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button upload_btn;
        private Label tarih_lbl;
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Panel panel2;
        private Label label5;
        private Label label8;
        private TextBox textBox2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private Label label10;
        private Label label9;
        private Label label3;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label2;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private SaveFileDialog saveFileDialog1;
        private Label label6;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label7;
        private TextBox textBox11;
        private TextBox textBox12;
        private Button button3;
        private TextBox txtExam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}