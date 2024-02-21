namespace TestTask.Data.Interfaces
{
    public interface IRepository<E> where E : class
    {
        Task<E> Get();

        Task<List<E>> GetEntities();

    }
}
