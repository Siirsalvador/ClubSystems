using System.ComponentModel.DataAnnotations;

namespace ClubSystemsAssessment.Models;

public class MembershipType
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}