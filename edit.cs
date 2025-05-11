using LGS_Tracking_Application.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LGS_Tracking_Application
{
    public partial class edit : Form
    {

        private UserService userService;
        private readonly AppDbContext _context;
        private string connectionString;
        public edit()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            userService = new UserService(_context);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            userService.DeleteUser(username);
            this.Hide();
            admin admin = new admin();
            admin.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;  // Username input
            string password = textBox3.Text;  // Password input
            string grade = textBox4.Text;     // Grade input

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(grade))
            {
                // Kullanıcıyı güncelleme
                userService.UpdateUser(username, password, grade);
                MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ListView'i temizle ve güncellenmiş bilgileri yeniden göster
                listView1.Items.Clear();
                button3.PerformClick();

            }
            else
            {
                MessageBox.Show("Password ve Grade boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            List<TextBox> textBoxes = panel3.Controls.OfType<TextBox>().ToList();

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var username = textBox2.Text;
            string userDetails = userService.UserDetailFromUsername(username);

            if (userDetails != null)
            {
                // ListView ayarları
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;

                // Kolonları yalnızca bir kez ekle
                if (listView1.Columns.Count == 0)
                {
                    listView1.Columns.Add("Username", 75);
                    listView1.Columns.Add("Password", 75);
                    listView1.Columns.Add("Grade", 75);
                }

                // Kullanıcı detaylarını ayıklama
                string[] details = userDetails.Split(';');

                ListViewItem item = new ListViewItem();

                if (details.Length == 3)
                {
                    item.Text = details[0];  // Username
                    item.SubItems.Add(details[1]);  // Password
                    item.SubItems.Add(details[2]);  // Grade
                }

                // ListView'e öğe ekleme
                listView1.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
