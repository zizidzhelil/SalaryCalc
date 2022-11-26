using Core.Entities;

namespace Services.Models.EmployeeModels.ResponseModels
{
    public class EmployeesResponseModel
    {
        public EmployeesResponseModel()
        {
            Id = 0;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            BirthDate = DateTime.MinValue;
        }

        public EmployeesResponseModel(Employee employee)
        {
            if (employee != null)
            {
                Id = employee.Id;
                FirstName = employee.FirstName;
                MiddleName = employee.MiddleName;
                LastName = employee.LastName;
                BirthDate = employee.BirthDate;
            }
            else
            {
                Id = 0;
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;
                BirthDate = DateTime.MinValue;
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
