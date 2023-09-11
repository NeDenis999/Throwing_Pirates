using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class LocaleSelector : MonoBehaviour
    {
        private const int RusNumber = 1;
        private const int EngNumber = 0;
        private const string LanguageKey = "Language";
        
        [SerializeField]
        private Button _rusLocateButton;
        
        [SerializeField]
        private Button _engLocateButton;
        
        private bool _isActive;

        private void Awake()
        {
            _rusLocateButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    ChangeLocate(RusNumber);
                });
            
            _engLocateButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    ChangeLocate(EngNumber);
                });
        }

        private void Start()
        {
            int locateId = PlayerPrefs.GetInt(LanguageKey, 0);
            ChangeLocate(locateId);
        }

        public async void ChangeLocate(int locateID)
        {
            _isActive = false;
            await LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[locateID];
            PlayerPrefs.SetInt(LanguageKey, locateID);
            _isActive = true;
        }
    }
}