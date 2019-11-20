***REMOVED***
using System.Windows.Media;

namespace BasicGameEngine
***REMOVED***
    abstract class Game
    ***REMOVED***
        readonly Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();

        public void AddEntity(Entity entity)
        ***REMOVED***
            _entities.Add(entity.Name, entity);
    ***REMOVED***

        public virtual void Update(float deltaTime)
        ***REMOVED***
            foreach (Entity entity in _entities.Values)
            ***REMOVED***
                entity.Update(deltaTime);
        ***REMOVED***
    ***REMOVED***

        public void Draw(DrawingContext drawingContext)
        ***REMOVED***
            foreach (Entity entity in _entities.Values)
            ***REMOVED***
                entity.Draw(drawingContext);
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***