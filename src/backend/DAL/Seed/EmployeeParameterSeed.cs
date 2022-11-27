using Core.Entities;

namespace DAL.Seed
{
    public class EmployeeParameterSeed
    {
        public EmployeeParameterSeed()
        {
            EmployeeParameters = new List<EmployeeParameter>
            {
                new EmployeeParameter() {Id = 1, EmployeeId = 1, ParameterId = 2, AnnualSalary = 80000},
                new EmployeeParameter() {Id = 2, EmployeeId = 1, ParameterId = 3, AnnualSalary = 79000},
                new EmployeeParameter() {Id = 3, EmployeeId = 2, ParameterId = 2, AnnualSalary = 70000},
                new EmployeeParameter() {Id = 4, EmployeeId = 3, ParameterId = 2, AnnualSalary = 75000},
                new EmployeeParameter() {Id = 5, EmployeeId = 4, ParameterId = 2, AnnualSalary = 73000},
                new EmployeeParameter() {Id = 6, EmployeeId = 4, ParameterId = 3, AnnualSalary = 71000},
                new EmployeeParameter() {Id = 7, EmployeeId = 5, ParameterId = 2, AnnualSalary = 60000},
                new EmployeeParameter() {Id = 8, EmployeeId = 5, ParameterId = 3, AnnualSalary = 59000},
                new EmployeeParameter() {Id = 9, EmployeeId = 6, ParameterId = 2, AnnualSalary = 50000},
                new EmployeeParameter() {Id = 10, EmployeeId = 6, ParameterId = 3, AnnualSalary = 48000}
            };
        }

        public List<EmployeeParameter> EmployeeParameters { get; }
    }
}
