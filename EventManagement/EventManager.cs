using System;
using System.Collections.Generic;

namespace LanKuDot.UnityToolBox.EventManagement
{
    public static class EventManager
    {
        private static readonly Dictionary<Type, IEventCallback> _eventCallbacks =
            new Dictionary<Type, IEventCallback>();

        /// <summary>
        /// Add a callback to the event
        /// </summary>
        /// <param name="callback">The callback of the event</param>
        /// <typeparam name="TMsg">The type of the event</typeparam>
        public static void AddListener<TMsg>(Action<TMsg> callback)
            where TMsg : struct
        {
            EventCallback<TMsg> callbacks;

            if (!_eventCallbacks.TryGetValue(typeof(TMsg), out var dictValue)) {
                callbacks = new EventCallback<TMsg>();
                _eventCallbacks[typeof(TMsg)] = callbacks;
            } else
                callbacks = (EventCallback<TMsg>) dictValue;

            callbacks.AddListener(callback);
        }

        /// <summary>
        /// Remove a callback from the event
        /// </summary>
        /// <param name="callback">The callback to be removed</param>
        /// <typeparam name="TMsg">The type of the event</typeparam>
        /// <exception cref="ArgumentException">
        /// Raised if the event type is invalid
        /// </exception>
        public static void RemoveListener<TMsg>(Action<TMsg> callback)
        {
            if (!_eventCallbacks.TryGetValue(typeof(TMsg), out var dictValue)) {
                throw new ArgumentException($"{typeof(TMsg)} is not registered");
            }

            var callbacks = (EventCallback<TMsg>) dictValue;
            callbacks.RemoveListener(callback);
        }

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="msg">The message of the event</param>
        /// <typeparam name="TMsg">The type of the event</typeparam>
        public static void Invoke<TMsg>(TMsg msg)
            where TMsg : struct
        {
            if (!_eventCallbacks.TryGetValue(typeof(TMsg), out var callbacks ))
                throw new ArgumentException($"{nameof(TMsg)} is not registered");

            ((EventCallback<TMsg>) callbacks).Invoke(msg);
        }
    }
}
