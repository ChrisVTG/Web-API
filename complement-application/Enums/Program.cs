// See https://aka.ms/new-console-template for more information

using Enums;

Console.WriteLine("Hello, World!");

var availableStatuses = new List<string>()
{
    "Nouveau statut qui se rajoute en cours de développement",
    "Dossier d'inscription en cours de complétion",
    "Dossier d'inscription en cours de completion",
    "Dossier d'inscription en cour de complétion",
    "Dossier d'inscription entièrement complété",
    "Dossier d'inscription en cours d'analyse",
    "Dossier d'inscription validé",
    "Dossier d'inscription refusé",
    "Dossier d'inscription en attente d'un complément d'information",
    "Dossier d'inscription abandonné"
};

var fullyCompleted = availableStatuses[3];
Console.WriteLine(fullyCompleted);
// Print: Dossier d'inscription entièrement complété

// then, we add a new status in our app, "Nouveau statut qui se rajoute en cours de développement"
fullyCompleted = availableStatuses[3];
Console.WriteLine(fullyCompleted);
// Now, "Dossier d'inscription en cour de complétion" is printed instead of "Dossier d'inscription entièrement complété"

var validated = RegistrationFileStatus.Validated;
Console.WriteLine(validated);

var availableColors = new List<string>()
{
    "Rouge, Jaune, Vert",
    "Jaune, Vert, Rouge",
    "Vert, Rouge, Jaune"
};

for (int i = 0; i <= 15; i++)
{
    Console.WriteLine($"[{i}] {(ColorEnum)i:G}");
}

var red = ColorEnum.Red;
Console.WriteLine(red);

var greenYellowBlack = ColorEnum.Green | ColorEnum.Yellow | ColorEnum.Black;
Console.WriteLine(greenYellowBlack);

if (greenYellowBlack.HasFlag(ColorEnum.Yellow))
    Console.WriteLine("Mon élément contient du jaune");
    
if (greenYellowBlack.HasFlag(ColorEnum.Red))
    Console.WriteLine("Mon élément contient du rouge");
    
if (greenYellowBlack.HasFlag(ColorEnum.Yellow) && greenYellowBlack.HasFlag(ColorEnum.Green))
    Console.WriteLine("Mon élément contient du jaune et du vert");