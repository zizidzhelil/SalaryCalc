using Core.Entities;
using MediatR;

namespace Services.Models.EmployeeModels.RequestModels
{
    public class PostEmployeeRequestModel : IRequest
    {
        public PostEmployeeRequestModel()
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            BirthDate = DateTime.MinValue;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Employee ToEmployee()
        {
            return new Employee()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                BirthDate = BirthDate,
                LastName = LastName,
            };
        }
    }
}
