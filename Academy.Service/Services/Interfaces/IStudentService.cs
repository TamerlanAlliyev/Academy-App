public interface IStudentService
{
    public Task<string> CreateAsync(string fullName, string group, int average, StudentEducation Studenteducation);
    public Task<string> UpdateAsync(string id, string fullName, string group, int average, StudentEducation Studenteducation);
    public Task<string> RemoveAsync(string id);
    public Task<string> GetAsync(string id);
    public Task GetAllAsync();
}

