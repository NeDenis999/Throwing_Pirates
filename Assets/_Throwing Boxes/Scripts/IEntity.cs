namespace Throwing_Boxes
{
    public interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T element);

        object[] GetAll();
    }
}