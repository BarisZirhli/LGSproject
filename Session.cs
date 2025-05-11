using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGS_Tracking_Application.Models;
namespace LGS_Tracking_Application
{
    public static class Session
    {
        public static User? CurrentUser { get; set; }
        public static Admin? CurrentAdmin { get; set; }
    }

}
