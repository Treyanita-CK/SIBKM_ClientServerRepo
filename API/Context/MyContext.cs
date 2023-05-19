using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Context;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Profiling> Profilings { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One University has many Educations (one to many)
        modelBuilder.Entity<University>()
            .HasMany(u => u.Educations)
            .WithOne(e => e.University)
            .IsRequired(false)
            .HasForeignKey(e => e.UniversityId)
            .OnDelete(DeleteBehavior.SetNull);

        // One Education has one Profiling (one to one)
        modelBuilder.Entity<Education>()
            .HasOne(e => e.Profiling)
            .WithOne(e => e.Education)
            .IsRequired(false)
            .HasForeignKey<Profiling>(p => p.EducationId)
            .OnDelete(DeleteBehavior.SetNull);

        // One Profiling has one Employee
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Profiling)
            .WithOne(p => p.Employee)
            .HasForeignKey<Profiling>(p => p.EmployeeNIK)
            .OnDelete(DeleteBehavior.Restrict);

        // One Roles has many Account Roles 
        modelBuilder.Entity<Role>()
            .HasMany(a => a.AccountRoles)
            .WithOne(r => r.Role)
            .IsRequired(false)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.SetNull);

        // One Accounts has many Accounts Roles
        modelBuilder.Entity<Account>()
            .HasMany(a => a.AccountRoles)
            .WithOne(c => c.Account)
            .IsRequired(false)
            .HasForeignKey(a => a.AccountNik)
            .OnDelete(DeleteBehavior.SetNull);

        // One Accounts has one Employee
        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Accounts)
            .WithOne(p => p.Employee)
            .HasForeignKey<Account>(a => a.EmployeeNIK)
            .OnDelete(DeleteBehavior.Restrict);
    }
} //