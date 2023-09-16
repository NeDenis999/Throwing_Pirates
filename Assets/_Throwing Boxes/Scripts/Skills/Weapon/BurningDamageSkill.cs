using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "BurningDamageSkill",menuName = "Configs/Skills/Burning Damage Skill", order = 62)]
    public class BurningDamageSkill : DamageSkill
    {
        public float DamageMultiplier = 1.5f;

        public override float ActivateResult(float damage, CharacterModel enemy, CharacterModel player)
        {
            if (enemy.IsBurn)
                return damage * DamageMultiplier;

            return damage;
        }
    }
}