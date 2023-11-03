public interface IRepository<T> where T : BaseModels
{
    public Task CreateAysnc(T entity);
    public Task RemoveAysnc(T entity);
    public Task<List<T>> GetAllAysnc();
    public Task<List<T>> GetAllAysnc(Func<T,bool>func);
    public Task<T> GetAysnc(Func<T, bool> func);

}
