namespace WebApi.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByid(int id);

        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);


    }
}
