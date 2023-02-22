using ClubSystemsAssessment.DbContexts;
using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsAssessment.Repository;

public class MembershipTypeRepository : IRepository<MembershipType>
{
    private readonly ApplicationDbContext _db;
    private readonly Response _response;

    public MembershipTypeRepository(ApplicationDbContext db)
    {
        _db = db;
        _response = new();
    }

    public async Task<IEnumerable<MembershipType>> GetAll()
    {
        return await _db.MembershipTypes.ToListAsync();
    }

    public async Task<MembershipType> CreateUpdate(MembershipType membershipType)
    {
        if (membershipType.Id > 0)
            _db.MembershipTypes.Update(membershipType);
        else
            _db.MembershipTypes.Add(membershipType);

        await _db.SaveChangesAsync();

        return membershipType;
    }
}