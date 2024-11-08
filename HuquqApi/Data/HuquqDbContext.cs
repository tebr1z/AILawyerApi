
using HuquqApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class HuquqDbContext : IdentityDbContext<User>
{
    public HuquqDbContext(DbContextOptions<HuquqDbContext> options) : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ContactForm> contactForms { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<RequestLog> RequestLogs { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
        new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" },
        new IdentityRole { Id = "3", Name = "MasterAdmin", NormalizedName = "MASTERADMIN" }
    };
        builder.Entity<IdentityRole>().HasData(roles);

        var hasher = new PasswordHasher<User>();

        List<User> users = new List<User>
    {
        new User
        {
            Id = "14", 
            UserName = "tabriz",
            Email = "hasimovtabriz@gmail.com",
            NormalizedUserName = "ADMINUSER",
            NormalizedEmail = "HASIMOVTABRIZ@GMAIL.COM",
            PasswordHash = hasher.HashPassword(null, "3865606Rt."),
            EmailConfirmed = true,
            FullName = "Tabriz ",
            LastName="Hashimov"

        },
        new User
        {
            Id = "2", 
            UserName = "admin",
            Email = "tebitebo2001@gmail.com",
            NormalizedUserName = "ADMINUSER1",
            NormalizedEmail = "TEBITEBO2001@GMAIL.COM",
            PasswordHash = hasher.HashPassword(null, "3865606Rt."),
            EmailConfirmed = true,
            FullName = "Admin",
            LastName="User"
        }
    };
        builder.Entity<User>().HasData(users);

    
        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
    {
        new IdentityUserRole<string>
        {
            RoleId = "1",
            UserId = "1"  
        },
        new IdentityUserRole<string>
        {
            RoleId = "2",
            UserId = "2"  
        }
    };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        base.OnModelCreating(builder);
    }


}











