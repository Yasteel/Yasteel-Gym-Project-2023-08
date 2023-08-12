namespace GymApp.API.Interfaces
{
    public interface IGenericService<T>
        where T : class
    {
        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(int id);
    }
}
