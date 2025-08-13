// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

namespace Core.UI.Views.HumanRequests.Students
{
    public class StudentAddRequestView : StudentRequestView
    {
        protected override void PerformedAction()
        {
            HumansStorage.AddHuman(_human);
        }
    }
}