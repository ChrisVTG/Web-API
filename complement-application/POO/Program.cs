// See https://aka.ms/new-console-template for more information

using POO;

Console.WriteLine("Hello, World!");

var course1 = new Course()
{
    Name = "Complément application"
};

var course2 = new Course();
course2.Name = "Programmation sécurisée";

Course course3 = null;

var teacher = new Teacher();
teacher.LastName = "Lebrun";
teacher.FirstName = "Ludwig";
// Console.WriteLine($"Mon professeur n°1 s'appelle {teacher.FirstName} {teacher.LastName} et a le n° de matricule {teacher.Reference}");
// Console.WriteLine($"Mon professeur n°1 s'appelle {teacher.FirstName} {teacher.LastName} et a le n° de matricule {teacher.GetReference()}");
teacher.DescribeMyself(1);
Console.WriteLine($"Mon professeur n°1 s'appelle {teacher.FirstName} {teacher.LastName} et a le n° de matricule {teacher.Reference2}");
Console.WriteLine($"Mon professeur n°1 s'appelle {teacher.FirstName} {teacher.LastName} et a le n° de matricule {teacher.Reference3}");

var teacher4 = new Teacher();
teacher4.LastName = "Lebrun";
teacher4.FirstName = "Ludwig";
teacher4.DescribeMyself(4);

// check why this doesn't work
if (teacher == teacher4)
{
    Console.WriteLine("Attention doublon de n° matricule détecté 2");
}

if (ReferenceEquals(teacher, teacher4))
{
    Console.WriteLine("Attention doublon de n° matricule détecté 3");
}

if (Equals(teacher, teacher4))
{
    Console.WriteLine("Attention doublon de n° matricule détecté");
}

var teacher2 = new Teacher();
teacher2.FirstName = "Hicham";
teacher2.LastName = "Erradi";
// Console.WriteLine($"Mon professeur n°2 s'appelle {teacher2.FirstName} {teacher2.LastName} et a le n° de matricule {teacher2.Reference}");
teacher2.DescribeMyself(2);
// Console.WriteLine($"Mon professeur n°2 s'appelle {teacher2.FirstName} {teacher2.LastName} et a le n° de matricule {teacher2.GetReference()}");

var teacher3 = new Teacher();
// Console.WriteLine($"Mon professeur n°3 s'appelle {teacher3.FirstName} {teacher3.LastName} et a le n° de matricule {teacher3.GetReference()}");
teacher3.DescribeMyself(3);
Console.WriteLine($"Mon professeur n°3 s'appelle {teacher3.FirstName} {teacher3.LastName} et a le n° de matricule {teacher3.Reference}");

// teacher.Courses = new List<Course>();
// teacher.Courses.Add(course1);
// teacher.Courses.Add(course2);
teacher.Courses = new List<Course> { course1, course2 };

Console.WriteLine("End of program");