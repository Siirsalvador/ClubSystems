using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubSystemsAssessment.Models;

public class Membership
{
    [Key]
    public int MembershipId { get; set; }
    
    [ForeignKey("MemberId")]
    public int MemberId { get; set; }

    public virtual Member Member { get; set; } 
    
    [ForeignKey("MembershipTypeId")] 
    public int MembershipTypeId { get; set; }
    
    public virtual MembershipType MembershipType { get; set; }
    
    public Decimal AccountBalance { get; set; }
}
