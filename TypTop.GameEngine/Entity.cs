***REMOVED***
***REMOVED***
using System.Windows.Media;

namespace BasicGameEngine
***REMOVED***
    abstract class Entity
    ***REMOVED***
        public string Name ***REMOVED*** get; ***REMOVED***
        public Dictionary<Type, Component> Components = new Dictionary<Type, Component>();
        private Game _game;

        protected Entity(string name)
        ***REMOVED***
            Name = name;
    ***REMOVED***

        public Game Game
        ***REMOVED***
            get => _game;
            set
            ***REMOVED***
                _game = value;
                AddedToGame();
        ***REMOVED***
    ***REMOVED***

        protected virtual void AddedToGame()
        ***REMOVED***

    ***REMOVED***

        public TComponent GetComponent<TComponent>() where TComponent : Component
        ***REMOVED***
            return (TComponent)Components[typeof(TComponent)];
    ***REMOVED***

        public void AddComponent(Component component)
        ***REMOVED***
            Components.Add(component.GetType(), component);
    ***REMOVED***

        public virtual void Update(float deltaTime)
        ***REMOVED***
            foreach (Component component in Components.Values)
            ***REMOVED***
                if (component is IUpdateable updateable)
                ***REMOVED***
                    updateable.Update(deltaTime);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        public virtual void Draw(DrawingContext drawingContext)
        ***REMOVED***
            foreach (Component component in Components.Values)
            ***REMOVED***
                if (component is IDrawable drawable)
                ***REMOVED***
                    drawable.Draw(drawingContext);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***