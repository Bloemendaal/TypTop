using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace BasicGameEngine
{
    abstract class Entity
    {
        public string Name { get; }
        public Dictionary<Type, Component> Components = new Dictionary<Type, Component>();
        private Game _game;

        protected Entity(string name)
        {
            Name = name;
        }

        public Game Game
        {
            get => _game;
            set
            {
                _game = value;
                AddedToGame();
            }
        }

        protected virtual void AddedToGame()
        {

        }

        public TComponent GetComponent<TComponent>() where TComponent : Component
        {
            return (TComponent)Components[typeof(TComponent)];
        }

        public void AddComponent(Component component)
        {
            Components.Add(component.GetType(), component);
        }

        public virtual void Update(float deltaTime)
        {
            foreach (Component component in Components.Values)
            {
                if (component is IUpdateable updateable)
                {
                    updateable.Update(deltaTime);
                }
            }
        }

        public virtual void Draw(DrawingContext drawingContext)
        {
            foreach (Component component in Components.Values)
            {
                if (component is IDrawable drawable)
                {
                    drawable.Draw(drawingContext);
                }
            }
        }
    }
}