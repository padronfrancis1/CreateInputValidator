using System.Collections.Generic;

namespace WinApp.Events
{
    public class AddItemRequestedEventArgs<T>
    {
    }

    public class OpenItemRequestedEventArgs<T>
    {
        public int ID { get; set; }
    }
    public class OpenListViewEventEventArgs<T>
    {
    }

    public class ValidationEventArgs
    {
        public ValidationEventArgs() { }

        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public string Title { get; set; }
    }
}
