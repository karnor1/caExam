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
        Guid id1= Guid.NewGuid();
        UserModel userAdmin = _initialDataGenerator.GenerateUserModel("admin", "admin", CaExam.Shared.eUserRole.Admin, id1);
        Guid id2 = Guid.NewGuid();
        UserModel userUser = _initialDataGenerator.GenerateUserModel("userUser", "userUser", CaExam.Shared.eUserRole.User, id2);

        Guid id3 = Guid.NewGuid();
        UserModel userUser1 = _initialDataGenerator.GenerateUserModel("userUser1", "userUser1", CaExam.Shared.eUserRole.User, id3);

        Guid id4 = Guid.NewGuid();
        UserModel userGuest = _initialDataGenerator.GenerateUserModel("userGuest", "userGuest", CaExam.Shared.eUserRole.Guest, id4);

        modelBuilder.Entity<Address>().HasData(
            _initialDataGenerator.GenerateAddress(id1),
            _initialDataGenerator.GenerateAddress(id2),
            _initialDataGenerator.GenerateAddress(id3),
            _initialDataGenerator.GenerateAddress(id4)
        );

        modelBuilder.Entity<UserDetails>().HasData(
            _initialDataGenerator.GenerateUserDetails(id1),
            _initialDataGenerator.GenerateUserDetails(id2),
            _initialDataGenerator.GenerateUserDetails(id3),
            _initialDataGenerator.GenerateUserDetails(id4)
            );

        modelBuilder.Entity<UserModel>().HasData(
            userAdmin, userGuest, userUser, userUser1
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
