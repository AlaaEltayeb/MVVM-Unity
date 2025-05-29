using System;

namespace MVVM.Unity.PersistentObjects
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PersistentAttribute : Attribute
    {
        public bool ExcludeFromReset { get; }

        public PersistentAttribute(bool excludeFromReset = false)
        {
            ExcludeFromReset = excludeFromReset;
        }
    }
}