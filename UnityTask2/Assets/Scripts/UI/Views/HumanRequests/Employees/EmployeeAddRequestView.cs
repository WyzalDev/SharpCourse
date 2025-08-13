// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

namespace Core.UI.Views.HumanRequests.Employees
{
    public class EmployeeAddRequestView : EmployeeRequestView
    {
        protected override void PerformedAction()
        {
            HumansStorage.AddHuman(_human);
        }
    }
}