using System.Collections.Generic;
using UnityEngine;

namespace Throwing_Boxes
{
    public enum Status : byte
    {
        Success,
        Failure, 
        Unknown
    }
    
    [CreateAssetMenu(fileName = "Quest", menuName = "Configs/Quest", order = 51)]
    public class Quest : ScriptableObject
    {
        public string Name;
        public List<QuestCondition> SuccessConditions;
        public List<QuestCondition> FailureConditions;

        public Status GetStatus()
        {
            if (SuccessConditions.Count == 0)
                return Status.Unknown;
            
            foreach (var failureCondition in FailureConditions)
            {
                if (failureCondition.IsTrue())
                {
                    return Status.Failure;
                }
            }
            
            foreach (var successCondition in SuccessConditions)
            {
                if (!successCondition.IsTrue())
                {
                    return Status.Unknown;
                }
            }

            return Status.Success;
        }
    }
}