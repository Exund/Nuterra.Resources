using System;
using System.Collections.Generic;
using Nuterra.Resources.Tag;

namespace Nuterra.Resources
{
    public class ResourceType
    {
        public string name;
        public List<Tag.Tag> tags;
    }

    public class Resource
    {
        public ResourceType type;
        public List<Tag.Tag> tags;
        public float amount;
    }
}
