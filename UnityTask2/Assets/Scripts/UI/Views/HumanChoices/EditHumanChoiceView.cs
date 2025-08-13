// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using Core.Data;
using Core.UI.Views.HumanRequests.Drivers;
using Core.UI.Views.HumanRequests.Employees;
using Core.UI.Views.HumanRequests.Students;

namespace Core.UI.Views.HumanChoices
{
    public class EditHumanChoiceView : HumanChoiceView
    {
        protected override void OnChoice(Human human)
        {
            switch (human)
            {
                case Driver driver:
                    PageManager.Show<DriverEditRequestView>(driver);
                    break;
                case Employee employee:
                    PageManager.Show<EmployeeEditRequestView>(employee);
                    break;
                case Student student:
                    PageManager.Show<StudentEditRequestView>(student);
                    break;
            }
        }
    }
}