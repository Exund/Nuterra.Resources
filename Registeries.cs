using System;
using System.Collections.Generic;
using System.Linq;
using Nuterra.Resources.Tag;

namespace Nuterra.Resources.Registery
{
    public abstract class Registery<T>
    {
        protected static List<T> registery;

        public virtual bool Register(T item)
        {
            if (!registery.Contains(item))
            {
                registery.Add(item);
                return true;
            }
            return false;
        }
    }

    public class TypeRegistery<T> : Registery<Type> {
        static readonly Type type = typeof(T);

        public override bool Register(Type item)
        {
            return item.BaseType == type || item == type;
        }
    }

    public class ResourceRegistery : Registery<ResourceType>
    {
        private ResourceRegistery() {}

        public static ResourceRegistery inst => new ResourceRegistery();
    }

    

    public class TagTypeRegistery : TypeRegistery<Tag.Tag>
    {
        private TagTypeRegistery() { }

        public static TagTypeRegistery inst => new TagTypeRegistery();
    }
}
