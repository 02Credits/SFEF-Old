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

        public static void AddComponentFromPool<T1, T2>(this Entity entity, Action<T1, T2> initialize)
            where T1 : ComponentPoolable
            where T2 : ComponentPoolable
        {
            T1 component1 = entity.AddComponentFromPool<T1>();
            T2 component2 = entity.AddComponentFromPool<T2>();
            initialize(component1, component2);
        }

        public static void AddComponentFromPool<T1, T2, T3>(this Entity entity, Action<T1, T2, T3> initialize)
            where T1 : ComponentPoolable
            where T2 : ComponentPoolable
            where T3 : ComponentPoolable
        {
            T1 component1 = entity.AddComponentFromPool<T1>();
            T2 component2 = entity.AddComponentFromPool<T2>();
            T3 component3 = entity.AddComponentFromPool<T3>();
            initialize(component1, component2, component3);
        }


        public static void AddComponentFromPool<T1, T2, T3, T4>(this Entity entity, Action<T1, T2, T3, T4> initialize)
            where T1 : ComponentPoolable
            where T2 : ComponentPoolable
            where T3 : ComponentPoolable
            where T4 : ComponentPoolable
        {
            T1 component1 = entity.AddComponentFromPool<T1>();
            T2 component2 = entity.AddComponentFromPool<T2>();
            T3 component3 = entity.AddComponentFromPool<T3>();
            T4 component4 = entity.AddComponentFromPool<T4>();
            initialize(component1, component2, component3, component4);
        }


        public static void AddComponentFromPool<T1, T2, T3, T4, T5>(this Entity entity, Action<T1, T2, T3, T4, T5> initialize)
            where T1 : ComponentPoolable
            where T2 : ComponentPoolable
            where T3 : ComponentPoolable
            where T4 : ComponentPoolable
            where T5 : ComponentPoolable
        {
            T1 component1 = entity.AddComponentFromPool<T1>();
            T2 component2 = entity.AddComponentFromPool<T2>();
            T3 component3 = entity.AddComponentFromPool<T3>();
            T4 component4 = entity.AddComponentFromPool<T4>();
            T5 component5 = entity.AddComponentFromPool<T5>();
            initialize(component1, component2, component3, component4, component5);
        }
    }
}
