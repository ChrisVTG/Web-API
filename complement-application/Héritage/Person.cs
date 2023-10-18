namespace Héritage;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Reference { get; set; }

    protected Person(string pFirstName, string pLastName)
    {
        FirstName = pFirstName;
        LastName = pLastName;
        Reference = $"{pFirstName.Substring(0, 2)}{pLastName.Substring(0, 2)}";
    }

    public virtual void DescribeMyself()
    {
        Console.WriteLine(
            $"[DescribeMyself - Person] Je m'appelle {FirstName} {LastName} " +
            $"(réf.: {Reference}) ");
    }
    
    public abstract void DescribeMyself2();
}