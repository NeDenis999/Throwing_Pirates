using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Throwing_Boxes
{
    public class UpgradeConfig : ScriptableObject
    {
        public string Id;
        
        [Range(1, 100)]
        public int MaxLevel;
        public Metadata Metadata;
        public InitialStats InitialStats;
        public PriceTable PriceTable;

        public void InitializeUpgrade()
        {
            
        }
    }

    [Serializable]
    public struct Metadata
    {
        public string Title;
        public Sprite Icon;
    }

    [Serializable]
    public struct InitialStats
    {
        
    }

    [Serializable]
    public struct PriceTable
    {
        public int Value;
        public int BasePowerPrice;
    }
}