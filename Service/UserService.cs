using LGS_Tracking_Application.Models;
using Microsoft.Extensions.Configuration;


namespace LGS_Tracking_Application.Data
{
    public class UserService
    {
        private readonly AppDbContext _context;
        
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            if(Session.CurrentUser.Role.Equals("ADMIN"))
            {
                return _context.Users.ToList();
            }  
            else
            {   MessageBox.Show("You do not have permission to view this data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new UnauthorizedAccessException("You do not have permission to view this data.");
            }
          
        }

        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("An error occurred while adding the user.", ex);

            }
        }

        public void DeleteUser(string username)
        {
            try
            {
                if (Session.CurrentAdmin.Role.Equals("ADMIN"))
                {
                    var user = _context.Users.FirstOrDefault(user => user.UserName.Equals(username));
                    if (user != null)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("An error occurred while deleting the user.", ex);
            }


        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }
        public void UpdateUser(string username,string password,string grade)
        {
            var existingUser = _context.Users.FirstOrDefault(user => user.UserName.Equals(username));
            if (existingUser != null)
            {
                existingUser.Password = password;
                existingUser.Grade = grade;

                _context.SaveChanges();
            }
        }


        public string UserDetailFromUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            string userDetails = string.Empty;  
            if (user == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return userDetails;
            }
            userDetails = $"{user.UserName};{user.Password};{user.Grade}";

            return userDetails; 

        }
        public void Login(string username, string password)
        {

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                var admin = _context.admins.FirstOrDefault(u => u.UserName== username && u.Password == password); 

                if(admin != null)
                {
                    Session.CurrentAdmin = admin;
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (user != null )
                {
                    Session.CurrentUser = user;
                    MessageBox.Show("Login successful User!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new UnauthorizedAccessException("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("An error occurred during login.", ex);
            }
        }



     /*   public void CreateExam(User user, string examClass, string examTutorName, string examGrade, string examSubject, DateTime date)
        {
            var admin = _context.Users.Find(user.UserId);
            if ((admin != null) && (admin.Role.Equals("ADMIN")))
            {
                // Check if the user is an admin
                if (admin.Role != "ADMIN")
                {
                    throw new UnauthorizedAccessException("Only admins can create exams.");
                }
                // Create a new exam and add it to the database

                    var exam = new Exam
                {
                    Date = date,
                    PdfFilePath = null, // Set this to the actual file path if needed
                    Grade = examGrade,
                    Subject = examSubject,
                    answerKeyFilePath = null,

                    };

                _context.Exams.Add(exam);
                _context.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException("Only admins can create exams.");
            }
        }
     */
    }
}
