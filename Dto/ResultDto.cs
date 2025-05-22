
namespace LGS_Tracking_Application.Dto
{
    public class ResultDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public double TurkishNet { get; set; }
        public double MathNet { get; set; }
        public double ScienceNet { get; set; }
        public double HistoryNet { get; set; }   
        public double ReligionNet { get; set; }   
        public double EnglishNet { get; set; }
        public DateTime DateTime { get; set; }

    }
}
