using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AspectCacheAttribute : Attribute
    {
        private string Name { get; set; }

        public AspectCacheAttribute(string name)
        {
            Name = name;
        }
    }
}
