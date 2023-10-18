namespace Static;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalNumber { get; set; }

    // pretty print / beautify / human readable string
    public string GetPrettyPrintedNationalNumber()
    {
        // 11223345684 => 11.22.33-456.84

        if (string.IsNullOrWhiteSpace(NationalNumber))
            return "";

        if (NationalNumber.Length != 11)
            return "";

        if (NationalNumber.Any(x => !char.IsNumber(x)))
            return "";

        return
            $"{NationalNumber.Substring(0, 2)}.{NationalNumber.Substring(2, 2)}.{NationalNumber.Substring(4, 2)}-{NationalNumber.Substring(6, 3)}.{NationalNumber.Substring(9, 2)}";
    }

    // public string GetPrettyPrintedPerson()
    // {
    //     return
    //         $"Cette personne s'appelle {FirstName} {LastName} et a le n° de registre national {NationalNumber.GetPrettyPrintedNationalNumber()}";
    // }
}