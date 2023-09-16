using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Throwing_Boxes
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Image _frameIcon;

        [SerializeField]
        private Image _blockImage;

        [SerializeField]
        private Sprite _frameSelectSprite;
        
        [SerializeField]
        private Sprite _frameDeselectSprite;
        
        public Button Button;
        
        public void SetFrameIconSelect()
        {
            _frameIcon.sprite = _frameSelectSprite;
        }
        
        public void SetFrameIconDeselect()
        {
            _frameIcon.sprite = _frameDeselectSprite;
        }
        
        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void ShowBlockImage()
        {
            _blockImage.gameObject.SetActive(true);
        }
        
        public void HideBlockImage()
        {
            _blockImage.gameObject.SetActive(false);
        }
    }
}