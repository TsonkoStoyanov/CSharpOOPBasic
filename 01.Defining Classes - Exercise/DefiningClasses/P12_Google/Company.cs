using System;

namespace P12_Google
{
    public class Company
    {
        
        public Company(string companyName, string department, decimal salary)
        {
            CompanyName = companyName;
            Department = department;
            Salary = salary;
        }

        public string CompanyName { get; set; } = String.Empty;

        public string Department { get; set; } = String.Empty;

        public decimal Salary { get; set; } = 0m;

        public override string ToString()
        {
            return $"{CompanyName} {Department} {Salary:f2}";
        }
    }
}