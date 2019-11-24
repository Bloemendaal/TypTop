using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace BasicGameEngine
{
    public abstract class Game : IEnumerable<Entity>
    {
        public readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        readonly Dictionary<string, Entity> _entities = new Dictionary<string, Entity>();

        public double Width
        {
            get => _width;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value != _width)
                {
                    Resize();
                }

                _width = value;
            }
        }
        private double _width;
        public double Height
        {
            get => _height;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value != _height)
                {
                    Resize();
                }

                _height = value;
            }
        }
        private double _height;

        public bool Relative
        {
            get => _relative;
            set
            {
                if (value != _relative)
                {
                    Resize();
                }

                _relative = value;
            }
        }
        private bool _relative;

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

        public void Resize()
        {
            foreach (Entity entity in _entities.Values)
            {
                entity.Resize();
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