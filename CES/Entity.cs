using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES
{
    public class Entity
    {
        public readonly CESManager manager;
        public Dictionary<Type, Component> Components { get; set; }

        internal Entity(CESManager manager, params Component[] components)
        {
            this.manager = manager;
            Initialize(components.ToList());
        }

        internal Entity(CESManager manager, List<Component> components)
        {
            this.manager = manager;
            Initialize(components);
        }

        internal void Initialize(List<Component> components)
        {
            Components = new Dictionary<Type, Component>();

            foreach (var component in components)
            {
                var type = component.GetType();
                foreach (var requirement in component.RequiredComponents)
                {
                    if (!Components.ContainsKey(requirement))
                        throw new ArgumentException(type.Name + " requires " + requirement.Name);
                }

                Components[type] = component;
            }
        }

        public bool HasComponent<T>()
        {
            var type = typeof(T);
            return Components.ContainsKey(type);
        }

        public T GetComponent<T>()
            where T : Component
        {
            var type = typeof(T);
            if (Components.ContainsKey(type))
            {
                return (T)Components[type];
            }
            else
            {
                return null;
            }
        }

        public void AddComponent<T>(T component)
            where T : Component
        {
            var type = component.GetType();

            foreach (var requirement in component.RequiredComponents)
            {
                if (!Components.ContainsKey(requirement))
                    throw new ArgumentException(type.Name + " requires " + requirement.Name);
            }

            Components[type] = component;

            manager.InitializeComponent(this, type);
        }

        public void AddComponents(params Component[] components) => AddComponents(components.ToList());
        public void AddComponents(List<Component> components)
        {
            foreach (var component in components)
            {
                var type = component.GetType();
                foreach (var requirement in component.RequiredComponents)
                {
                    if (!Components.ContainsKey(requirement))
                        throw new ArgumentException(type.Name + " requires " + requirement.Name);
                }

                Components[type] = component;

                manager.InitializeComponent(this, type);
            }
        }
    }
}
