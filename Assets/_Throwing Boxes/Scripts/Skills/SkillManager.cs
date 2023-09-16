using UnityEngine;

namespace Throwing_Boxes
{
    public class SkillManager : MonoBehaviour, ISkillManager
    {
        [SerializeField]
        private SkillCatalog _skillCatalog;
        
        public Skill[] GetAllSkills()
        {
            return _skillCatalog.Skills.ToArray();
        }
    }
}