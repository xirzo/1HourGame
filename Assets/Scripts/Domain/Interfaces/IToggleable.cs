using System;

namespace Game.Domain.Interfaces
{
    public interface IToggleable
    {
        event Action<bool> OnToggled;
        bool IsToggled { get; }
        void Toggle();
    }
}
