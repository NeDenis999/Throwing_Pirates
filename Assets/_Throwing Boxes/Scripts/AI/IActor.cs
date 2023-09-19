namespace Throwing_Boxes
{
    public interface IActor
    {
        IFactState ResultState { get; }
        
        IFactState RequiredState { get; }

        bool IsPlaying { get; }

        bool IsValid();
        
        int EvaluateCost();
        
        void Play(Callback callback);

        void Cancel();

        public interface Callback
        {
            void Invoke(IActor action, bool success);
        }
    }
}