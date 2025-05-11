using System.ComponentModel.DataAnnotations;

namespace LGS_Tracking_Application.Models
{
    public class UserExam
    {
        // Bu bir property olmalı ki EF algılasın:
        [Key]
        public int Id { get; set; }

       
        public int UserId { get; set; }
        public User User { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string? UserKeyAnswerPdffile { get; set; }
      
        
    }
}
