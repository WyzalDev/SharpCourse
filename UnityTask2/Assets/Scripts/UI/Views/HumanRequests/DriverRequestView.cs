// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using TMPro;
using Core.Data;

namespace Core.UI.Views.HumanRequests
{
    public abstract class DriverRequestView : EmployeeRequestView
    {
        [SerializeField] private TMP_InputField _carBrandInputField;
        [SerializeField] private TMP_InputField _carModelInputField;

        protected override void BuildHumanFromInputFields()
        {
            base.BuildHumanFromInputFields();

            var driver = _human as Driver;
            driver.CarBrand = _carBrandInputField.text;
            driver.CarModel = _carModelInputField.text;
        }

        protected override void BuildInputFieldsFromHuman(Human human)
        {
            base.BuildInputFieldsFromHuman(human);

            var driver = _human as Driver;

            _carBrandInputField.text = driver.CarBrand;
            _carModelInputField.text = driver.CarModel;
        }

        protected override void RestoreToDefault()
        {
            _human = new Driver();
        }
    }
}