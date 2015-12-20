using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES
{
    public class CESManager
    {
        public readonly List<Entity> Entities = new List<Entity>();
        public readonly Dictionary<Type, object> Systems = new Dictionary<Type, Object>();
        public readonly Dictionary<Type, List<IEntitySystem>> EntitySystemLists = new Dictionary<Type, List<IEntitySystem>>();
        public readonly Dictionary<Type, List<object>> SystemLists = new Dictionary<Type, List<object>>();

        public CESManager()
        {
        }

        public Entity ConstructEntity(params Component[] components) => ConstructEntity(components.ToList());
        public Entity ConstructEntity(List<Component> components)
        {
            var entity = new Entity(this, components);
            AddEntity(entity);
            return entity;
        }

        private void AddEntity(Entity entity)
        {
            Entities.Add(entity);
            foreach (var entitySystemList in EntitySystemLists.Values)
            {
                foreach (var entitySystem in entitySystemList)
                {
                    foreach (var subscribedComponent in entitySystem.SubscribedComponentTypes)
                    {
                        if (entity.Components.ContainsKey(subscribedComponent))
                        {
                            entitySystem.Initialize(entity);
                            break;
                        }
                    }
                }
            }
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);

            foreach (var entitySystemList in EntitySystemLists.Values)
            {
                foreach (var entitySystem in entitySystemList)
                {
                    foreach (var subscribedComponent in entitySystem.SubscribedComponentTypes)
                    {
                        if (entity.Components.ContainsKey(subscribedComponent))
                        {
                            entitySystem.Deconstruct(entity);
                            break;
                        }
                    }
                }
            }
        }

        public void InitializeComponent(Entity entity, Type componentType)
        {
            foreach (var entitySystemList in EntitySystemLists.Values)
            {
                foreach (var entitySystem in entitySystemList)
                {
                    foreach (var subscribedComponent in entitySystem.SubscribedComponentTypes)
                    {
                        if (entity.Components.ContainsKey(subscribedComponent))
                        {
                            entitySystem.Initialize(entity);
                            break;
                        }
                    }
                }
            }
        }

        public void ActivateSystems<T>(Action<T> activate)
        {
            foreach (var system in SystemLists[typeof(T)])
            {
                activate((T)system);
            }
        }

        public void ActivateEntitySystems<T>(Action<T, Entity> activate)
            where T : IEntitySystem
        {
            foreach (var system in EntitySystemLists[typeof(T)])
            {
                foreach (var gameObject in Entities.ToList())
                {
                    foreach (var subscribedComponent in ((T)system).SubscribedComponentTypes)
                    {
                        if (gameObject.Components.ContainsKey(subscribedComponent))
                        {
                            activate((T)system, gameObject);
                        }
                    }
                }
            }
        }

        public void AddSystem(object system)
        {
            Type systemType = system.GetType();
            Systems[systemType] = system;

            if (system is IEntitySystem)
            {
                foreach (Type t in EntitySystemLists.Keys)
                {
                    if (system.GetType().IsAssignableFrom(t))
                    {
                        EntitySystemLists[t].Add((IEntitySystem)system);
                    }
                }
            }

            foreach (Type t in SystemLists.Keys)
            {
                if (system.GetType().IsAssignableFrom(t))
                {
                    SystemLists[t].Add(system);
                }
            }
        }

        public T GetSystem<T>()
        {
            var type = typeof(T);
            if (Systems.ContainsKey(type))
            {
                return (T)Systems[type];
            }
            else
            {
                return default(T);
            }
        }
    }
}
