namespace ShipsInSpace
{
    public interface IFactory <T>
    {
        T GetNewObject();
    }
}
