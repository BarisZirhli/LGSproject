using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS_Tracking_Application.Models
{
    public class Admin
    {
       [Key]
        public int AdminId { get; set; }
        [Required, MaxLength(100)]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Role { get; set; } = "ADMIN";

    }
}
