using LGS_Tracking_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS_Tracking_Application.Service
{
    internal class ResultService
    {
        private readonly AppDbContext _context;

        public ResultService(AppDbContext context)
        {
            _context = context;
        }

        public void addResult(Result result)
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }
        public Dictionary<string, double> getStudentResult(int userId)
        {
            Dictionary<string, double> results = new Dictionary<string, double>();

            var userResult = _context.Results.FirstOrDefault(x => Convert.ToInt32(x.UserId) == userId);
            if (userResult != null)
            {
                
                var subjects = new[]
                {
            new { Name = "turkish", TrueProp = "TurkishTrueNumber", FalseProp = "TurkishFalseNumber" },
            new { Name = "math", TrueProp = "MathTrueNumber", FalseProp = "MathFalseNumber" },
            new { Name = "science", TrueProp = "ScienceTrueNumber", FalseProp = "ScienceFalseNumber" },
            new { Name = "social", TrueProp = "SocialTrueNumber", FalseProp = "SocialFalseNumber" }
        };

                foreach (var subject in subjects)
                {
                   
                    var trueVal = (int)userResult.GetType().GetProperty(subject.TrueProp).GetValue(userResult);
                    var falseVal = (int)userResult.GetType().GetProperty(subject.FalseProp).GetValue(userResult);

                    double net = trueVal - (falseVal / 4.0);
                    results.Add($"{subject.Name}Net", net);
                }
            }

            return results;
        }

    }
}
