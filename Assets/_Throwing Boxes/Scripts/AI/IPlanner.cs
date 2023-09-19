using System.Collections.Generic;

namespace Throwing_Boxes
{
    public interface IPlanner
    {
        bool MakePlan(IFactState worldState, IFactState goal, out List<IActor> plan);
    }
}