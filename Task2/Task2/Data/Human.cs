// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;

namespace Task2.Data
{
    public abstract class Human
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public DateOnly BirthDate { get; private set; }

        protected Human()
        {
            Name = "SomeHumanName";
            Surname = "SomeHumanSurname";
            Patronymic = "SomeHumanPatronymic";
            BirthDate = new DateOnly(2000, 1, 1);
            
            Console.WriteLine($"Empty constructor: Created.");
            Log();
        }

        protected Human(string name, string surname, string patronymic, DateOnly birthDate)
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

            if (BirthDate.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-age))) < 0)
                age--;

            return age;
        }

        public virtual void RequestData()
        {
            Console.Clear();
            Name = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} name: ");
            Console.Clear();
            Surname = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Surname: ");
            Console.Clear();
            Patronymic = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Patronymic: ");
            Console.Clear();
            BirthDate =
                DefaultInputs.GetCorrectDateFromConsole($"Enter {GetType().Name} Birth Date(in yyyy-MM-dd format): ");
            Console.Clear();
        }

        public void Log()
        {
            Console.WriteLine($"{GetType().Name} with name - {Name},surname - {Surname}, years - {GetFullYearsCount()}");
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.AppendLine($"{GetType().Name}")
                .AppendLine($"Name : {Name}")
                .AppendLine($"Surname : {Surname}")
                .AppendLine($"Patronymic : {Patronymic}")
                .AppendLine($"BirthDate : {BirthDate}");
            return s.ToString();
        }

        ~Human()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}