// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Data;

namespace Core.UI.Views
{
    public abstract class HumanRequestView : Page
    {
        [Header("Buttons")]
        [SerializeField] private Button _actionButton;
        [SerializeField] private Button _backButton;

        [Header("Input Fields")]
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private TMP_InputField _surNameInputField;
        [SerializeField] private TMP_InputField _patronymicInputField;
        [SerializeField] private TMP_InputField _birthDateInputField;

        protected Human _human;
        protected string _oldName;

        public override void Initialize()
        {
            _backButton.onClick.AddListener(OnBackButton);
            _actionButton.onClick.AddListener(OnActionButton);

            RestoreToDefault();
            BuildInputFieldsFromHuman(_human);
        }

        public override void Show(object data = null)
        {
            base.Show(data);

            if (data is Human human)
                BuildInputFieldsFromHuman(human);
        }

        private void OnActionButton()
        {
            BuildHumanFromInputFields();
            PerformedAction();
            OnBackButton();
            PopupManager.ShowNotification<Popup>(_human.ToString());
            RestoreToDefault();
        }

        protected virtual void BuildHumanFromInputFields()
        {
            _human.Name = _nameInputField.text;
            _human.Surname = _surNameInputField.text;
            _human.Patronymic = _patronymicInputField.text;
            _human.BirthDate = DateTime.Parse(_birthDateInputField.text);
        }

        protected virtual void BuildInputFieldsFromHuman(Human human)
        {
            _human = human;
            _oldName = _human.Name;

            _nameInputField.text = _human.Name;
            _surNameInputField.text = _human.Surname;
            _patronymicInputField.text = _human.Patronymic;
            _birthDateInputField.text = _human.BirthDate.ToString("d");
        }

        protected abstract void PerformedAction();

        protected void OnBackButton()
        {
            PageManager.ShowLast();
        }

        protected abstract void RestoreToDefault();

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnBackButton);
            _actionButton.onClick.RemoveListener(OnActionButton);
        }
    }
}