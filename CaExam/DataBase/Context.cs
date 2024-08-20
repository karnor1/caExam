using CaExam.Helpers;
using CaExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Context: DbContext
{
    private readonly IInitialDataGenerator _initialDataGenerator;
    public Context(DbContextOptions<Context> options, IInitialDataGenerator initialDataGenerator)
    : base(options)
    {
        _initialDataGenerator = initialDataGenerator;
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Guid id= Guid.NewGuid();
        UserModel user = _initialDataGenerator.GenerateUserModel("admin", "admin", CaExam.Shared.eUserRole.Admin, id);


        modelBuilder.Entity<Address>().HasData(
            _initialDataGenerator.GenerateAddress(id)
        );

        modelBuilder.Entity<UserDetails>().HasData(
            _initialDataGenerator.GenerateUserDetails(id)
            );

        modelBuilder.Entity<UserModel>().HasData(
            user
        );




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
