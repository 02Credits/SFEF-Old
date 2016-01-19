using Artemis;
using System;

namespace Extensions.Artemis
{
    public static class EntityExtensions
    {
        public static void AddComponentFromPool<T>(this Entity entity, Action<T> initialize)
            where T : ComponentPoolable
        {
            T component = entity.AddComponentFromPool<T>();
            initialize(component);
        }
    }
}
