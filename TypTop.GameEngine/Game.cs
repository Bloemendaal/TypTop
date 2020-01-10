using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.MinigameEngine;

namespace TypTop.GameEngine
{
    public abstract class Game : IEnumerable<Entity>
    {
        /// <summary>The width
        /// of the resolution</summary>
        public const double Width = 1920;
        /// <summary>
        ///   <para>
        ///  The height
        /// of the resolution</para>
        /// </summary>
        public const double Height = 1080;

        private readonly HashSet<ITimed> _timedObjects = new HashSet<ITimed>();
        /// <summary>  Helper for generating random values</summary>
        public readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private HashSet<Entity> _entities = new HashSet<Entity>();

        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Occurs when user presses a key.</summary>
        public event TextCompositionEventHandler TextInput;

        /// <summary>Adds a callback timer.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="interval">The interval.</param>
        /// <returns></returns>
        public ITimer AddTimer(Action callback, int interval)
        {
            var gameTimer = new GameTimer(callback, interval);
            _timedObjects.Add(gameTimer);
            return gameTimer;
        }

        /// <summary>  Adds a delayed action.</summary>
        /// <param name="callback">The callback.</param>
        /// <param name="millisecondsDelay">The milliseconds delay.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public void AddDelayedAction(Action callback, int millisecondsDelay,
            CancellationToken cancellationToken = default)
        {
            _timedObjects.Add(new DelayedAction(callback, millisecondsDelay, cancellationToken));
        }

        private void RunTimedObjects(double deltaTime)
        {
            List<ITimed> removedTimers = null;
            foreach (ITimed timedObject in _timedObjects.ToList())
                if (timedObject.IncrementTime(deltaTime))
                {
                    if (removedTimers == null)
                        removedTimers = new List<ITimed>();

                    removedTimers.Add(timedObject);
                }

            if (removedTimers != null)
                foreach (ITimed removedTimer in removedTimers)
                    _timedObjects.Remove(removedTimer);
        }

        /// <summary>Adds an entity.</summary>
        /// <param name="entity">The entity.</param>
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            _entities = _entities.OrderBy(e => e.ZIndex).ToHashSet();
        }

        /// <summary>Removes the entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool RemoveEntity(Entity entity)
        {
            return _entities.Remove(entity);
        }


        /// <summary>Removes the entity by type.</summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public int RemoveEntity<TEntity>() where TEntity : Entity
        {
            return _entities.RemoveWhere(e => e is TEntity);
        }


        /// <summary>Gets the entities with the specified component.</summary>
        /// <typeparam name="TComponent">The type of the component.</typeparam>
        /// <returns></returns>
        public IEnumerable<Entity> GetEntitiesWithComponent<TComponent>() where TComponent : Component
        {
            foreach (Entity entity in _entities.ToList())
                if (entity.HasComponent<TComponent>())
                    yield return entity;
        }

        /// <summary>Updates the game with the specified delta time.</summary>
        /// <param name="deltaTime">The delta time.</param>
        public virtual void Update(float deltaTime)
        {
            foreach (Entity entity in _entities.ToList()) entity.Update(deltaTime);

            RunTimedObjects(deltaTime);
        }

        /// <summary>Draws the game.</summary>
        /// <param name="drawingContext">The drawing context.</param>
        public void Draw(DrawingContext drawingContext)
        {
            foreach (Entity entity in _entities.ToList()) entity.Draw(drawingContext);
        }

        /// <summary>Raises the <see cref="E:TextInput"/> event.</summary>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        public virtual void OnTextInput(TextCompositionEventArgs e)
        {
            TextInput?.Invoke(this, e);
        }

        /// <summary>
        ///   <para>
        ///  Raises the hover event in all components</para>
        /// </summary>
        /// <param name="point">The point.</param>
        public void OnMouseHover(Point point)
        {
            foreach (Entity entity in GetEntitiesWithComponent<HoverComponent>())
                entity.GetComponent<HoverComponent>().CaptureHover(point);
        }

        /// <summary>  Raises the click event in all components</summary>
        /// <param name="point">The point.</param>
        public void OnMouseDown(Point point)
        {
            foreach (Entity entity in GetEntitiesWithComponent<ClickComponent>())
                entity.GetComponent<ClickComponent>().CaptureClick(point);
        }
    }
}