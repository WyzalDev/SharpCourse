// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;

namespace Task2.Data
{
    public sealed class Driver : Employee
    {
        public string CarBrand { get; private set; }
        public string CarModel { get; private set; }

        public Driver()
        {
            CarBrand = "SomeDriversCarBrand";
            CarModel = "SomeDriversCarModel";
        }

        public Driver(string name, string surname, string patronymic, DateOnly birthDate,
            string organization, int salary, TimeSpan workExperience,
            string carBrand, string carModel) : base(name, surname, patronymic, birthDate,
            organization, salary, workExperience)
        {
            CarBrand = carBrand;
            CarModel = carModel;
        }

        public Driver(Driver driver) : base(driver)
        {
            CarBrand = driver.CarBrand;
            CarModel = driver.CarModel;
        }
        
        public override void RequestData()
        {
            base.RequestData();
            
            var carBrand = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Car Brand: ");
            Console.Clear();
            var carModel = DefaultInputs.GetCorrectStringFromConsole($"Enter {GetType().Name} Car Model: ");
            Console.Clear();
        }

        public override string ToString()
        {
            var s = new StringBuilder(base.ToString());
            s.AppendLine($"Car Brand: {CarBrand}")
                .AppendLine($"Car Model: {CarModel}");
            return s.ToString();
        }

        ~Driver()
        {
            Console.WriteLine("Destructor : Disposed");
            Log();
        }
    }
}