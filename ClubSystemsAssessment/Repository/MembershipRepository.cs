using ClubSystemsAssessment.DbContexts;
using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsAssessment.Repository;

public class MembershipRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _db;

    public MembershipRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Membership>> GetAll()
    {
        return await _db.Memberships.ToListAsync();
    }

    public async Task<Membership> CreateUpdate(Membership membership)
    {
        var memTypeInDb = await _db.MembershipTypes.FirstOrDefaultAsync(u =>
            u.Id == membership.MembershipTypeId);

        if (memTypeInDb == null)
        {
            return membership;
        }

        var memberInDb = await _db.Members.FirstOrDefaultAsync(u =>
            u.Id == membership.MemberId);

        if (memberInDb == null)
        {
            return membership;
        }
        
        if (membership.MembershipId > 0)
        {
            membership.Member = memberInDb;
            membership.MembershipType = memTypeInDb;
            _db.Memberships.Update(membership);
            await _db.SaveChangesAsync();
        }
        else
        {
            if (_db.Memberships.Any(u =>
                    u.MemberId == membership.MemberId && u.MembershipTypeId == membership.MembershipTypeId))
            {
                return membership;
            }
            membership.Member = memberInDb;
            membership.MembershipType = memTypeInDb;
            _db.Memberships.Add(membership);
            await _db.SaveChangesAsync();
        }
        return membership;
    }

    public async Task<IEnumerable<Membership>> GetByMemberId(int id)
    {
        List<Membership> members = await _db.Memberships.Where(m=>m.MemberId == id).ToListAsync();
        return members;
    }

    public async Task<IEnumerable<Membership>> GetByMembershipTypeId(int id)
    {
        List<Membership> members = await _db.Memberships.Where(m=>m.MembershipTypeId == id).ToListAsync();
        return members;
    }

    public async Task<IEnumerable<Membership>> GetOverdrawnMemberships()
    {
        List<Membership> members = await _db.Memberships.Where(m=>m.AccountBalance < 0).ToListAsync();
        return members;
    }
}