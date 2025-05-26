using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using LGS_Tracking_Application.Models;
using LGS_Tracking_Application.Service;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace LGS_Tracking_Application
{
    public partial class ResultScreen : Form
    {
        private ResultService resultService;
        private UserService userService;
        private readonly AppDbContext _context;
        private string connectionString;
        public ResultScreen()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            resultService = new ResultService(_context);
            userService = new UserService(_context);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int userID = int.Parse(textBox1.Text);

            var userResults = resultService.GetResultsByUserTGId(userID);
            var student = userService.GetUserByTGID(userID);

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Subject", 100);
            listView1.Columns.Add("Net Score", 100);
            listView1.Columns.Add("Student Name", 100);
            listView1.Columns.Add("Exam ID", 80);
            listView1.Columns.Add("Exam Date", 80);

            if (userResults != null)
            {
                foreach (var result in userResults)
                {

                    var name = $"{student.FirstName} {student.LastName}";

                    listView1.Items.Add(new ListViewItem(new[] {
                "Turkish",
                result.TurkishNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                 result.DateTime.ToString("dd/MM/yyyy")
            }));

                    listView1.Items.Add(new ListViewItem(new[] {
                "Math",
                result.MathNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                 result.DateTime.ToString("dd/MM/yyyy")
            }));

                    listView1.Items.Add(new ListViewItem(new[] {
                "Science",
                result.ScienceNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                 result.DateTime.ToString("dd/MM/yyyy")
            }));

                    listView1.Items.Add(new ListViewItem(new[] {
                "History",
                result.HistoryNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                 result.DateTime.ToString("dd/MM/yyyy")
            }));
                    listView1.Items.Add(new ListViewItem(new[] {
                "Religion",
                result.ReligionNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                 result.DateTime.ToString("dd/MM/yyyy")
            }));

                    listView1.Items.Add(new ListViewItem(new[] {
                "English",
                result.EnglishNet.ToString("0.00"),
                name,
                result.ExamId.ToString(),
                result.DateTime.ToString("dd/MM/yyyy")
            }));



                }
            }

            else
            {
                MessageBox.Show("Sonuç bulunamadı.");
            }

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();


            Series series = new Series("NETS");
            series.ChartType = SeriesChartType.Column;

            series["PointWidth"] = "0.4";
            series.IsValueShownAsLabel = true;
            series.Color = System.Drawing.Color.DodgerBlue;


            int[] positions = { 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < positions.Length; i++)
            {
                string subject = listView1.Items[i].SubItems[0].Text;
                double netNot = double.Parse(listView1.Items[i].SubItems[1].Text);
                series.Points.AddXY(positions[i], netNot);
                CustomLabel label = new CustomLabel(positions[i] - 0.5, positions[i] + 0.5, subject, 0, LabelMarkStyle.None);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }
            chart1.ChartAreas[0].AxisX.Minimum = 0.5;
            chart1.ChartAreas[0].AxisX.Maximum = 7.5;


            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 8;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightBlue;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);

            chart1.ChartAreas[0].Position.Auto = false;
            chart1.ChartAreas[0].Position.Width = 100;
            chart1.ChartAreas[0].Position.Height = 90;
            chart1.ChartAreas[0].Position.X = 5;
            chart1.ChartAreas[0].Position.Y = 0;

            chart1.ChartAreas[0].InnerPlotPosition.Auto = false;
            chart1.ChartAreas[0].InnerPlotPosition.Width = 90;
            chart1.ChartAreas[0].InnerPlotPosition.Height = 90;
            chart1.ChartAreas[0].InnerPlotPosition.X = 0;
            chart1.ChartAreas[0].InnerPlotPosition.Y = 0;
            chart1.Width = 650;
            chart1.Height = 500;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            series.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            chart1.Series.Add(series);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files (*.pdf)|*.pdf";
            save.Title = "Save Student Results";
            save.FileName = "StudentResults.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);

                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                    doc.Open();

                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
                    var nameFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, new BaseColor(0, 70, 140));
                    var labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY);
                    var valueFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

                  
                    Paragraph title = new Paragraph("Student Result Report", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 25f
                    };
                    doc.Add(title);

                   
                    var studentsGrouped = listView1.Items
                        .Cast<ListViewItem>()
                        .GroupBy(item => item.SubItems[2].Text) 
                        .ToList();

                    foreach (var studentGroup in studentsGrouped)
                    {
                        string studentName = studentGroup.Key;

                      
                        Paragraph studentHeader = new Paragraph(studentName, nameFont)
                        {
                            SpacingBefore = 15f,
                            SpacingAfter = 10f
                        };
                        doc.Add(studentHeader);

                      
                        var exams = studentGroup
                            .GroupBy(item => item.SubItems[3].Text + item.SubItems[4].Text) // ExamID + Date
                            .ToList();

                        foreach (var examGroup in exams)
                        {
                            string examId = examGroup.First().SubItems[3].Text;
                            string examDate = examGroup.First().SubItems[4].Text;

                          
                            Paragraph examInfo = new Paragraph($"Exam ID: {examId}    Date: {examDate}", labelFont)
                            {
                                SpacingAfter = 5f
                            };
                            doc.Add(examInfo);

                           
                            PdfPTable subjectTable = new PdfPTable(2)
                            {
                                WidthPercentage = 60,
                                SpacingAfter = 15f
                            };

                            foreach (var item in examGroup)
                            {
                                string subject = item.SubItems[0].Text;
                                string netScore = item.SubItems[1].Text;

                                PdfPCell subjectCell = new PdfPCell(new Phrase(subject, labelFont))
                                {
                                    BackgroundColor = new BaseColor(230, 230, 250),
                                    Padding = 5
                                };
                                PdfPCell scoreCell = new PdfPCell(new Phrase(netScore, valueFont))
                                {
                                    Padding = 5
                                };

                                subjectTable.AddCell(subjectCell);
                                subjectTable.AddCell(scoreCell);
                            }

                            doc.Add(subjectTable);
                        }

                      
                        LineSeparator line = new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2);
                        doc.Add(new Chunk(line));
                    }

                    MessageBox.Show("Şık PDF başarıyla oluşturuldu.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    doc.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Subject", 100);
            listView1.Columns.Add("Net Score", 100);
            listView1.Columns.Add("Student Name", 100);
            listView1.Columns.Add("Exam ID", 80);
            listView1.Columns.Add("Exam Date", 80);
            var allUserIds = resultService.getallStudentId();

            foreach (var userId in allUserIds)
            {
              
                var userResults = resultService.GetResultByUserId(userId);
                var student = userService.GetUserById(userId);

                if (userResults != null && userResults.Any() && student != null)
                {
                    var name = $"{student.FirstName} {student.LastName}";

                    foreach (var result in userResults)
                    {
                        
                        listView1.Items.Add(new ListViewItem(new[] {
                            "Turkish",
                            result.TurkishNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));

                        listView1.Items.Add(new ListViewItem(new[] {
                            "Math",
                            result.MathNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));

                        listView1.Items.Add(new ListViewItem(new[] {
                            "Science",
                            result.ScienceNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));

                        listView1.Items.Add(new ListViewItem(new[] {
                            "History",
                            result.HistoryNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));

                        listView1.Items.Add(new ListViewItem(new[] {
                            "Religion",
                            result.ReligionNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));

                        listView1.Items.Add(new ListViewItem(new[] {
                            "English",
                            result.EnglishNet.ToString("0.00"),
                            name,
                            result.ExamId.ToString(),
                            result.DateTime.ToString("dd/MM/yyyy")
                        }));
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Subject", 100);
            listView1.Columns.Add("Net Score", 100);
            listView1.Columns.Add("Student Name", 100);
            listView1.Columns.Add("Exam ID", 80);
            listView1.Columns.Add("Exam Date", 80);

            string name = txtFN.Text;
            var userNames = userService.GetUsersByName(name);
            // Örnek: userNames bir List<User> türündeyse
            string allNames = string.Join(", ", userNames.Select(i => i.FirstName.ToString()));
            MessageBox.Show(allNames);

            var userResults = userService.GetResultDtosFromUsers(userNames);

            if (userResults != null && userResults.Any())
            {
                foreach (var result in userResults)
                {
                    var student = userService.GetUserById(result.UserId);
                    if (student == null) continue;

                    var studentName = $"{student.FirstName} {student.LastName}";

                    // Add Turkish result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "Turkish",
                        result.TurkishNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));

                    // Add Math result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "Math",
                        result.MathNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));

                    // Add Science result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "Science",
                        result.ScienceNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));

                    // Add History result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "History",
                        result.HistoryNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));

                    // Add Religion result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "Religion",
                        result.ReligionNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));

                    // Add English result
                    listView1.Items.Add(new ListViewItem(new[] {
                        "English",
                        result.EnglishNet.ToString("0.00"),
                        studentName,
                        result.ExamId.ToString(),
                        result.DateTime.ToString("dd/MM/yyyy")
                    }));
                }

                // Grafiği güncelle
                UpdateChart();
            }
            else
            {
                MessageBox.Show("No results found for the specified name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private void UpdateChart()
        {
            if (listView1.Items.Count == 0) return;

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            Series series = new Series("NETS");
            series.ChartType = SeriesChartType.Column;
            series["PointWidth"] = "0.4";
            series.IsValueShownAsLabel = true;
            series.Color = System.Drawing.Color.DodgerBlue;

            int[] positions = { 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < positions.Length; i++)
            {
                string subject = listView1.Items[i].SubItems[0].Text;
                double netNot = double.Parse(listView1.Items[i].SubItems[1].Text);
                series.Points.AddXY(positions[i], netNot);
                CustomLabel label = new CustomLabel(positions[i] - 0.5, positions[i] + 0.5, subject, 0, LabelMarkStyle.None);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }

           
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 8;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightBlue;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);

            chart1.ChartAreas[0].Position.Auto = false;
            chart1.ChartAreas[0].Position.Width = 100;
            chart1.ChartAreas[0].Position.Height = 90;
            chart1.ChartAreas[0].Position.X = 5;
            chart1.ChartAreas[0].Position.Y = 0;

            chart1.ChartAreas[0].InnerPlotPosition.Auto = false;
            chart1.ChartAreas[0].InnerPlotPosition.Width = 90;
            chart1.ChartAreas[0].InnerPlotPosition.Height = 90;
            chart1.ChartAreas[0].InnerPlotPosition.X = 0;
            chart1.ChartAreas[0].InnerPlotPosition.Y = 0;

            chart1.Width = 650;
            chart1.Height = 500;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            series.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            chart1.Series.Add(series);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            admin adminForm = new admin();
            adminForm.Show();
        }
    }
}
