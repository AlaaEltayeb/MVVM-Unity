using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace MVVM.Unity.Event
{
    [UsedImplicitly]
    public sealed class EventSystem : IEventSystem
    {
        private readonly Dictionary<Type, List<object>> _handlersAction = new();

        public void Subscribe<TEvent>(EventDelegate<TEvent> action) where TEvent : struct, IEvent
        {
            var type = typeof(TEvent);

            if (!_handlersAction.ContainsKey(type))
                _handlersAction.Add(type, new List<object>());

            _handlersAction[type].Add(action);
        }

        public void Unsubscribe<TEvent>(EventDelegate<TEvent> action) where TEvent : struct, IEvent
        {
            if (!_handlersAction.TryGetValue(typeof(TEvent), out var actions))
                return;

            actions.Remove(action);

            if (actions.Count == 0)
                UnsubscribeAll<TEvent>();
        }

        public void UnsubscribeAll<TEvent>() where TEvent : struct, IEvent
        {
            if (!_handlersAction.ContainsKey(typeof(TEvent)))
                return;

            _handlersAction.Remove(typeof(TEvent));
        }

        public void Publish<TEvent>(in TEvent sendEvent) where TEvent : struct, IEvent
        {
            if (!_handlersAction.TryGetValue(typeof(TEvent), out var actions))
                return;

            foreach (EventDelegate<TEvent> action in actions)
            {
                action(sendEvent);
            }
        }
    }
}