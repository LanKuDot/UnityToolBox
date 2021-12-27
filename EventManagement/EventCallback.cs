using System;

namespace LanKuDot.UnityToolBox.EventManagement
{
    public interface IEventCallback
    {}

    public class EventCallback<TMsg> : IEventCallback
    {
        private event Action<TMsg> _callbacks;

        public void AddListener(Action<TMsg> callback)
        {
            _callbacks += callback;
        }

        public void RemoveListener(Action<TMsg> callback)
        {
            _callbacks -= callback;
        }

        public void Invoke(TMsg msg)
        {
            _callbacks?.Invoke(msg);
        }
    }
}
