using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace BasicGameEngine
{
    public abstract class Game : IEnumerable<Entity>
    {
        readonly Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity.Name, entity);
        }

        public IEnumerable<Entity> GetEntitiesWithComponent<TComponent>() where TComponent : Component
        {
            foreach (var entity in _entities.Values)
            {
                if (entity.HasComponent<TComponent>())
                {
                    yield return entity;
                }
            }
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

        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}