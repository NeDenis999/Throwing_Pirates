using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class ChangeScore : MonoBehaviour
    {
        [SerializeField]
        private LocalizedString _localizedStringScore;

        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Button _addClickButton;
        
        private int _score;

        private void OnEnable()
        {
            _localizedStringScore.Arguments = new object[] {_score};
            _localizedStringScore.StringChanged += UpdateText;
        }

        private void OnDisable()
        {
            _localizedStringScore.StringChanged -= UpdateText;
        }

        private void Awake()
        {
            _addClickButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    IncreaseScore();
                });
        }

        private void UpdateText(string value)
        {
            _text.text = value;
        }

        private void IncreaseScore()
        {
            _score++;
            _localizedStringScore.Arguments[0] = _score;
            _localizedStringScore.RefreshString();
        }
    }
}