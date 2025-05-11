using LGS_Tracking_Application.Models;
using System.ComponentModel.DataAnnotations;

public class Exam
{
    [Key]
    public int Id { get; set; }

    public string? ExamName { get; set; } // PascalCase

    public DateTime Date { get; set; }

    public string? Grade { get; set; }

    public string? Subject { get; set; }

    public string? PdfFilePath { get; set; }

    public string? answerKeyFilePath { get; set; }
    public ICollection<UserExam> UserExams { get; set; }

  //  public ICollection<User> Users { get; set; }
}
