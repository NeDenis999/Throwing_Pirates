namespace Throwing_Boxes
{
    public abstract class DamageSkill : Skill
    {
        public abstract float ActivateResult(float damage, CharacterModel enemy, CharacterModel player);
    }
}