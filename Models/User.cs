using LGS_Tracking_Application.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(100)]
    public string? UserName { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required, MaxLength(50)]
    public string? Role { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public int? Grade { get; set; }

    [Required]
    public int? TGID { get; set; }
    public ICollection<Result> UserResults { get; set; }
}
