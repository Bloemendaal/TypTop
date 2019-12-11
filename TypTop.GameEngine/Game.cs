﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.MinigameEngine;

namespace TypTop.GameEngine
{
    public abstract class Game : IEnumerable<Entity>
    {
        public readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        HashSet<Entity> _entities = new HashSet<Entity>();
        HashSet<Entity> _removeEntities = new HashSet<Entity>();

        public event TextCompositionEventHandler TextInput;

        public const double Width = 1920;
        public const double Height = 1080;

        private readonly HashSet<ITimed> _timedObjects = new HashSet<ITimed>();

        public ITimer AddTimer(Action callback, int interval)
        {
            var gameTimer = new GameTimer(callback, interval);
            _timedObjects.Add(gameTimer);
            return gameTimer;
        }

        public void AddDelayedAction(Action callback, int millisecondsDelay, CancellationToken cancellationToken = default)
        {
            _timedObjects.Add(new DelayedAction(callback, millisecondsDelay, cancellationToken));
        }

        private void RunTimedObjects(double deltaTime)
        {
            List<ITimed> removedTimers = null;
            foreach (ITimed timedObject in _timedObjects.ToList())
            {
                if (timedObject.IncrementTime(deltaTime))
                {
                    if(removedTimers == null)
                        removedTimers = new List<ITimed>();

                    removedTimers.Add(timedObject);
                }
            }
            if (removedTimers != null)
            {
                foreach (ITimed removedTimer in removedTimers)
                {
                    _timedObjects.Remove(removedTimer);
                }
            }
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            _entities = _entities.OrderBy(e => e.ZIndex).ToHashSet();
        }

        public void RemoveEntity(Entity entity)
        {
            _removeEntities.Add(entity);
        }
        public void RemoveEntity<TEntity>() where TEntity : Entity
        {
            foreach (Entity entity in _entities.Where(e => e is TEntity))
            {
                _removeEntities.Add(entity);
            }
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

            foreach (Entity entity in _removeEntities)
            {
                _entities.Remove(entity);
            }
            _removeEntities.Clear();

            RunTimedObjects(deltaTime);
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

        public void OnMouseDown(Point point)
        {
            foreach (Entity entity in GetEntitiesWithComponent<ClickComponent>())
            {
                entity.GetComponent<ClickComponent>().CaptureClick(point);
            }
        }
    }
}