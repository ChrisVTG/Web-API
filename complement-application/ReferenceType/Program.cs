// See https://aka.ms/new-console-template for more information

using ReferenceType;

Console.WriteLine("Hello, World!");

var cup = new CupOfCoffee();
cup.IsFilled = false;
Console.WriteLine($"Is my cup of coffee filled ? {cup.IsFilled}");
FillCup(cup);
Console.WriteLine($"Is my cup of coffee filled ? {cup.IsFilled}");

// reference type
void FillCup(CupOfCoffee cupOfCoffee)
{
    cupOfCoffee.IsFilled = true;
}

var myNumber = 1;
Console.WriteLine($"My number equals {myNumber}");
IncreaseNumber(myNumber);
Console.WriteLine($"My number equals {myNumber}");

// value type
void IncreaseNumber(int number)
{
    number = number + 1;
}

var myNumber2 = 1;
Console.WriteLine($"My number 2 equals {myNumber2}");
var myNumber3 = IncreaseNumber2(myNumber2);
Console.WriteLine($"My number 2 equals {myNumber2}");
Console.WriteLine($"My number 3 equals {myNumber3}");

// value type
int IncreaseNumber2(int number)
{
    return number + 1;
}