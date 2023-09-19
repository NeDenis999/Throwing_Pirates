namespace Throwing_Boxes
{
    public interface IGoal
    {
        IFactState ResultState { get; }

        bool IsValid();
        
        int EvaluatePriority();
    }
}