namespace Throwing_Boxes
{
    public interface ICondition
    {
        bool IsTrue();
    }

    public interface ICondition<in T>
    {
        bool IsTrue(T value);
    }
}