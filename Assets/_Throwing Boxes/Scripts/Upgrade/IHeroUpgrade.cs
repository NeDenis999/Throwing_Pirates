using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public interface IHeroUpgrade
    {
        event Action<int> OnLevelUp;
        
        string Id { get; }
        
        int Level { get; }
        
        int MaxLevel { get; }
        
        int NextPrice { get; }
        
        string Title { get; }
        
        string CurrentStatus { get; }
        
        string NextImprovement { get; }
        
        Sprite Icon { get; }

        void Setup(int level);
        void IncrementLevel();
        bool IsMaxLevel() => Level >= MaxLevel;
    }
}