using LGS_Tracking_Application.Service;

namespace LGS_Tracking_Application
{
    public partial class login : Form
    {

        private readonly UserService userService;
        private readonly AppDbContext _context;
        public login()
        {
            InitializeComponent();
            string connectionString = AppDbContextFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
            userService = new UserService(_context);

            this.txtPassword.PasswordChar = '*'; 
         
            this.txtPassword.UseSystemPasswordChar = true; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string formattedDate = today.ToString("dd/MM/yyyy");
            label4.Text = $"Bugünün Tarihi {formattedDate} 🕒";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userService.Login(txtUsername.Text, txtPassword.Text);


            if (Session.CurrentAdmin != null && Session.CurrentAdmin.Role.Equals("ADMIN"))
            {
                this.Hide();
                admin adminForm = new admin();
                adminForm.Show();
            }
            else if (Session.CurrentUser != null && Session.CurrentUser.Role.Equals("Student"))
            {
                this.Hide();
                student studentForm = new student();
                studentForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
