using System;
using System.Collections.Generic;

namespace LanKuDot.UnityToolBox.EventManagement
{
    public static class EventManager
    {
        private static readonly Dictionary<Type, List<object>> _eventCallbacks =
            new Dictionary<Type, List<object>>();

        /// <summary>
        /// Register a callback to the event
        /// </summary>
        /// <param name="callback">The callback of the event</param>
        /// <typeparam name="TMsg">The type of the event</typeparam>
        public static void Register<TMsg>(Action<TMsg> callback)
            where TMsg : struct
        {
            if (!_eventCallbacks.TryGetValue(typeof(TMsg), out var callbackList)) {
                callbackList = new List<object>();
                _eventCallbacks[typeof(TMsg)] = callbackList;
            }

            callbackList.Add(callback);
        }

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="msg">The message of the event</param>
        /// <typeparam name="TMsg">The type of the event</typeparam>
        public static void Invoke<TMsg>(TMsg msg)
            where TMsg : struct
        {
            if (!_eventCallbacks.TryGetValue(typeof(TMsg), out var callbackList))
                throw new ArgumentException($"{typeof(TMsg)} is not registered");

            foreach (var callback in callbackList) {
                ((Action<TMsg>) callback).Invoke(msg);
            }
        }
    }
}
