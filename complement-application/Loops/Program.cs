// See https://aka.ms/new-console-template for more information

using Loops;

Console.WriteLine("Hello, World!");

//PrintForEach();
// PrintForI();
// PrintWhile();
// PrintLinqFunctions();
PrintSkipTake();

void PrintSkipTake()
{
    var integers = new List<int>()
    {
        1,
        45,
        23,
        155,
        355,
        3,
        12
    };

    bool meet23 = false;
    foreach (var integer in integers)
    {
        if (integer == 23)
            meet23 = true;
        if (meet23)
            Console.WriteLine($"[1] {integer}");
    }
    
    // will return 23, 155, 355, 3, 12
    foreach (var integer in integers.SkipWhile(x => x != 23))
        Console.WriteLine($"[2] {integer}");
    
    foreach (var integer in integers)
    {
        if (integer == 23)
            break;
        Console.WriteLine($"[3] {integer}");
    }
    
    foreach (var integer in integers.TakeWhile(x => x != 23))
        Console.WriteLine($"[4] {integer}");
    
    foreach (var integer in integers.Take(3))
        Console.WriteLine($"[5] {integer}");
    
    foreach (var integer in integers.Skip(2))
        Console.WriteLine($"[6] {integer}");
    
    foreach (var integer in integers.Skip(2).Take(1))
        Console.WriteLine($"[7] {integer}");
    
    foreach (var integer in integers.Skip(6).Take(1))
        Console.WriteLine($"[8] {integer}");
    
    foreach (var integer in integers.OrderBy(x => x).Skip(6).Take(1))
        Console.WriteLine($"[9] {integer}");
    
    foreach (var integer in integers.OrderByDescending(x => x).Take(1))
        Console.WriteLine($"[9'] {integer}");
    
    foreach (var integer in integers.OrderDescending().Skip(2))
        Console.WriteLine($"[10] {integer}");
}

void PrintLinqFunctions()
{
    var students = new List<Student>()
    {
        new Student()
        {
            FirstName = "Ludwig",
            LastName = "Lebrun"
        },
        new Student()
        {
            FirstName = "Alain",
            LastName = "Lejuste"
        },
        new Student()
        {
            FirstName = "Alain",
            LastName = "Leblanc"
        },
        new Student()
        {
            FirstName = "Georges",
            LastName = "Legris"
        }
    };

    foreach (var student in students)
    {
        Console.WriteLine($"[1] Étudiant de prénom {student.FirstName} et de nom {student.LastName}");
    }

    // LINQ
    // lambda expression
    foreach (var student in students.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
    {
        Console.WriteLine($"[2] Étudiant de prénom {student.FirstName} et de nom {student.LastName}");
    }

    foreach (var student in students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName))
    {
        Console.WriteLine($"[3] Étudiant de prénom {student.FirstName} et de nom {student.LastName}");
    }

    foreach (var student in students.Where(x => x.FirstName == "Alain"))
    {
        Console.WriteLine($"[4] Étudiant de prénom {student.FirstName} et de nom {student.LastName}");
    }

    foreach (var student in students.Where(x => x.FirstName == "Paul"))
    {
        Console.WriteLine($"[5] Étudiant de prénom {student.FirstName} et de nom {student.LastName}");
    }

    var matchingStudent = students.First(x => x.FirstName == "Alain");
    Console.WriteLine($"[6] Étudiant de prénom {matchingStudent.FirstName} et de nom {matchingStudent.LastName}");

    // will throw exception
    // matchingStudent = students.First(x => x.FirstName == "Paul");
    // Console.WriteLine($"[6] Étudiant de prénom {matchingStudent.FirstName} et de nom {matchingStudent.LastName}");

    // wiil throw exception even if called with FirstOrDefault (which returns a TSource? = nullable object, as TSource? is a Student?)
    // matchingStudent = students.FirstOrDefault(x => x.FirstName == "Paul");
    // Console.WriteLine($"[6] Étudiant de prénom {matchingStudent.FirstName} et de nom {matchingStudent.LastName}");

    matchingStudent = students.FirstOrDefault(x => x.FirstName == "Paul");
    if (matchingStudent != null)
        Console.WriteLine($"[7] Étudiant de prénom {matchingStudent.FirstName} et de nom {matchingStudent.LastName}");

    // will return true
    bool exists = students.Any(x => x.FirstName == "Georges");
    // will return true
    exists = students.Exists(x => x.FirstName == "Georges");
    // will return false
    exists = students.All(x => x.FirstName == "Georges");

    foreach (var student in students)
        Console.WriteLine(student.FirstName);

    var firstNames = new List<string>();
    foreach (var student in students)
        firstNames.Add(student.FirstName);
    
    var linqFirstNames = students.Select(x => x.FirstName).ToList();
}

void PrintWhile()
{
    var integers = new List<int>()
    {
        1,
        45,
        23,
        155,
        355,
        3,
        12
    };

    var i = 0;
    while (i < integers.Count)
    {
        var integer = integers[i];
        Console.WriteLine($"[1] Index {i} = {integer}");
        i++;
    }

    i = 0;
    while (true)
    {
        var integer = integers[i];
        Console.WriteLine($"[2] Index {i} = {integer}");
        i++;

        if (i >= integers.Count)
            break;
    }
}

void PrintForI()
{
    var integers = new List<int>()
    {
        1,
        45,
        23,
        155,
        355,
        3,
        12
    };

    for (int i = 6; i >= 0; i--)
    {
        var integer = integers[i];
        Console.WriteLine($"[1'] Index {i} = {integer}");
    }

    for (int i = 0; i < integers.Count; i++)
        // for (int i = 0; i < 7; i++)
    {
        var integer = integers[i];
        Console.WriteLine($"[1] Index {i} = {integer}");
    }

    for (int i = 0; i <= integers.Count - 1; i++)
        // for (int i = 0; i <= 6; i++)
    {
        var integer = integers[i];
        Console.WriteLine($"[2] Index {i} = {integer}");
    }

    for (int i = 1; i <= 7; i++)
    {
        var integer = integers[i - 1];
        if (integer == 155)
            continue;
        Console.WriteLine($"[3] Index {i - 1} = {integer}");
    }

    for (int i = 1; i < 8; i++)
    {
        var integer = integers[i - 1];
        Console.WriteLine($"[4] Index {i - 1} = {integer}");
        if (integer == 155)
            break;
    }
}

void PrintForEach()
{
    var integers = new List<int>()
    {
        1,
        45,
        23,
        155,
        355,
        3,
        12
    };

    int i = 0;
    foreach (var integer in integers)
    {
        Console.WriteLine($"[1] Index {i} = {integer}");
        i++;
    }

    int y = 0;
    foreach (var integer in integers)
    {
        Console.WriteLine($"[2] Index {y} = {integer}");
        if (integer == 23)
            break;
        // if (y == 2)
        //     break;
        y++;
    }

    int z = 0;
    foreach (var integer in integers)
    {
        if (integer == 23)
            continue;
        Console.WriteLine($"[3] Index {z} = {integer}");
        // if (y == 2)
        //     break;
        y++;
    }
}