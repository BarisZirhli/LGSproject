using LGS_Tracking_Application.Models;
using LGS_Tracking_Application.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
namespace LGS_Tracking_Application
{
    public partial class admin : Form
    {
        private UserService userService;
        private ResultService resultService; // Ensure this instance is initialized
        private readonly AppDbContext _context;
        private string connectionString;

        public admin()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            resultService = new ResultService(_context); // Initialize ResultService with AppDbContext
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
                Grade = Convert.ToInt32(txtGrade.Text),
                Role = "STUDENT",
                TGID = Convert.ToInt32(txtTGID.Text)
                
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
        private int ProcessStudentData(string rawText)
        {
            int successCount = 0;

            try
            {
                string cleanedText = Regex.Replace(rawText, @"\s+", " ").Trim();
                string[] allWords = cleanedText.Split(' ');

                string[] headers = new string[13];
                for (int i = 0; i < 13 && i < allWords.Length; i++)
                {
                    headers[i] = allWords[i];
                }

                for (int i = 13; i < allWords.Length; i += 13)
                {
                    if (i + 12 < allWords.Length)
                    {
                        try
                        {
                            var result = new Result
                            {

                                UserId = int.Parse(allWords[i + 1]),
                                ExamId = int.Parse(allWords[i + 2]),
                                TurkishTrueNumber = int.Parse(allWords[i + 3]),
                                TurkishFalseNumber = int.Parse(allWords[i + 4]),
                                MathTrueNumber = int.Parse(allWords[i + 5]),
                                MathFalseNumber = int.Parse(allWords[i + 6]),
                                ScienceTrueNumber = int.Parse(allWords[i + 7]),
                                ScienceFalseNumber = int.Parse(allWords[i + 8]),
                                SocialTrueNumber = int.Parse(allWords[i + 9]),
                                SocialFalseNumber = int.Parse(allWords[i + 10]),
                                Date = DateTime.Parse(allWords[i + 11]),
                                Grade = int.Parse(allWords[i + 12])
                            };

                            resultService.addResult(result);
                            successCount++;
                            MessageBox.Show($"{successCount}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Geçersiz format, indeks: {i}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler işlenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

