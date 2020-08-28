using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuterra.Resources.Tag
{
    public class Tag
    {
        public string name;
        public object value;
        public bool informative;

        public Tag(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        public virtual bool Validate(Tag tag) { return true; }
    }

    public class BoundedTag : Tag
    {
        public float min = float.MinValue;
        public float max = float.MaxValue;

        public BoundedTag(string name, object value, float min, float max) : base(name, value)
        {
            this.min = min;
            this.max = max;
            informative = false;
        }

        public override bool Validate(Tag tag)
        {
            if(tag.value is float || tag.value is int)
            {
                var value = (float)tag.value;

                return value >= min && value <= max;
            }

            return false;
        }
    }
}
