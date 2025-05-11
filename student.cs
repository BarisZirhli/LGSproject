using LGS_Tracking_Application.Data;
using LGS_Tracking_Application.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGS_Tracking_Application
{
    public partial class student : Form
    {

        private readonly AppDbContext _context;
        private ExamService examService;
        private string connectionString;
        public student()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            examService = new ExamService(_context);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string formattedDate = today.ToString("dd/MM/yyyy");
            tarih_lbl.Text = $"Bugünün Tarihi {formattedDate} 🕒";


            List<Exam> exams=examService.getAllExam();
            foreach (var exam in exams)
            {
                listBox1.Items.Add(exam.Id);
                listBox1.Items.Add(exam.Date);
                listBox1.Items.Add(exam.ExamName);
                listBox1.Items.Add(exam.Subject);


            }

        }



        private void upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.Title = "Lütfen cevap anahtarınızı yükleyin";
            openFileDialog.CheckFileExists = true;

          
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                
                using (var context = new AppDbContext(connectionString))
                {
                    var selectedUser = context.Users.FirstOrDefault(u => u.UserId == Session.CurrentUser.UserId);
                    var selectedExam = context.Exams.FirstOrDefault(e => e.Id == 1);

                    if (Session.CurrentUser.Role.Equals("STUDENT") && selectedUser != null && selectedExam != null)
                    {
                       
                        selectedExam.PdfFilePath = selectedFilePath;
                       // selectedExam.UserExams.Add(selectedUser);
                        context.SaveChanges();
                        MessageBox.Show("PDF dosyası ve kullanıcı-sınav ilişkisi başarıyla kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı veya sınav bulunamadı.");
                    }
                }


            }
        }
    }
}

