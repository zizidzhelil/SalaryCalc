using Core;

namespace SalaryCalcWeb
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSection _salaryCalcServerSection;

        public AppSettings(IConfiguration configuration)
        {
            _salaryCalcServerSection = configuration.GetSection("SalaryCalcServer");
        }

        public string SalaryCalcServerHost => _salaryCalcServerSection[nameof(SalaryCalcServerHost)];

        public string EmployeePath => _salaryCalcServerSection[nameof(EmployeePath)];

        public string EmployeeParameterPath => _salaryCalcServerSection[nameof(EmployeeParameterPath)];

        public string ParameterPath => _salaryCalcServerSection[nameof(ParameterPath)];

        public string SalaryPath => _salaryCalcServerSection[nameof(SalaryPath)];
    }
}
