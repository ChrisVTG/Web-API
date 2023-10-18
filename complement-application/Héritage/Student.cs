namespace Héritage;

public class Student : Person
{
    public string CurrentClass { get; set; }
    public string CurrentYear { get; set; }

    public Student(string pFirstName, string pLastName,
        string pCurrentClass, string pCurrentYear) 
        : base(pFirstName, pLastName)
    {
        CurrentClass = pCurrentClass;
        CurrentYear = pCurrentYear;
    }

    public override void DescribeMyself()
    {
        base.DescribeMyself();
        Console.WriteLine(
            $"[DescribeMyself - Student] Je m'appelle {FirstName} {LastName} " +
            $"(réf.: {Reference}), " +
            $"je suis en {CurrentYear}ème année " +
            $"dans la classe {CurrentClass}");
    }

    public override void DescribeMyself2()
    {
        Console.WriteLine(
            $"[DescribeMyself2 - Student] Je m'appelle {FirstName} {LastName} " +
            $"(réf.: {Reference}), " +
            $"je suis en {CurrentYear}ème année " +
            $"dans la classe {CurrentClass}");
    }
}