// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;

namespace Task2.Data
{
    public class Employee : Human
    {
        public string Organization { get; private set; }
        public int Salary { get; private set; }
        public TimeSpan WorkExperience { get; private set; }

        public Employee()
        {
            Organization = "SomeEmployeeOrganization";
            Salary = 1;
            WorkExperience = TimeSpan.FromDays(30);
        }

        public Employee(string name, string surname, string patronymic, DateOnly birthDate,
            string organization, int salary, TimeSpan workExperience) : base(name, surname, patronymic, birthDate)
        {
            Organization = organization;
            Salary = salary;
            WorkExperience = workExperience;
        }

        public Employee(Employee employee) : base(employee)
        {
            Organization = employee.Organization;
            Salary = employee.Salary;
            WorkExperience = employee.WorkExperience;
        }
        
        public override void RequestData()
        {
            base.RequestData();
            
            Organization = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Organization: ");
            Console.Clear();
            Salary = DefaultInputs.GetCorrectNumberFromConsole($"Enter {GetType().Name} Salary: ");
            Console.Clear();
            
            var workExperienceYears =
                DefaultInputs.GetCorrectNumberFromConsole($"Enter {GetType().Name} Work Experience years: ");
            Console.Clear();
            var workExperienceMonths =
                DefaultInputs.GetCorrectNumberFromConsole($"Enter {GetType().Name} Work Experience months: ");
            Console.Clear();

            WorkExperience = TimeSpan.FromDays(workExperienceYears * 365 + workExperienceMonths * 30);
        }

        public override string ToString()
        {
            var s = new StringBuilder(base.ToString());
            s.AppendLine($"Organization: {Organization}")
                .AppendLine($"Salary: {Salary}")
                .AppendLine($"Work Experience: {WorkExperience.Days / 365} years, {(WorkExperience.Days % 365) / 30} months");
            return s.ToString();
        }

        ~Employee()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}