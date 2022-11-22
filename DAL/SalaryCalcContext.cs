using Core.Entities;
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

        public SalaryCalcContext CreateDbContext(string[] args)
        {
            // TODO: Move this to proper location
            var optionsBuilder = new DbContextOptionsBuilder<SalaryCalcContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=SalaryCalc;Trusted_Connection=True");

            return new SalaryCalcContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}
