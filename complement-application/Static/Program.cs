// See https://aka.ms/new-console-template for more information

using Static;

Console.WriteLine("Hello, World!");

var person = new Person() { FirstName = "Ludwig", LastName = "Lebrun", NationalNumber = "11223345684" };

// 11223345684 => 11.22.33-456.84
Console.WriteLine(person.GetPrettyPrintedNationalNumber());

var dataFormatter = new DataFormatter();
Console.WriteLine(dataFormatter.GetPrettyPrintedNationalNumber("11223345684"));

Console.WriteLine(DataFormatterStatic.GetPrettyPrintedNationalNumber("11223345684"));
Console.WriteLine("11223345684".GetPrettyPrintedNationalNumber());

Console.WriteLine(person.GetPrettyPrintedPerson());