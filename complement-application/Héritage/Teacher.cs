namespace Héritage;

public class Teacher : Person
{
    public string Matricule { get; set; }

    public Teacher(string pFirstname, string pLastName, string pMatricule)
        : base(pFirstname, pLastName)
    {
        Matricule = pMatricule;
    }

    public override void DescribeMyself2()
    {
        Console.WriteLine(
            $"[DescribeMyself2 - Teacher] Je suis un professeur qui s'appelle {FirstName} {LastName} " +
            $"(réf.: {Reference}) " +
            $"et je possède le matricule {Matricule}");
    }
}