namespace TypTop.GameEngine
{
    /// <summary>Inherited by components that are updateable</summary>
    public interface IUpdateable
    {
        /// <summary>Updates the component with the specified delta time.</summary>
        /// <param name="deltaTime">The delta time.</param>
        void Update(float deltaTime);
    }
}