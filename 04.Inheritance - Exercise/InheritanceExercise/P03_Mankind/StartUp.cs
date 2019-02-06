using System;

namespace P03_Mankind
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            try
            {
                var studentInfo = Console.ReadLine().Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facultyNumber = studentInfo[2];
                var student = new Student(firstName, lastName, facultyNumber);

                var workerInfo = Console.ReadLine().Split();
                string workersFirstName = workerInfo[0];
                string workersLastName = workerInfo[1];
                decimal salary = decimal.Parse(workerInfo[2]);
                decimal workingHoursPerDay = decimal.Parse(workerInfo[3]);
                var worker = new Worker(workersFirstName, workersLastName, salary, workingHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
