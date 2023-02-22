namespace ClubSystemsAssessment.Models;

public class MembershipDto
{
    public int MembershipId { get; set; }
    
    public int MemberId { get; set; }
    
    public int MembershipTypeId { get; set; }
    
    public Decimal AccountBalance { get; set; }

    public Membership Map()
    {
        return new Membership()
        {
            MembershipId = MembershipId,
            MemberId = MemberId,
            MembershipTypeId = MembershipTypeId,
            AccountBalance = AccountBalance
        };
    }
}