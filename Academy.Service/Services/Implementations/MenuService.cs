namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        IStudentService studentService = new StudentService();
        public async Task RunApp()
        {
            await Menu();
            string request = Console.ReadLine();

            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveStudent();
                        break;
                    case "4":
                        await GetAllStudent();
                        break;
                    case "5":
                        await GetById();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose Right");
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }

        async Task CreateStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Add Full Name");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add Group");
            string Group = Console.ReadLine();
            Console.WriteLine("Add Average");
            int.TryParse(Console.ReadLine(), out int Average);
            int i = 1;
            Console.WriteLine("Educational Options");
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine(item);
                i++;
            }

            bool IsExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add Student Education");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)EnumIndex);
            }
            while (!IsExsist);

            string result = await studentService.CreateAsync(FullName, Group, Average, (StudentEducation)EnumIndex);
            Console.WriteLine(result);
        }

        async Task UpdateStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Add ID");
            string Id = Console.ReadLine();
            Console.WriteLine("Add Full Name");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add Group");
            string Group = Console.ReadLine();
            Console.WriteLine("Add Average");
            int.TryParse(Console.ReadLine(), out int Average);
            int i = 1;
            Console.WriteLine("Educational Options");
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine(item);
                i++;
            }

            bool IsExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add Student Education");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)EnumIndex);
            }
            while (!IsExsist);

            string result = await studentService.UpdateAsync(Id, FullName, Group, Average, (StudentEducation)EnumIndex);
            Console.WriteLine(result);
        }

        async Task RemoveStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Add ID");
            string Id = Console.ReadLine();
            string result = await studentService.RemoveAsync(Id);
            Console.WriteLine(result);

        }

        async Task GetAllStudent()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            await studentService.GetAllAsync();
        }

        async Task GetById()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Add ID");
            string Id = Console.ReadLine();
            string result =await studentService.GetAsync(Id);
            Console.WriteLine(result);
        }

        async Task Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Remove");
            Console.WriteLine("4.Get All");
            Console.WriteLine("5.Get");
            Console.WriteLine("0.Close");
        }
    }
}
