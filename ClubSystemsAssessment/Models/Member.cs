using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClubSystemsAssessment.Models;

public class Member 
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Forename { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public string Email { get; set; }
}