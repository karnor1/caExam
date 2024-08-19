using CaExam.Models;
using Microsoft.EntityFrameworkCore;

public class Context: DbContext
{

    public Context(DbContextOptions<Context> options)
    : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.UserId);

        modelBuilder.Entity<UserModel>()
            .HasOne(u => u.UserDetails)
            .WithOne(d => d.User)
            .HasForeignKey<UserDetails>(d => d.UserId);

        base.OnModelCreating(modelBuilder);
    }
}
