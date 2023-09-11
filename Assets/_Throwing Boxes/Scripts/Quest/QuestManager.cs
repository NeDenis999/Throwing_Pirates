using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Throwing_Boxes
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField]
        private List<Quest> _activeQuests;

        [SerializeField]
        private TextMeshProUGUI _questInfoText;

        private List<Quest> _completeQuests = new List<Quest>();

        private void Update()
        {
            if (_activeQuests.Count == 0)
                return;

            string condition = "Неизвестное условие";
            
            foreach (var successCondition in _activeQuests[0].SuccessConditions)
            {
                condition = successCondition.GetCondition();
            }
            
            _questInfoText.text = $"{_activeQuests[0].Name} ({condition})\n"
                                  + $"Status: {_activeQuests[0].GetStatus()}\n";
                
            if (_activeQuests[0].GetStatus() == Status.Success)
                CompleteQuest(_activeQuests[0]);
        }

        private void CompleteQuest(Quest quest)
        {
            _activeQuests.Remove(quest);
            _completeQuests.Add(quest);
        }
    }
}