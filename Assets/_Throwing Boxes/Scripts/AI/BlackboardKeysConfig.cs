using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(
        fileName = "BlackboardKeysConfig",
        menuName = "Configs/AI/Blackboards/BlackboardKeysConfig"
    )]
    public sealed class BlackboardKeysConfig : ScriptableObject
    {
        [SerializeField]
        public string[] names;

        public static BlackboardKeysConfig EditorInstance => 
            Resources.Load<BlackboardKeysConfig>("BlackboardKeysConfig");
    }
}