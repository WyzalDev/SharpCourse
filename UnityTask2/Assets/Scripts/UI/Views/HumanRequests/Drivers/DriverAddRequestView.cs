// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

namespace Core.UI.Views.HumanRequests.Drivers
{
    public class DriverAddRequestView : DriverRequestView
    {
        protected override void PerformedAction()
        {
            HumansStorage.AddHuman(_human);
        }
    }
}