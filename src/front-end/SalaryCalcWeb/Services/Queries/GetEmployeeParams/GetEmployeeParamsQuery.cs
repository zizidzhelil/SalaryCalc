using Core.Models;
using Core.Queries;

namespace Services.Queries.GetEmployeeParams
{
    public record GetEmployeeParamsQuery : IQuery<IList<EmployeeParameterModel>>
    {
        public GetEmployeeParamsQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
