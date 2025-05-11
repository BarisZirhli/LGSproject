using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS_Tracking_Application.Models
{
    public class Result
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public string? ResultValue { get; set; } // examResult => ResultValue
        public DateTime Date { get; set; } // examDate => Date
        public string? Grade { get; set; } // examGrade => Grade
        public string? Subject { get; set; } // examSubject => Subject
        public User? User { get; set; }
        public Exam? Exam { get; set; }

    }
}
