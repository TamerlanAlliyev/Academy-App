public class Student : BaseModels
{
    static int _id;
    public string FullName { get; set; }
    public string Group { get; set; }
    public int Average { get; set; }
    public StudentEducation studentEducation { get; set; }
    public Student(string fullName,string group,int average, StudentEducation Studenteducation)
    {
        FullName = fullName;
        Group = group;
        Average = average;
        studentEducation = Studenteducation;
        _id++;
        Id = $"{studentEducation.ToString()[0]}-{_id}";
    }
}

