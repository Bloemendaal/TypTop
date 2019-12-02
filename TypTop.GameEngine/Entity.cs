﻿using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace TypTop.GameEngine
{
    public abstract class Entity
    {
        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

        public int ZIndex = 0;

        protected Entity(Game game)
        {
            Game = game;
        }

        public Game Game { get; }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : Component
        {
            if (_components.TryGetValue(typeof(TComponent), out var b))
            {
                component = (TComponent) b;
                return true;
            }
            component = (TComponent) _components[typeof(TComponent)];
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : Component
        {
            return (TComponent)_components[typeof(TComponent)];
        }

        public void AddComponent(Component component)
        {
            component.Entity = this;
            component.AddedToEntity();
            _components.Add(component.GetType(), component);
        }

        public bool HasComponent<TComponent>()
        {
            return _components.ContainsKey(typeof(TComponent));
        }

        public virtual void Update(float deltaTime)
        {
            foreach (Component component in _components.Values)
            {
                if (component is IUpdateable updateable)
                {
                    updateable.Update(deltaTime);
                }
            }
        }

        public virtual void Draw(DrawingContext drawingContext)
        {
            foreach (Component component in _components.Values)
            {
                if (component is IDrawable drawable && !drawable.Hidden)
                {
                    drawable.Draw(drawingContext);
                }
            }
        }
    }
}