using LGS_Tracking_Application.Service;
using LGS_Tracking_Application.Models;


namespace LGS_Tracking_Application
{
    public partial class student : Form
    {

        private readonly AppDbContext _context;

        private string connectionString;
        public student()
        {
            InitializeComponent();
            connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);

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
    }
}

