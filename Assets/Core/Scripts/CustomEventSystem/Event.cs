using System;

namespace CustomEventSystem
{
    public class Event
    {
        private event Action action = delegate { };

        public void Invoke() => action.Invoke();

        public void AddListener(Action listener) { action += listener; }

        public void RemoveListener(Action listener) { action -= listener; }
    }

    public class Event<T>
    {
        private event Action<T> action = delegate { };

        public void Invoke(T param) => action.Invoke(param);

        public void AddListener(Action<T> listener) { action += listener; }

        public void RemoveListener(Action<T> listener) { action -= listener; }
    }

    public class Event<T1, T2>
    {
        private event Action<T1, T2> action = delegate { };

        public void Invoke(T1 param1, T2 param2) => action.Invoke(param1, param2);

        public void AddListener(Action<T1, T2> listener) { action += listener; }

        public void RemoveListener(Action<T1, T2> listener) { action -= listener; }
    }

    public class Event<T1, T2, T3>
    {
        private event Action<T1, T2, T3> action = delegate { };

        public void Invoke(T1 param1, T2 param2, T3 param3) => action.Invoke(param1, param2, param3);

        public void AddListener(Action<T1, T2, T3> listener) { action += listener; }

        public void RemoveListener(Action<T1, T2, T3> listener) { action -= listener; }
    }

    public class Event<T1, T2, T3, T4>
    {
        private event Action<T1, T2, T3, T4> action = delegate { };

        public void Invoke(T1 param1, T2 param2, T3 param3, T4 param4) => action.Invoke(param1, param2, param3, param4);

        public void AddListener(Action<T1, T2, T3, T4> listener) { action += listener; }

        public void RemoveListener(Action<T1, T2, T3, T4> listener) { action -= listener; }
    }

    public class Event<T1, T2, T3, T4, T5>
    {
        private event Action<T1, T2, T3, T4, T5> action = delegate { };

        public void Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => action.Invoke(param1, param2, param3, param4, param5);

        public void AddListener(Action<T1, T2, T3, T4, T5> listener) { action += listener; }

        public void RemoveListener(Action<T1, T2, T3, T4, T5> listener) { action -= listener; }
    }
}