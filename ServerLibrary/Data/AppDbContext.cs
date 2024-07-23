using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        // GeneralDepartments / Department / Branch
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        // Country / City / Town
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        // Authentication / Role / SystemRole
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
        // Other / Vacation / Sanction / Doctor / Overtime
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateType> CertificateTypes { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configuración de las relaciones
        //    modelBuilder.Entity<Overtime>()
        //        .HasOne(o => o.OvertimeType)
        //        .WithMany(ot => ot.Overtimes)
        //        .HasForeignKey(o => o.OvertimeTypeId);
        //}

    }

    

}



//using BaseLibrary.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace ServerLibrary.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        public DbSet<Employee> Employees { get; set; }
//        //GeneralDepartaments / Departament /Branch
//        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
//        public DbSet<Department> Departments { get; set; }
//        public DbSet<Branch> Branches { get; set; }
//        //country / city Town
//        public DbSet<Town> Towns { get; set; }
//        public DbSet<Country> Countries { get; set; }
//        public DbSet<City> Cities { get; set; }
//        //Authentication / Role /SystemRole
//        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
//        public DbSet<SystemRole> SystemRoles { get; set; }
//        public DbSet<UserRole> UserRoles { get; set; }
//        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
//        //Other / Vacation /Sanction / Doctor / Overtime
//        public DbSet<Vacation> Vacations { get; set; }
//        public DbSet<VacationType> VacationTypes { get; set; }
//        public DbSet<Overtime> Overtimes { get; set; }
//        public DbSet<OvertimeType> OvertimeTypes { get; set; }
//        public DbSet<Sanction> Sanctions { get; set; }
//        public DbSet<SanctionType> SanctionTypes { get; set; }
//        public DbSet<Doctor> Doctors { get; set; }
//    }
//}
