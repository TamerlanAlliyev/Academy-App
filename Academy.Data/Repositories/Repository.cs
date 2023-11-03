public class Repository<T> : IRepository<T> where T : BaseModels
{
    List<T> values = new List<T>();
    public async Task CreateAysnc(T entity)
    {
        values.Add(entity);
    }

    public async Task<List<T>> GetAllAysnc()
    {
        return values;
    }

    public async Task<List<T>> GetAllAysnc(Func<T, bool> func)
    {
        return values.Where(func).ToList();
    }

    public async Task<T> GetAysnc(Func<T, bool> func)
    {
        return values.FirstOrDefault(func);
    }

    public async Task RemoveAysnc(T entity)
    {
        values.Remove(entity);
    }
}

