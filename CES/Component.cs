using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES
{
    public abstract class Component
    {
        static List<Type> requiredComponents = new List<Type>();
        public virtual List<Type> RequiredComponents => requiredComponents;
    }
}
