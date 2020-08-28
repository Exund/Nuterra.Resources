using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuterra.Resources
{
    class ResourceStore
    {
        Dictionary<Resource, float> resources;
        public List<Tag.Tag> tags;

        public bool ValidateTags(Resource resource)
        {
            var rTags = resource.tags.Where(t => !t.informative);
            if (!rTags.Select(t => t.name).Except(tags.Select(t => t.name)).Any())
            {
                foreach (var rTag in rTags)
                {
                    var tag = tags.First(t => t.name == rTag.name);

                    if(!rTag.Validate(tag))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool TryAdd(Resource resource)
        {
            if(ValidateTags(resource))
            {

                return true;
            }
            return false;
        }
    }
}
