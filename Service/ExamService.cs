using LGS_Tracking_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGS_Tracking_Application.Models;

namespace LGS_Tracking_Application.Service
{
    public class ExamService

    {

        private readonly AppDbContext _context;

        public ExamService(AppDbContext context)
        {
            _context = context;
        }

        public List<Exam> getAllExam()
        {
            return _context.Exams.ToList();

        }


    }
}
