using System.Collections.Generic;
using System.Windows.Media;

namespace BasicGameEngine
{
    abstract class Game
    {
        readonly Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity.Name, entity);
        }

        public virtual void Update(float deltaTime)
        {
            foreach (Entity entity in _entities.Values)
            {
                entity.Update(deltaTime);
            }
        }

        public void Draw(DrawingContext drawingContext)
        {
            foreach (Entity entity in _entities.Values)
            {
                entity.Draw(drawingContext);
            }
        }
    }
}