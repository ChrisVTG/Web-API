namespace POO;

public class Teacher
{
    // all public properties start with uppercase
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Reference { get; set; }
    public string Reference2 => GetReference();

    public string Reference3
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName)
                                                      && FirstName.Length >= 2
                                                      && LastName.Length >= 2)
            {
                return $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
            }

            return string.Empty;
        }
    }

    public List<Course> Courses { get; set; } = new List<Course>();

    public Teacher()
    {
        Courses = new List<Course>();
        Reference = "une valeur par défault";
    }

    public string GetReference()
    {
        if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName)
                                                  && FirstName.Length >= 2
                                                  && LastName.Length >= 2)
        {
            return $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
        }

        return string.Empty;
        // throw new Exception("Nous n'avons pas toutes les informations nécessaires pour calculer une référence");
    }

    public void DescribeMyself(int i)
    {
        Console.WriteLine($"Mon professeur n°{i} s'appelle {FirstName} {LastName} et a le n° de matricule {GetReference()}");
    }
    
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Teacher)
        {
            return ((Teacher)obj).GetReference() == GetReference();
        }
        return false;
    }
}