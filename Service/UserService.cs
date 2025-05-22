using LGS_Tracking_Application.Dto;

namespace LGS_Tracking_Application.Service
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
            if (Session.CurrentUser.Role.Equals("ADMIN"))
            {
                return _context.Users.ToList();
            }
            else
            {
                MessageBox.Show("You do not have permission to view this data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void DeleteUser(int TGID)
        {
            try
            {
                if (Session.CurrentAdmin.Role.Equals("ADMIN"))
                {
                    var user = _context.Users.FirstOrDefault(user => user.TGID.Equals(TGID));
                    if (user != null)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("An error occurred while deleting the user.", ex);
            }


        }

        public User GetUserByTGID(int TGID)
        {
            return _context.Users.FirstOrDefault(user => user.TGID == TGID);
        }

        public User GetUserById(int userID)
        {
            return _context.Users.Find(userID);
        }

        public User? GetUserByName(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                return null;
            }

            try 
            {
              
                var nameParts = fullname.Trim().Split(' ');
                if (nameParts.Length != 2)
                {
                    return null;
                }

                string firstName = nameParts[0];
                string lastName = nameParts[1];

                return _context.Users
                    .FirstOrDefault(user => 
                        (user.FirstName != null && user.LastName != null) &&
                        (user.FirstName.ToLower() + " " + user.LastName.ToLower()) == fullname.ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserByName: {ex.Message}");
                return null;
            }
        }

        public List<User> GetUsersByName(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                return new List<User>();
            }

            try 
            {
                var nameParts = fullname.Trim().Split(' ');
                if (nameParts.Length != 2)
                {
                    MessageBox.Show("Please enter both first and last name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<User>();
                }

                string firstName = nameParts[0];
                string lastName = nameParts[1];

                var users = _context.Users
                    .Where(user => 
                        (user.FirstName != null && user.LastName != null) &&
                        (user.FirstName.ToLower() + " " + user.LastName.ToLower()) == fullname.ToLower())
                    .ToList();

                if (!users.Any())
                {
                    MessageBox.Show("No users found with the specified name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetUsersByName: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }

        public void UpdateUser(int TGID, string password, int grade)
        {
            var existingUser = _context.Users.FirstOrDefault(user => user.TGID.Equals(TGID));
            if (existingUser != null)
            {
                existingUser.Password = password;
                existingUser.Grade = grade;

                _context.SaveChanges();
                MessageBox.Show(UserDetailFromUsername(TGID), "User updated successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);  

            }
        }

        public string UserDetailFromUsername(int TGID)
        {
            var user = _context.Users.FirstOrDefault(u => u.TGID == TGID);
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
                var admin = _context.admins.FirstOrDefault(u => u.UserName == username && u.Password == password);

                if (admin != null)
                {
                    Session.CurrentAdmin = admin;
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (user != null)
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

        public List<ResultDto> GetResultDtosFromUsers(List<User> users)
        {
            try
            {
                if (users == null || !users.Any())
                {
                    return new List<ResultDto>();
                }


                var userIds = users.Select(u => u.UserId).ToList();

                var results = _context.Results
                    .Where(r => userIds.Contains(r.UserId))
                    .ToList();

                var resultDtos = new List<ResultDto>();

                foreach (var result in results)
                {
                   
                            var dto = new ResultDto
                            {
                                UserId = result.UserId,
                                ExamId = result.ExamId,
                                TurkishNet = result.TurkishTrueNumber - (result.TurkishFalseNumber / 4.0),
                                MathNet = result.MathTrueNumber - (result.MathFalseNumber / 4.0),
                                ScienceNet = result.ScienceTrueNumber - (result.ScienceFalseNumber / 4.0),
                                HistoryNet = result.HistoryTrueNumber - (result.HistoryFalseNumber / 4.0),
                                ReligionNet = result.ReligionTrueNumber - (result.ReligionFalseNumber / 4.0),
                                EnglishNet = result.EnglishTrueNumber - (result.EnglishFalseNumber / 4.0),
                                DateTime = result.Date
                            };
                            resultDtos.Add(dto);
                        
                    
                }

                if (!resultDtos.Any())
                {
                    MessageBox.Show("No results found for the specified users.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return resultDtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ResultDto>();
            }
        }
    }
}
