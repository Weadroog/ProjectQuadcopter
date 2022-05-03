namespace Assets.Scripts
{
    public interface IFactory<T>
    {
        public T GetCreated();
    }
}
