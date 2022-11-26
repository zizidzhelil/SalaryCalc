using Core.Models;
using Core.Models.RequestModels;
using Core.Queries;

namespace Services.Queries.GetSalary
{
    public class GetSalaryQuery : IQuery<SalaryModel>
    {
        public GetSalaryQuery(SalaryRequestModel salaryRequest)
        {
            SalaryRequest = salaryRequest;
        }

        public SalaryRequestModel SalaryRequest { get; }
    }
}
