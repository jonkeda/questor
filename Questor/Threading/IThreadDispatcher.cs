using System;

namespace Questor.Threading
{
    public interface IThreadDispatcher
    {
        bool ShouldInvoke();

        void Invoke(Action action);
    }
}