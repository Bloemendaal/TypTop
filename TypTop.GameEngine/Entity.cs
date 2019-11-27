***REMOVED***
***REMOVED***
using System.Windows.Media;

namespace BasicGameEngine
***REMOVED***
    public abstract class Entity
    ***REMOVED***
        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

        protected Entity(Game game)
        ***REMOVED***
            Game = game;
    ***REMOVED***

        public Game Game ***REMOVED*** get; ***REMOVED***

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : Component
        ***REMOVED***
            if (_components.TryGetValue(typeof(TComponent), out var b))
            ***REMOVED***
                component = (TComponent) b;
                return true;
        ***REMOVED***
            component = (TComponent) _components[typeof(TComponent)];
            return false;
    ***REMOVED***

        public TComponent GetComponent<TComponent>() where TComponent : Component
        ***REMOVED***
            return (TComponent)_components[typeof(TComponent)];
    ***REMOVED***

        public void AddComponent(Component component)
        ***REMOVED***
            component.Entity = this;
            component.AddedToEntity();
            _components.Add(component.GetType(), component);
    ***REMOVED***

        public bool HasComponent<TComponent>()
        ***REMOVED***
            return _components.ContainsKey(typeof(TComponent));
    ***REMOVED***

        public virtual void Update(float deltaTime)
        ***REMOVED***
            foreach (Component component in _components.Values)
            ***REMOVED***
                if (component is IUpdateable updateable)
                ***REMOVED***
                    updateable.Update(deltaTime);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        public virtual void Draw(DrawingContext drawingContext)
        ***REMOVED***
            foreach (Component component in _components.Values)
            ***REMOVED***
                if (component is IDrawable drawable)
                ***REMOVED***
                    drawable.Draw(drawingContext);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***