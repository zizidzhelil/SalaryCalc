using Core.Entities;
using DAL.Configs;
using DAL.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class SalaryCalcContext : DbContext, IDesignTimeDbContextFactory<SalaryCalcContext>
    {
        public SalaryCalcContext()
        {
        }

        public SalaryCalcContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Parameter> Parameters { get; set; }

        public DbSet<EmployeeParameter> EmployeeParameter { get; set; }

        public SalaryCalcContext CreateDbContext(string[] args)
        {
            // TODO: Move this to proper location
            var optionsBuilder = new DbContextOptionsBuilder<SalaryCalcContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SalaryCalc;Trusted_Connection=True;Encrypt=False");

            return new SalaryCalcContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ParameterConfig());
            modelBuilder.ApplyConfiguration(new EmployeeParameterConfig());

            modelBuilder.Entity<Employee>().HasData(new EmployeeSeed().Employees);
            modelBuilder.Entity<Parameter>().HasData(new ParameterSeed().Parameters);
            modelBuilder.Entity<EmployeeParameter>().HasData(new EmployeeParameterSeed().EmployeeParameters);
        }
    }
}
