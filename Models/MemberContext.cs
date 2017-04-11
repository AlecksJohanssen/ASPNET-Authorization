using Microsoft.EntityFrameworkCore;

public class MemberContext : DbContext  
{
    public MemberContext(DbContextOptions<MemberContext> options)
        : base(options)
    { }

    public DbSet<Member> members { get; set; }
}