using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS_Tracking_Application.Models
{
    public class Result
    {
        [Key]
    
            public int Id { get; set; }
            public int UserId { get; set; }
            public int ExamId { get; set; }

            public int TurkishTrueNumber { get; set; }
            public int TurkishFalseNumber { get; set; }

            public int MathTrueNumber { get; set; }
            public int MathFalseNumber { get; set; }

            public int ScienceTrueNumber { get; set; }
            public int ScienceFalseNumber { get; set; }

            public int HistoryTrueNumber { get; set; }
            public int HistoryFalseNumber { get; set; }

            public int ReligionTrueNumber { get; set; }
            public int ReligionFalseNumber { get; set; }

            public int EnglishTrueNumber { get; set; }
            public int EnglishFalseNumber { get; set; }
        

            public DateTime Date { get; set; } 
            public int Grade { get; set; }




    }
}
