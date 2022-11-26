﻿using System.Text.Json.Serialization;

namespace SalaryCalcWeb.Models
{
    public class EmployeeParameterResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("annualSalary")]
        public double AnnualSalary { get; set; }
    }
}