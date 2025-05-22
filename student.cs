using iTextSharp.text;
using iTextSharp.text.pdf;
using LGS_Tracking_Application.Dto;
using LGS_Tracking_Application.Models;
using LGS_Tracking_Application.Service;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms.DataVisualization.Charting;


namespace LGS_Tracking_Application
{
    public partial class student : Form
    {

        private readonly AppDbContext _context;
        private readonly UserService _userService;
        private readonly ResultService _resultService;

        private string connectionString;
        public student()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            _resultService = new ResultService(_context);
            _userService = new UserService(_context);

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string formattedDate = today.ToString("dd/MM/yyyy");
            tarih_lbl.Text = $"Bugünün Tarihi {formattedDate} 🕒";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            int userID = Session.CurrentUser.UserId;

            var userResults = _resultService.GetResultByUserId(userID);
            var student = _userService.GetUserById(userID);

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Subject", 100);
            listView1.Columns.Add("Net Score", 100);
            listView1.Columns.Add("Student Name", 100);
            listView1.Columns.Add("Exam ID", 50);
            listView1.Columns.Add("Exam Date", 80);

            if (userResults != null && student != null)
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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files (*.pdf)|*.pdf";
            save.Title = "Save Student Results";
            var student = _userService.GetUserById(Session.CurrentUser.UserId);
            save.FileName = $"{student.FirstName.ToUpper() + "_" + student.LastName.ToUpper()}.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4);
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                    doc.Open();


                    Paragraph title = new Paragraph($"{student.FirstName.ToUpper() + " " + student.LastName.ToUpper()} Results")
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    title.SpacingAfter = 20;
                    doc.Add(title);


                    PdfPTable table = new PdfPTable(listView1.Columns.Count);
                    table.WidthPercentage = 100;


                    foreach (ColumnHeader column in listView1.Columns)
                    {
                        PdfPCell header = new PdfPCell(new Phrase(column.Text));
                        header.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(header);
                    }


                    foreach (ListViewItem item in listView1.Items)
                    {
                        table.AddCell(item.Text);
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems.Cast<ListViewItem.ListViewSubItem>().Skip(1))
                        {
                            table.AddCell(subItem.Text);
                        }
                    }

                    doc.Add(table);
                    MessageBox.Show("PDF exported successfully.");
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

        private void upload_btn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var Result = new Result
            {
                TurkishTrueNumber = string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text),
                TurkishFalseNumber = string.IsNullOrEmpty(textBox2.Text) ? 0 : Convert.ToInt32(textBox2.Text),

                MathTrueNumber = string.IsNullOrEmpty(textBox3.Text) ? 0 : Convert.ToInt32(textBox4.Text),
                MathFalseNumber = string.IsNullOrEmpty(textBox4.Text) ? 0 : Convert.ToInt32(textBox3.Text),

                ScienceTrueNumber = string.IsNullOrEmpty(textBox5.Text) ? 0 : Convert.ToInt32(textBox6.Text),
                ScienceFalseNumber = string.IsNullOrEmpty(textBox6.Text) ? 0 : Convert.ToInt32(textBox5.Text),

                ReligionTrueNumber = string.IsNullOrEmpty(textBox7.Text) ? 0 : Convert.ToInt32(textBox8.Text),
                ReligionFalseNumber = string.IsNullOrEmpty(textBox8.Text) ? 0 : Convert.ToInt32(textBox7.Text),

                EnglishTrueNumber = string.IsNullOrEmpty(textBox9.Text) ? 0 : Convert.ToInt32(textBox10.Text),
                EnglishFalseNumber = string.IsNullOrEmpty(textBox10.Text) ? 0 : Convert.ToInt32(textBox9.Text),

                HistoryTrueNumber = string.IsNullOrEmpty(textBox11.Text) ? 0 : Convert.ToInt32(textBox12.Text),
                HistoryFalseNumber = string.IsNullOrEmpty(textBox12.Text) ? 0 : Convert.ToInt32(textBox11.Text),

                Date = DateTime.UtcNow,
                UserId = Session.CurrentUser.UserId,
                ExamId = rnd.Next(1, 999999),
                Grade = 8,

            };

            _resultService.addResult(Result);
            MessageBox.Show("Result uploaded successfully.");
            List<TextBox> textBoxes = panel2.Controls.OfType<TextBox>().ToList();
            
            foreach(var textBox in textBoxes)
            {
                textBox.Clear();
            }   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
           
            int userId;
            if (Session.CurrentUser != null)
            {
                userId = Session.CurrentUser.UserId;
            }
            else
            {
                MessageBox.Show("Current user is not logged in or session is invalid.");
                return; 
            }
            int examId;

            if (!int.TryParse(txtExam.Text, out examId))
            {
                MessageBox.Show("Invalid Exam ID");
                return;
            }

            var results = _resultService.GetResultByUserId(userId);

            var dto = results.FirstOrDefault(r => r.ExamId == examId);


            if (dto != null)
            {      

                listView1.View = View.Details;
                listView1.Columns.Clear();
                listView1.Columns.Add("Subject", 100);
                listView1.Columns.Add("Net Score", 100);
                listView1.Columns.Add("Student Name", 100);
                listView1.Columns.Add("Exam ID", 80);
                listView1.Columns.Add("Exam Date", 80);

                var name = $"{Session.CurrentUser.FirstName} {Session.CurrentUser.LastName}";

                if (dto != null) {

                    listView1.Items.Add(new ListViewItem(new[] {
                        "Turkish",
                        dto.TurkishNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));

                    listView1.Items.Add(new ListViewItem(new[] {
                        "Math",
                        dto.MathNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));

                    listView1.Items.Add(new ListViewItem(new[] {
                        "Science",
                        dto.ScienceNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));

                    listView1.Items.Add(new ListViewItem(new[] {
                        "History",
                        dto.HistoryNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));
                    
                    listView1.Items.Add(new ListViewItem(new[] {
                        "Religion",
                        dto.ReligionNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));

                    listView1.Items.Add(new ListViewItem(new[] {
                        "English",
                        dto.EnglishNet.ToString("0.00"),
                        name,
                        dto.ExamId.ToString(),
                        dto.DateTime.ToString("dd/MM/yyyy")
                    }));

                }

            }
            else
            {
                MessageBox.Show("No results found for this exam ID.");
            }

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();


            Series series = new Series("NETS");
            series.ChartType = SeriesChartType.Column;

            series["PointWidth"] = "0.5";
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
            chart1.ChartAreas[0].AxisX.Maximum = 8.0;


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
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].Position.X = 5;
            chart1.ChartAreas[0].Position.Y = 0;

            chart1.ChartAreas[0].InnerPlotPosition.Auto = false;
            chart1.ChartAreas[0].InnerPlotPosition.Width = 90;
            chart1.ChartAreas[0].InnerPlotPosition.Height = 85;
            chart1.ChartAreas[0].InnerPlotPosition.X = 0;
            chart1.ChartAreas[0].InnerPlotPosition.Y = 0;
            chart1.Width = 650;
            chart1.Height = 500;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            series.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            chart1.Series.Add(series);

        }

            }
        }

