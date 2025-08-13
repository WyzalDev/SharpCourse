// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using TMPro;
using Core.Data;

namespace Core.UI.Views.HumanRequests
{
    public abstract class StudentRequestView : HumanRequestView
    {
        [SerializeField] private TMP_InputField _facultyInputField;
        [SerializeField] private TMP_InputField _courseInputField;
        [SerializeField] private TMP_InputField _groupInputField;

        protected override void BuildHumanFromInputFields()
        {
            base.BuildHumanFromInputFields();

            var student = _human as Student;
            student.Faculty = _facultyInputField.text;
            student.Course = int.Parse(_courseInputField.text);
            student.Group = _groupInputField.text;
        }

        protected override void BuildInputFieldsFromHuman(Human human)
        {
            base.BuildInputFieldsFromHuman(human);

            var student = _human as Student;

            _facultyInputField.text = student.Faculty;
            _courseInputField.text = student.Course.ToString();
            _groupInputField.text = student.Group;
        }

        protected override void RestoreToDefault()
        {
            _human = new Student();
        }
    }
}