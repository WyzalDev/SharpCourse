// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Core.UI.Views.HumanChoices;

namespace Core.UI.Views
{
    public class MainView : Page
    {
        [SerializeField] private Button _addInfoButton;
        [SerializeField] private Button _editInfoButton;
        [SerializeField] private Button _deleteInfoButton;
        [SerializeField] private Button _printInfoButton;
        [SerializeField] private Button _printAllInfoButton;

        [SerializeField] private Button _exitButton;

        public override void Initialize()
        {
            _addInfoButton.onClick.AddListener(OnAddInfoButton);
            _editInfoButton.onClick.AddListener(OnEditInfoButton);
            _deleteInfoButton.onClick.AddListener(OnDeleteInfoButton);
            _printInfoButton.onClick.AddListener(OnPrintInfoButton);
            _printAllInfoButton.onClick.AddListener(OnPrintAllInfoButton);

            _exitButton.onClick.AddListener(OnExitButton);
        }

        private void OnAddInfoButton()
        {
            PageManager.Show<InfoTypeChoiceView>();
        }

        private void OnEditInfoButton()
        {
            if (HumansStorage.Count != 0)
                PageManager.Show<EditHumanChoiceView>();
            else
                PopupManager.ShowNotification<Popup>(SystemMessages.NoneEntitiesInCollection);
        }

        private void OnDeleteInfoButton()
        {
            if (HumansStorage.Count != 0)
                PageManager.Show<DeleteHumanChoiceView>();
            else
                PopupManager.ShowNotification<Popup>(SystemMessages.NoneEntitiesInCollection);
        }

        private void OnPrintInfoButton()
        {
            if (HumansStorage.Count != 0)
                PageManager.Show<PrintHumanChoiceView>();
            else
                PopupManager.ShowNotification<Popup>(SystemMessages.NoneEntitiesInCollection);
        }

        private void OnPrintAllInfoButton()
        {
            if (HumansStorage.Count != 0)
            {
                var message = new StringBuilder();
                var humans = HumansStorage.GetHumans();

                for (var i = 0; i < humans.Count; i++)
                    message.AppendLine($"{i + 1}. {humans[i]}\n\r");

                PopupManager.ShowNotification<Popup>(message.ToString());
            }
            else
                PopupManager.ShowNotification<Popup>(SystemMessages.NoneEntitiesInCollection);
        }

        private void OnExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }

        private void OnDestroy()
        {
            _addInfoButton.onClick.RemoveListener(OnAddInfoButton);
            _editInfoButton.onClick.RemoveListener(OnEditInfoButton);
            _deleteInfoButton.onClick.RemoveListener(OnDeleteInfoButton);
            _printInfoButton.onClick.RemoveListener(OnPrintInfoButton);
            _printAllInfoButton.onClick.RemoveListener(OnPrintAllInfoButton);

            _exitButton.onClick.RemoveListener(OnExitButton);
        }
    }
}