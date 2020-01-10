using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace TypTop.GameEngine
{
    /// <summary>
    ///   <para>Entities with components form the game objects.</para>
    /// </summary>
    public abstract class Entity
    {
        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

        /// <summary>
        ///   <para>
        ///  De draw depth</para>
        /// </summary>
        public int ZIndex = 0;

        /// <summary>Initializes a new instance of the <see cref="Entity"/> class.</summary>
        /// <param name="minigame">The minigame.</param>
        protected Entity(Game minigame)
        {
            Game = minigame;
        }

        /// <summary>
        ///   <para>
        ///  The game the component is in</para>
        /// </summary>
        /// <value>The game.</value>
        public Game Game { get; }

        /// <summary>Tries to get the component.</summary>
        /// <typeparam name="TComponent">The type of the component.</typeparam>
        /// <param name="component">The component.</param>
        /// <returns></returns>
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

        /// <summary>Gets the component.</summary>
        /// <typeparam name="TComponent">The type of the component.</typeparam>
        /// <remarks>If the component is empty it throws an error</remarks>
        /// <returns></returns>
        public TComponent GetComponent<TComponent>() where TComponent : Component
        {
            return (TComponent)_components[typeof(TComponent)];
        }

        /// <summary>Adds the component.</summary>
        /// <param name="component">The component.</param>
        public void AddComponent(Component component)
        {
            component.Entity = this;
            component.AddedToEntity();
            _components.Add(component.GetType(), component);
        }

        /// <summary>Determines whether the entity has a component.</summary>
        /// <typeparam name="TComponent">The type of the component.</typeparam>
        public bool HasComponent<TComponent>()
        {
            return _components.ContainsKey(typeof(TComponent));
        }

        /// <summary>Updates the components with the specified delta time.</summary>
        /// <param name="deltaTime">The delta time.</param>
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

        /// <summary>Draws the entity.</summary>
        /// <param name="drawingContext">The drawing context.</param>
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