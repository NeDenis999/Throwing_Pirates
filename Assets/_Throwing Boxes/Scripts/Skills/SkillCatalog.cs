using System.Collections.Generic;
using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "SkillCatalog",menuName = "Configs/Skills/Skill Catalog", order = 59)]
    public class SkillCatalog : ScriptableObject
    {
        public List<Skill> Skills;
    }
}