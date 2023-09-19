using UnityEngine;

namespace Throwing_Boxes
{
    public class MeleeCombat : MonoBehaviour
    {
        public bool IsCombat { get; set; }

        public void StartCombat(CharacterModel enemy)
        {
            Debug.Log("StartCombat");
            enemy.Damage(1);
        }

        public void StopCombat()
        {
            Debug.Log("StopCombat");
        }
    }
}