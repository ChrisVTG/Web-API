namespace Héritage;

public class Teacher2 : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Reference { get; set; }
    public string Test2 { get; set; }

    public void DescribeMyself2()
    {
        throw new NotImplementedException();
    }
}