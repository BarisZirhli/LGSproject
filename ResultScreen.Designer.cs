namespace LGS_Tracking_Application
{
    partial class ResultScreen
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            saveFileDialog1 = new SaveFileDialog();
            button3 = new Button();
            button4 = new Button();
            txtFN = new TextBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Menu;
            listView1.Location = new Point(23, 118);
            listView1.Name = "listView1";
            listView1.Size = new Size(525, 468);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(592, 118);
            button1.Name = "button1";
            button1.Size = new Size(281, 56);
            button1.TabIndex = 1;
            button1.Text = "Tüm ögrencilerin Sonuçlarını getir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(562, 278);
            button2.Name = "button2";
            button2.Size = new Size(179, 56);
            button2.TabIndex = 2;
            button2.Text = "Ögrenci Sonuç Getir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(761, 298);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 28);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(592, 32);
            label1.Name = "label1";
            label1.Size = new Size(375, 32);
            label1.TabIndex = 4;
            label1.Text = "Ögrenci Başarı Gösterme Ekranı";
            // 
            // chart1
            // 
            chart1.BackColor = SystemColors.ControlDark;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(906, 93);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(676, 493);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            chart1.Click += chart1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button3.Location = new Point(649, 493);
            button3.Name = "button3";
            button3.Size = new Size(190, 67);
            button3.TabIndex = 6;
            button3.Text = "Tüm Sonuçları Pdf Al";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button4.Location = new Point(562, 373);
            button4.Name = "button4";
            button4.Size = new Size(179, 56);
            button4.TabIndex = 7;
            button4.Text = "Ögrenci Sonuç Getir İsimle";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // txtFN
            // 
            txtFN.Location = new Point(761, 384);
            txtFN.Multiline = true;
            txtFN.Name = "txtFN";
            txtFN.Size = new Size(139, 28);
            txtFN.TabIndex = 8;
            // 
            // ResultScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1594, 623);
            Controls.Add(txtFN);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(chart1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "ResultScreen";
            Text = "Result";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private SaveFileDialog saveFileDialog1;
        private Button button3;
        private Button button4;
        private TextBox txtFN;
    }
}