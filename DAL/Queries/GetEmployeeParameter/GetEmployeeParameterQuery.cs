using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetEmployeeParameter
{
    public class GetEmployeeParameterQuery : IQuery<IList<EmployeeParameter>>
    {
        public GetEmployeeParameterQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
    }
}
