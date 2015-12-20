using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES
{
    public interface IEntitySystem
    {
        List<Type> SubscribedComponentTypes { get; }
        void Initialize(Entity entity);
        void Deconstruct(Entity entity);
    }
}
