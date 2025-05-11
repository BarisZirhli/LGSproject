using LGS_Tracking_Application.Models;
using LGS_Tracking_Application.Data;
using Microsoft.EntityFrameworkCore;
namespace LGS_Tracking_Application
{
    public partial class admin : Form
    {

        private UserService userService;
        private readonly AppDbContext _context;
        private string connectionString;
        public admin()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
        }



        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog keyPdf = new OpenFileDialog();
            keyPdf.Filter = "PDF files (*.pdf)|*.pdf";
            keyPdf.Title = "Bir cevap Anahtarı Pdf seçiniz.";

            if (keyPdf.ShowDialog() == DialogResult.OK)
            {
                string keyPdfPath = keyPdf.FileName;

                OpenFileDialog examPdf = new OpenFileDialog();
                examPdf.Filter = "PDF files (*.pdf)|*.pdf";
                examPdf.Title = "Bir sınav Pdf seçiniz.";
                if (examPdf.ShowDialog() == DialogResult.OK)
                {
                    string examPdfPath = examPdf.FileName;
                    using (var context = new AppDbContext(connectionString))
                    {
                        Exam newExam = new Exam
                        {
                            ExamName = txtExamName.Text,
                            Grade = txtExamGrade.Text, // sabit ya da formdan alınabilir
                            Date = DateTime.Now, // örnek tarih
                            Subject = txtExamSubject.Text, // sabit ya da formdan alınabilir
                            answerKeyFilePath = keyPdfPath,
                            PdfFilePath = examPdfPath,

                        };
                        context.Exams.Add(newExam);
                        context.SaveChanges();
                        MessageBox.Show("PDF dosyası başarıyla kaydedildi.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir PDF dosyası seçin.");
                    return;
                }
                // Veritabanı işlemleri

                List<TextBox> panelTextBoxes = panel2.Controls.OfType<TextBox>().ToList();

                //List<TextBox> textBoxes = new List<TextBox>
                //{   txtExamName,
                //    txtExamGrade,
                //    txtExamSubject
                //};

                foreach (var textBox in panelTextBoxes)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>
            {
                txtUsername,
                txtPassword,
                txtName,
                txtLastName,
                txtGrade
            };

            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Please fill in all fields.");

                    return;
                }
            }

            var user = new User
            {
                UserName = txtUsername.Text.ToUpper(),
                Password = txtPassword.Text.ToUpper(),
                FirstName = txtName.Text.ToUpper(),
                LastName = txtLastName.Text.ToUpper(),
                Grade = txtGrade.Text.ToUpper(),
                Role = "STUDENT"
            };

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                MessageBox.Show("User added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            edit studentEditForm = new edit();
            studentEditForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            edit studentEditForm = new edit();
            studentEditForm.Show();
        }
    }
}
