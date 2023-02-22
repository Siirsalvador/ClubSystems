using ClubSystemsAssessment.DbContexts;
using ClubSystemsAssessment.Models;
using ClubSystemsAssessment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsAssessment.Repository;

public class MemberRepository : IRepository<Member>
{
    private readonly ApplicationDbContext _db;
    
    public MemberRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Member>> GetAll()
    {
        List<Member> members = await _db.Members.ToListAsync();
        return members;
    }

    public async Task<Member> CreateUpdate(Member member)
    {
        if (member.Id > 0)
            _db.Members.Update(member);
        else
            _db.Members.Add(member);

        await _db.SaveChangesAsync();

        return member;
    }
}