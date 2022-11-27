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

            EmployeeParameters = new List<EmployeeParameterResponseModel>();
        }

        public EmployeesResponseModel(Employee employee)
        {
            EmployeeParameters = new List<EmployeeParameterResponseModel>();

            if (employee != null)
            {
                Id = employee.Id;
                FirstName = employee.FirstName;
                MiddleName = employee.MiddleName;
                LastName = employee.LastName;
                BirthDate = employee.BirthDate;

                if (employee.Parameters != null && employee.Parameters.Any())
                {
                    EmployeeParameters = employee.Parameters.Select(p => new EmployeeParameterResponseModel(p))?.ToList();
                }
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<EmployeeParameterResponseModel> EmployeeParameters { get; set; }
    }
}
