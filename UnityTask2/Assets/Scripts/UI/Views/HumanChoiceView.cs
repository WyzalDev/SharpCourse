// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Core.Data;

namespace Core.UI.Views
{
    public abstract class HumanChoiceView : Page
    {
        [SerializeField] private Transform _choicesTransform;
        [SerializeField] private Choice _choicePrefab;

        [SerializeField] private Button _backButton;

        private List<Choice> _choices;
        private List<UnityAction> _actions = new();

        public override void Initialize()
        {
            _backButton.onClick.AddListener(OnBackButton);
            _choices = new List<Choice>();
        }

        public override void Show(object data = null)
        {
            UpdateChoices();
            base.Show(data);
        }

        private void UpdateChoices()
        {
            if (_choices.Count != 0)
            {
                RemoveChoiceListeners();

                foreach (var choice in _choices)
                    Destroy(choice.gameObject);

                _choices.Clear();
            }

            var humans = HumansStorage.GetHumans();

            for (var i = 0; i < humans.Count; i++)
            {
                var choice = Instantiate(_choicePrefab, _choicesTransform);
                choice.Text.text = $"{i}. {humans[i].Name}";
                _choices.Add(choice);

                AddChoiceListener(humans[i], i);
            }
        }

        private void AddChoiceListener(Human human, int currentIndex)
        {
            _actions.Add(() => OnChoice(human));
            _choices[currentIndex].Button.onClick.AddListener(_actions[currentIndex]);
        }

        private void RemoveChoiceListeners()
        {
            for (var i = 0; i < _choices.Count; i++)
                _choices[i].Button.onClick.RemoveListener(_actions[i]);

            _actions.Clear();
        }

        protected abstract void OnChoice(Human human);

        private void OnBackButton()
        {
            PageManager.ShowLast();
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnBackButton);

            RemoveChoiceListeners();
        }
    }
}