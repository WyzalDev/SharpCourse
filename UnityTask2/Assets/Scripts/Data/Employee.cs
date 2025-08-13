// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using System.Text;

namespace Core.Data
{
    public class Employee : Human
    {
        public string Organization { get; set; }
        public int Salary { get; set; }
        public TimeSpan WorkExperience { get; set; }

        public Employee()
        {
            Organization = "SomeEmployeeOrganization";
            Salary = 1;
            WorkExperience = TimeSpan.FromDays(30);
        }

        public Employee(string name, string surname, string patronymic, DateTime birthDate,
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

        public override void Update(Human human)
        {
            base.Update(human);
            var employee = human as Employee;

            Organization = employee.Organization;
            Salary = employee.Salary;
            WorkExperience = employee.WorkExperience;
        }

        public override string ToString()
        {
            var s = new StringBuilder(base.ToString());
            s.AppendLine($"Organization: {Organization}")
                .AppendLine($"Salary: {Salary}")
                .AppendLine(
                    $"Work Experience: {WorkExperience.Days / 365} years, {(WorkExperience.Days % 365) / 30} months");
            return s.ToString();
        }

        ~Employee()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}