using UnityEngine;

namespace Throwing_Boxes
{
    public class RandomizeAttribute : PropertyAttribute
    {
        public readonly float MinValue;
        public readonly float MaxValue;

        public RandomizeAttribute(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}