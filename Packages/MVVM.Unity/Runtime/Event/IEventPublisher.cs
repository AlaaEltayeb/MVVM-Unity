namespace MVVM.Unity.Event
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(in TEvent sendEvent) where TEvent : struct, IEvent;
    }
}