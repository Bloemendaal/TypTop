namespace TypTop.GameEngine
{
    /// <summary>Components are added to give entities extra behaviour</summary>
    public abstract class Component
    {
        private Entity _entity;

        /// <summary>  The entity the components is added to</summary>
        /// <value>The entity.</value>
        public Entity Entity
        {
            get => _entity;
            set
            {
                _entity = value;
                AddedToEntity();
            }
        }

        /// <summary>Callback when added to entity.</summary>
        public virtual void AddedToEntity() { }
    }
}