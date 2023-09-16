using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "LittleHealthDamageSkill",menuName = "Configs/Skills/Little Health Damage Skill", order = 63)]
    public class LittleHealthDamageSkill : DamageSkill
    {
        public float Damage = 4;
        
        public override float ActivateResult(float damage, CharacterModel enemy, CharacterModel player)
        {
            if (player.GetHealth < 10)
                return damage + Damage;

            return damage;
        }
    }
}