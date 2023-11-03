public class StudentService : IStudentService
{
    IStudentRepository _StudentRepository = new StudentRepository();
    public async Task<string> CreateAsync(string fullName, string group, int average, StudentEducation Studenteducation)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return "Full Name cannot be empty";

        if (string.IsNullOrWhiteSpace(group))
            return "Group cannot be empty";

        if (average <= 0)
            return "Average cannot be less than 0";

        Student student = new Student(fullName, group, average, Studenteducation);
        student.CreateAt = DateTime.UtcNow.AddHours(4);
        await _StudentRepository.CreateAysnc(student);

        return "Created Successfully";
    }

    public async Task GetAllAsync()
    {
        List<Student> students = await _StudentRepository.GetAllAysnc();
        foreach (Student student in students)
        {
            Console.WriteLine($"ID : {student.Id}, Full Name : {student.FullName}, Group : {student.Group}, Average : {student.Average}, Education {student.studentEducation}, Creation Date : {student.CreateAt}, Updated At {student.UpdateAt}");
        }
    }

    public async Task<string> GetAsync(string id)
    {
        Student student = await _StudentRepository.GetAysnc(x => x.Id == id);
        if (student == null)
            return "Student not found";
        Console.WriteLine($"ID : {student.Id}, Full Name : {student.FullName}, Group : {student.Group}, Average : {student.Average}, Education {student.studentEducation}, Creation Date : {student.CreateAt}, Updated At {student.UpdateAt}");
        return "Successfull";
    }

    public async Task<string> RemoveAsync(string id)
    {
        Student student = await _StudentRepository.GetAysnc(x => x.Id == id);
        if (student == null)
            return "Student not found";
        await _StudentRepository.RemoveAysnc(student);
        return "Successfully Removed";

    }

    public async Task<string> UpdateAsync(string id, string fullName, string group, int average, StudentEducation Studenteducation)
    {
        Student student = await _StudentRepository.GetAysnc(x => x.Id == id);
        if (student == null)
            return "Student not found";

        student.FullName = fullName;
        student.Group = group;
        student.Average = average;
        student.studentEducation = Studenteducation;
        student.UpdateAt = DateTime.UtcNow.AddHours(4);
        return "Successfully Updated";
    }
}

