namespace TypTop.GameEngine
{
    public abstract class Component
    {
        private Entity _entity;

        public Entity Entity
        {
            get => _entity;
            set
            {
                _entity = value;
                AddedToEntity();
            }
        }

        public virtual void AddedToEntity()
        {
        }
    }
}