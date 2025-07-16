// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;

namespace Task2.Data
{
    public class Student : Human
    {
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public string Group { get; private set; }

        public Student()
        {
            Faculty = "SomeStudentFaculty";
            Course = 1;
            Group = "SomeStudentGroup";
        }

        public Student(string name, string surname, string patronymic, DateOnly birthDate,
            string faculty, int course, string group) : base(name, surname, patronymic, birthDate)
        {
            Faculty = faculty;
            Course = course;
            Group = group;
        }

        public Student(Student student) : base(student)
        {
            Faculty = student.Faculty;
            Course = student.Course;
            Group = student.Group;
        }

        public override void RequestData()
        {
            base.RequestData();
            
            Faculty = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Faculty: ");
            Console.Clear();
            Course = DefaultInputs.GetCorrectNumberFromConsole($"Enter {GetType().Name} Course: ");
            Console.Clear();
            Group = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Group: ");
            Console.Clear();
        }

        public override string ToString()
        {
            var s = new StringBuilder(base.ToString());
            s.AppendLine($"Faculty: {Faculty}")
                .AppendLine($"Course: {Course}")
                .AppendLine($"Group: {Group}");
            return s.ToString();
        }

        ~Student()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}