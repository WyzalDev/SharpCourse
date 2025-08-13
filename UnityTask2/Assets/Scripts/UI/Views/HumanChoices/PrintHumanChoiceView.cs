// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using Core.Data;

namespace Core.UI.Views.HumanChoices
{
    public class PrintHumanChoiceView : HumanChoiceView
    {
        protected override void OnChoice(Human human)
        {
            PopupManager.ShowNotification<Popup>(human.ToString());
        }
    }
}