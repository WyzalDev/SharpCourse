// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using System.Text;

namespace Core.Data
{
    public class Student : Human
    {
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }

        public Student()
        {
            Faculty = "SomeStudentFaculty";
            Course = 1;
            Group = "SomeStudentGroup";
        }

        public Student(string name, string surname, string patronymic, DateTime birthDate,
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

        public override void Update(Human human)
        {
            base.Update(human);
            var student = human as Student;

            Faculty = student.Faculty;
            Course = student.Course;
            Group = student.Group;
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