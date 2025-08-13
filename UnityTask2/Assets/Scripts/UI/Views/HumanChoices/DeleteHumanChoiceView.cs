// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using Core.Data;

namespace Core.UI.Views.HumanChoices
{
    public class DeleteHumanChoiceView : HumanChoiceView
    {
        protected override void OnChoice(Human human)
        {
            HumansStorage.RemoveHuman(human.Name);
            PageManager.ShowLast();
            PopupManager.ShowNotification<Popup>($"DELETED HUMAN:\n\r{human}");
        }
    }
}