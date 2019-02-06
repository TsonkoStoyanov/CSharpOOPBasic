using System.ComponentModel.DataAnnotations;

namespace P06_CompanyRoster
{
    public class Employee
    {
        private string name;

        private int age;

        private decimal salary;

        private string position;

        private string department;

        private string email;

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = email;
            this.age = age;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public override string ToString()
        {
            return $"{name} {salary:f2} {email} {age}";
        }

    }
}