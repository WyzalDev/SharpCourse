// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using TMPro;
using Core.Data;

namespace Core.UI.Views.HumanRequests
{
    public abstract class EmployeeRequestView : HumanRequestView
    {
        [SerializeField] private TMP_InputField _organizationInputField;
        [SerializeField] private TMP_InputField _salaryInputField;
        [SerializeField] private TMP_InputField _workExperienceInputField;

        protected override void BuildHumanFromInputFields()
        {
            base.BuildHumanFromInputFields();

            var employee = _human as Employee;
            employee.Organization = _organizationInputField.text;
            employee.Salary = int.Parse(_salaryInputField.text);
            employee.WorkExperience = TimeSpan.Parse(_workExperienceInputField.text);
        }

        protected override void BuildInputFieldsFromHuman(Human human)
        {
            base.BuildInputFieldsFromHuman(human);

            var employee = _human as Employee;

            _organizationInputField.text = employee.Organization;
            _salaryInputField.text = employee.Salary.ToString();
            _workExperienceInputField.text = employee.WorkExperience.ToString();
        }

        protected override void RestoreToDefault()
        {
            _human = new Employee();
        }
    }
}