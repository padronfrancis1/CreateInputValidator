using System;

namespace WinApp.PropertyChanged
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class NotifyAttribute : Attribute
    {
    }
}
