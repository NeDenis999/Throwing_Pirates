using System;
using System.Collections.Generic;

namespace Throwing_Boxes
{
    public static class PlannerFactory
    {
        public static IPlanner CreatePlanner(IEnumerable<IActor> allActions)
        {
            return new AStarPlanner(allActions);
        } 
    }
}