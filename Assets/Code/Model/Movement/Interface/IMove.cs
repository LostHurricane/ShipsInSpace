namespace ShipsInSpace
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }

}
