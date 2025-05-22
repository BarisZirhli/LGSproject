using LGS_Tracking_Application.Models;
using LGS_Tracking_Application.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
namespace LGS_Tracking_Application
{
    public partial class admin : Form
    {
        private UserService userService;
        private ResultService resultService;
        private readonly AppDbContext _context;
        private string connectionString;

        public admin()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            resultService = new ResultService(_context);
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
                    MessageBox.Show("Lütfen Tüm alanları doldurun.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtGrade.Text) ||
                string.IsNullOrWhiteSpace(txtTGID.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!int.TryParse(txtGrade.Text, out int grade))
            {
                MessageBox.Show("Sınıf değeri sayısal olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTGID.Text, out int tgid))
            {
                MessageBox.Show("TGID değeri sayısal olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            var user = new User
            {
                UserName = txtUsername.Text.ToUpper(),
                Password = txtPassword.Text.ToUpper(),
                FirstName = txtName.Text.ToUpper(),
                LastName = txtLastName.Text.ToUpper(),
                Grade = grade,
                Role = "Student",
                TGID = tgid
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

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Dosyaları|*.pdf",
                Title = "Öğrenci Sonuç PDF'ini Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                try
                {
                    using (PdfDocument document = PdfDocument.Open(path))
                    {
                        string fullText = "";

                        foreach (Page page in document.GetPages())
                        {
                            fullText += page.Text + " ";
                        }

                        MessageBox.Show("PDF başarıyla okundu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        int addedCount = ProcessStudentData(fullText);

                        if (addedCount > 0)
                        {
                            MessageBox.Show($"{addedCount} adet öğrenci sonucu başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hiçbir veri işlenemedi. PDF içeriğini kontrol edin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"PDF dosyası okunurken bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Dosya seçimi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private  int ProcessStudentData(string rawText)
        {
            int successCount = 0;
            try
            {
                // Gereksiz boşlukları temizle  
                string cleanedText = Regex.Replace(rawText, @"\s+", " ").Trim();

                string[] allWords = cleanedText.Split(' ');

                // Başlıkları al (17 sütun için)  
                string[] headers = new string[17];
                for (int i = 0; i < 17 && i < allWords.Length; i++)
                {
                    headers[i] = allWords[i];
                }

                // Veriler başlıklardan sonra başladığı için i = 17'den başlıyoruz  
                for (int i = 17; i + 16 < allWords.Length; i += 17)
                {
                    int id = 0, userId = 0, examId = 0, turkishTN = 0, turkishFN = 0, mathTN = 0, mathFN = 0, scienceTN = 0, scienceFN = 0, religionTN = 0, religionFN = 0, historyTN = 0, historyFN = 0, englishTN = 0, englishFN = 0, grade = 0;
                    DateTime date = default;

                    bool parseSuccess =
                        int.TryParse(allWords[i + 0], out id) &&
                        int.TryParse(allWords[i + 1], out userId) &&
                        int.TryParse(allWords[i + 2], out examId) &&
                        int.TryParse(allWords[i + 3], out turkishTN) &&
                        int.TryParse(allWords[i + 4], out turkishFN) &&
                        int.TryParse(allWords[i + 5], out mathTN) &&
                        int.TryParse(allWords[i + 6], out mathFN) &&
                        int.TryParse(allWords[i + 7], out scienceTN) &&
                        int.TryParse(allWords[i + 8], out scienceFN) &&
                        int.TryParse(allWords[i + 9], out religionTN) &&
                        int.TryParse(allWords[i + 10], out religionFN) &&
                        int.TryParse(allWords[i + 11], out historyTN) &&
                        int.TryParse(allWords[i + 12], out historyFN) &&
                        int.TryParse(allWords[i + 13], out englishTN) &&
                        int.TryParse(allWords[i + 14], out englishFN) &&
                        DateTime.TryParse(allWords[i + 15], out date) &&
                        int.TryParse(allWords[i + 16], out grade);

                    if (!parseSuccess)
                    {
                        Console.WriteLine($"Geçersiz format, indeks: {i}");
                        continue;
                    }

                    var result = new Result
                    {
                       
                        UserId = userId,
                        ExamId = examId,
                        TurkishTrueNumber = turkishTN,
                        TurkishFalseNumber = turkishFN,
                        MathTrueNumber = mathTN,
                        MathFalseNumber = mathFN,
                        ScienceTrueNumber = scienceTN,
                        ScienceFalseNumber = scienceFN,
                        ReligionTrueNumber = religionTN,
                        ReligionFalseNumber = religionFN,
                        HistoryTrueNumber = historyTN,
                        HistoryFalseNumber = historyFN,
                        EnglishTrueNumber = englishTN,
                        EnglishFalseNumber = englishFN,
                        Date = date,
                        Grade = grade
                    };

                    successCount++;
                    resultService.addResult(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veri işleme hatası: {ex.Message}");
            }
            return successCount;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultScreen r = new ResultScreen();
            r.Show();

        }
    }
}

