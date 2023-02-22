using ClubSystemsAssessment.Models;

namespace ClubSystemsAssessment.Repository.Interfaces;

public interface IMembershipRepository : IRepository<Membership>
{
    Task<IEnumerable<Membership>> GetByMemberId(int Id);
    
    Task<IEnumerable<Membership>> GetByMembershipTypeId(int Id);

    Task<IEnumerable<Membership>> GetOverdrawnMemberships();
}