using Core.Models;
using Core.Queries;

namespace Services.Queries.GetAllEmployees
{
    public record GetAllEmployeesQuery : IQuery<IList<EmployeeModel>> { }
}
