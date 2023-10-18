// See https://aka.ms/new-console-template for more information

using Ensembles;

Console.WriteLine("Hello, World!");

var integers = new List<int>()
{
    1,
    2,
    3
};

// var integers2 = new List<int>();
// integers2.Add(1);
// integers2.Add(2);
// integers2.Add(3);

Console.WriteLine($"[1] {integers[0]}"); // will print 1
Console.WriteLine($"[1] {integers[1]}"); // will print 2
Console.WriteLine($"[1] {integers[2]}"); // will print 3
// will throw an ArgumentOutOfRanngeException
// Console.WriteLine(integers[3]);

for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[2] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

integers.Add(17);
for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[3] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

integers.Insert(1, 484);
for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[4] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

integers.Remove(2);
for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[5] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

integers.RemoveAt(3);
for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[6] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

integers.Add(3);
for (int i = 0; i < integers.Count; i++)
{
    Console.WriteLine($"[6] {integers[i]}");
}

Console.WriteLine($"Ma liste contient {integers.Count} éléments");

var person1 = new Person() { FirstName = "Ludwig", LastName = "Lebrun", NationalNumber = "00112234584" };
var person2 = new Person() { FirstName = "Ludwig", LastName = "Lebrin", NationalNumber = "00112234584" };
var person3 = new Person() { FirstName = "Ludwig", LastName = "Labrune", NationalNumber = "66889934584" };

var persons = new List<Person>() { person1, person2 };

var dico = new Dictionary<string, Person>();
dico.Add("00112234584", person1);
// var dico2 = new Dictionary<string, Person> { { "00112234584", person1 } };
if(!dico.ContainsKey("00112234584"))
    dico.Add("00112234584", person2);
dico.TryAdd("00112234584", person2);
dico.Add("66889934584", person3);
Console.WriteLine($"Mon dictionnaire contient {dico.Keys.Count} clés");

if (dico.ContainsKey("66889934584"))
{
    Console.WriteLine("Mon dictionnaire contient la clé '66889934584'");
    var match = dico["66889934584"];
    Console.WriteLine($"La personne portant le n° de registre national '66889934584' s'appelle {match.FirstName} {match.LastName}");
}