using System;

namespace Throwing_Boxes
{
    public interface IMoneyBank
    {
        event Action<int, int, object> OnMoneyChanged;
        int Money { get; set; }
    }
}