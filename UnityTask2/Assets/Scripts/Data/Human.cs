// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using System.Text;

namespace Core.Data
{
    public abstract class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }

        protected Human()
        {
            Name = "SomeHumanName";
            Surname = "SomeHumanSurname";
            Patronymic = "SomeHumanPatronymic";
            BirthDate = new DateTime(2000, 1, 1);

            Console.WriteLine($"Empty constructor: Created.");
            Log();
        }

        protected Human(string name, string surname, string patronymic, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;

            Console.WriteLine($"Constructor: Created");
            Log();
        }

        protected Human(Human human)
        {
            Name = human.Name;
            Surname = human.Surname;
            Patronymic = human.Patronymic;
            BirthDate = human.BirthDate;

            Console.WriteLine($"Copy constructor: Created");
            Log();
        }

        public int GetFullYearsCount()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if (BirthDate.CompareTo(DateTime.Now.AddYears(-age)) < 0)
                age--;

            return age;
        }

        public virtual void Update(Human human)
        {
            Name = human.Name;
            Surname = human.Surname;
            Patronymic = human.Patronymic;
            BirthDate = human.BirthDate;
        }

        public void Log()
        {
            Console.WriteLine(
                $"{GetType().Name} with name - {Name},surname - {Surname}, years - {GetFullYearsCount()}");
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.AppendLine($"{GetType().Name}")
                .AppendLine($"Name : {Name}")
                .AppendLine($"Surname : {Surname}")
                .AppendLine($"Patronymic : {Patronymic}")
                .AppendLine($"BirthDate : {BirthDate:d}");
            return s.ToString();
        }

        ~Human()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}