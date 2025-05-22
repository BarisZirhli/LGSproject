using LGS_Tracking_Application.Dto;
using LGS_Tracking_Application.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _context.Results.Add(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hata mesajını veya loglama yapın
                Console.WriteLine("AddResult error: " + ex.Message);
                throw;  // Veya hatayı dışarı fırlatın ki üstte yakalansın
            }
        }

      

        public List<ResultDto> GetResultsByUserTGId(int TGID)
        {
            try
            {
                var userWithResults = _context.Users
                    .Include(u => u.UserResults)
                    .FirstOrDefault(x => x.TGID == TGID);

                if (userWithResults == null)
                {
                    return new List<ResultDto>();
                }

                return userWithResults.UserResults
                    .Select(result => new ResultDto
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
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetResultsByUserId: {ex.Message}");
                throw;
            }
        }

        public List<int> getallStudentId()
        {
            List<int> studentIds = new List<int>();
            var students = _context.Users.ToList();
            foreach (var student in students)
            {
                studentIds.Add(student.UserId);
            }
            return studentIds;
        }

        public List<ResultDto> GetResultById(int examId)
        {
            try
            {
                var results = _context.Results
                 
                    .Where(r => r.ExamId == examId)
                    .Select(result => new ResultDto
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
                    })
                    .ToList();

                if (!results.Any())
                {
                    Console.WriteLine($"No results found for exam ID: {examId}");
                    return new List<ResultDto>();
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetResultById: {ex.Message}");
                throw;
            }
        }

        public List<ResultDto> GetResultByUserId(int userId)
        {
            try
            {
                var results = _context.Results

                    .Where(r => r.UserId == userId)
                    .Select(result => new ResultDto
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
                    })
                    .ToList();

                if (!results.Any())
                {
                    Console.WriteLine($"No results found for exam ID: {userId}");
                    return new List<ResultDto>();
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetResultById: {ex.Message}");
                throw;
            }
        }

      
    }
}
