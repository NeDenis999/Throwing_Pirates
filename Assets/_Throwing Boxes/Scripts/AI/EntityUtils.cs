using UnityEngine;

namespace Throwing_Boxes
{
    public static class EntityUtils
    {
        public static float Distance(CharacterModel unit, CharacterModel enemy)
        {
            Vector3 unitPosition = unit.transform.position;
            Vector3 enemyPosition = enemy.transform.position;
            float distance = Vector3.Distance(unitPosition, enemyPosition);
            return distance;
        }
    }
}