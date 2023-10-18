// See https://aka.ms/new-console-template for more information

using Héritage;

Console.WriteLine("Hello, World!");

// var person = new Person();

// var teacher2 = new Teacher();
var teacher = new Teacher("Ludwig", "Lebrun", "MAT23");
// teacher.FirstName = "Ludwig";
// teacher.LastName = "Lebrun";
// teacher.Matricule = "MAT23";
teacher.DescribeMyself();
teacher.DescribeMyself2();

var teacher2 = new Teacher("Louis", "Leblanc", "MAT48");
teacher2.DescribeMyself();
teacher2.DescribeMyself2();

// var student2 = new Student();
var student = new Student("Georges", "Legris", "MA3", "3");
// student.FirstName = "Ludwig";
// student.LastName = "Lebrun";
// student.CurrentClass = "MA3";
// student.CurrentYear = "3";
student.DescribeMyself();
student.DescribeMyself2();

// TODO: recreate project
// Console.WriteLine($"=== Polymorphisme ===");
//
// var persons = new List<Person>()
// {
//     teacher,
//     student
// };

// foreach (Person person in persons)
// {
//     // ((Person) person).DescribeMyself();
// }