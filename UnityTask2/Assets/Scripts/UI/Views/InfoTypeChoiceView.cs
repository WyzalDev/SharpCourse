// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using Core.Data;
using Core.UI.Views.HumanRequests.Drivers;
using Core.UI.Views.HumanRequests.Employees;
using Core.UI.Views.HumanRequests.Students;

namespace Core.UI.Views
{
    public class InfoTypeChoiceView : Page
    {
        [SerializeField] private Button _addStudentButton;
        [SerializeField] private Button _addEmployeeButton;
        [SerializeField] private Button _addDriverButton;
        [SerializeField] private Button _backButton;

        public override void Initialize()
        {
            _addStudentButton.onClick.AddListener(OnAddStudentButton);
            _addEmployeeButton.onClick.AddListener(OnAddEmployeeButton);
            _addDriverButton.onClick.AddListener(OnAddDriverButton);
            _backButton.onClick.AddListener(OnBackButton);
        }

        private void OnAddStudentButton()
        {
            PageManager.Show<StudentAddRequestView>(new Student());
        }

        private void OnAddEmployeeButton()
        {
            PageManager.Show<EmployeeAddRequestView>(new Employee());
        }

        private void OnAddDriverButton()
        {
            PageManager.Show<DriverAddRequestView>(new Driver());
        }

        private void OnBackButton()
        {
            PageManager.ShowLast();
        }

        public void OnDestroy()
        {
            _addStudentButton.onClick.RemoveListener(OnAddStudentButton);
            _addEmployeeButton.onClick.RemoveListener(OnAddEmployeeButton);
            _addDriverButton.onClick.RemoveListener(OnAddDriverButton);
            _backButton.onClick.RemoveListener(OnBackButton);
        }
    }
}