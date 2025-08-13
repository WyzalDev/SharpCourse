// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

namespace Core.UI.Views.HumanRequests.Students
{
    public class StudentEditRequestView : StudentRequestView
    {
        protected override void PerformedAction()
        {
            HumansStorage.EditHuman(_human, _oldName);
        }
    }
}