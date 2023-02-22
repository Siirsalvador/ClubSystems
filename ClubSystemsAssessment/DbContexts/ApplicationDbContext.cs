using ClubSystemsAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsAssessment.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Member> Members { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Membership> Memberships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // member to membership type constraint
        modelBuilder.Entity<Membership>().HasIndex(i => new {i.MemberId, i.MembershipTypeId});
        
        modelBuilder.Entity<Member>().HasData(new Member
        {
            Id = 1, Email = "test@test.com", Forename = "test", Surname = "McTest"
        });
        
        modelBuilder.Entity<MembershipType>().HasData(new MembershipType
        {
            Id = 1, Name = "Test"
        }, new MembershipType
        {
            Id = 2, Name = "SecondTest"
        });
        
        modelBuilder.Entity<Membership>().HasData(new Membership
        {
            MembershipId = 1, MemberId = 1, MembershipTypeId = 1, AccountBalance = -100
        }, new Membership
        {
            MembershipId = 2, MemberId = 1, MembershipTypeId = 2, AccountBalance = 100000
        });
        
        base.OnModelCreating(modelBuilder);
    }
}