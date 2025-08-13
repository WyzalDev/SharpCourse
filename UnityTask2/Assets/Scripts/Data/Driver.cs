// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using System.Text;

namespace Core.Data
{
    public sealed class Driver : Employee
    {
        public string CarBrand { get; set; }
        public string CarModel { get; set; }

        public Driver()
        {
            CarBrand = "SomeDriversCarBrand";
            CarModel = "SomeDriversCarModel";
        }

        public Driver(string name, string surname, string patronymic, DateTime birthDate,
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

        public override void Update(Human human)
        {
            base.Update(human);
            var driver = human as Driver;
            
            driver.CarBrand = CarBrand;
            driver.CarModel = CarModel;
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