namespace General
{
    public interface IFactory<T>
    {
        public T GetCreated();
    }
}
