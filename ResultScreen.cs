using LGS_Tracking_Application.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var userResults = resultService.getStudentResult(userID);
            var student = userService.GetUserById(userID);

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Subject", 150);
            listView1.Columns.Add("Net Score", 100);
            listView1.Columns.Add("Student Name", 150);

            listView1.Items.Clear(); 

            if (userResults != null && student != null)
            {
                foreach (var result in userResults)
                {
                    string subjectName = result.Key;
                    double netScore = result.Value;

                    ListViewItem item = new ListViewItem(subjectName);
                    item.SubItems.Add(netScore.ToString());

                
                    item.SubItems.Add(student.FirstName+" "+student.LastName);

                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Sonuç bulunamadı.");
            }
        }


    }
}
