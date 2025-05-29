namespace MVVM.Unity.Event
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(EventDelegate<TEvent> action) where TEvent : struct, IEvent;
        void Unsubscribe<TEvent>(EventDelegate<TEvent> action) where TEvent : struct, IEvent;
        void UnsubscribeAll<TEvent>() where TEvent : struct, IEvent;
    }
}