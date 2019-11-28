using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BasicGameEngine
{
    public abstract class Game : IEnumerable<Entity>
    {
        public readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        readonly HashSet<Entity> _entities = new HashSet<Entity>();

        public event TextCompositionEventHandler TextInput;

        public const double Width = 1920;
        public const double Height = 1080;

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<Entity> GetEntitiesWithComponent<TComponent>() where TComponent : Component
        {
            foreach (var entity in _entities)
            {
                if (entity.HasComponent<TComponent>())
                {
                    yield return entity;
                }
            }
        }

        public virtual void Update(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.Update(deltaTime);
            }
        }

        public void Draw(DrawingContext drawingContext)
        {
            foreach (Entity entity in _entities)
            {
                entity.Draw(drawingContext);
            }
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void OnTextInput(TextCompositionEventArgs e)
        {
            TextInput?.Invoke(this, e);
        }
    }
}