namespace Core
{
    public interface IAppSettings
    {
        string SalaryCalcServerHost { get; }

        string EmployeePath { get; }

        string EmployeeParameterPath { get; }

        string ParameterPath { get; }

        string ParameterByYearPath { get; }

        string SalaryPath { get; }
    }
}
