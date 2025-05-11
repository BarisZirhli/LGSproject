
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
            upload_btn = new Button();
            tarih_lbl = new Label();
            listBox1 = new ListBox();
            panel1 = new Panel();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // upload_btn
            // 
            upload_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            upload_btn.Location = new Point(630, 307);
            upload_btn.Name = "upload_btn";
            upload_btn.Size = new Size(122, 57);
            upload_btn.TabIndex = 0;
            upload_btn.Text = "Yükle";
            upload_btn.UseVisualStyleBackColor = true;
            upload_btn.Click += upload_btn_Click;
            // 
            // tarih_lbl
            // 
            tarih_lbl.AutoSize = true;
            tarih_lbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tarih_lbl.Location = new Point(533, 32);
            tarih_lbl.Name = "tarih_lbl";
            tarih_lbl.Size = new Size(65, 25);
            tarih_lbl.TabIndex = 1;
            tarih_lbl.Text = "label1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(14, 16);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(465, 334);
            listBox1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(upload_btn);
            panel1.Controls.Add(tarih_lbl);
            panel1.Controls.Add(listBox1);
            panel1.Location = new Point(22, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 394);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(403, 22);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 4;
            label1.Text = "Ögrenci Ana Ekranı";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // student
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 492);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "student";
            Text = "student";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button upload_btn;
        private Label tarih_lbl;
        private ListBox listBox1;
        private Panel panel1;
        private Label label1;
        private OpenFileDialog openFileDialog1;
    }
}