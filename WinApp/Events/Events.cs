using DomainModel;
using Prism.Events;

namespace WinApp.Events
{
    public class ShowValidationErrorRequestedEvent: PubSubEvent<ValidationEventArgs> { }
    public class AddItemRequestedEvent<T> : PubSubEvent<AddItemRequestedEventArgs<T>> where T : DomainObject { }
    public class OpenItemRequestedEvent<T> : PubSubEvent<OpenItemRequestedEventArgs<T>> where T : DomainObject { }
}
