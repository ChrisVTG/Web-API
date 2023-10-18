// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.WriteLine("Appuyez sur une touche");
var userKey = Console.ReadKey();

if (userKey.KeyChar == '1')
{
    // condition exécutée si  l'utilisateur a cliqué sur 1
}
else
{
    if (userKey.KeyChar == '2')
    {
        // condition exécutée si  l'utilisateur a cliqué sur 2
    }
    else
    {
        if (userKey.KeyChar == '3')
        {
            // condition exécutée si  l'utilisateur a cliqué sur 3
        }
        else
        {
            // condition exécutée si l'utilisateur a cliqué sur autre chose que 1, 2, et 3
        }
    }
}

if (userKey.KeyChar == '1')
{
    // condition exécutée si  l'utilisateur a cliqué sur 1
}
else if (userKey.KeyChar == '2')
{
    // condition exécutée si  l'utilisateur a cliqué sur 2
}
else if (userKey.KeyChar == '3')
{
    // condition exécutée si  l'utilisateur a cliqué sur 3
}
else
{
    // condition exécutée si l'utilisateur a cliqué sur autre chose que 1, 2, et 3
}

switch (userKey.KeyChar)
{
    case '1':
        // condition exécutée si  l'utilisateur a cliqué sur 1
        break;
    case '2':
        // condition exécutée si  l'utilisateur a cliqué sur 2
        break;
    case '3':
        // condition exécutée si  l'utilisateur a cliqué sur 3
        break;
    default:
        // condition exécutée si l'utilisateur a cliqué sur autre chose que 1, 2, et 3
        break;
}

switch (userKey.KeyChar)
{
    case '1':
    case '2':
    case '3':
        // condition exécutée si  l'utilisateur a cliqué sur 1, 2 ou 3
        break;
    default:
        // condition exécutée si l'utilisateur a cliqué sur autre chose que 1, 2, et 3
        break;
}

switch (userKey.KeyChar)
{
    case '1':
    case '2':
        // condition exécutée si  l'utilisateur a cliqué sur 1 ou 2
        break;
    case '3':
        // condition exécutée si  l'utilisateur a cliqué sur 3
        break;
    default:
        // condition exécutée si l'utilisateur a cliqué sur autre chose que 1, 2, et 3
        break;
}

if (userKey.KeyChar == '1')
{
    Console.WriteLine("Vous avez cliqué sur la touche 1");
}
else
{
    Console.WriteLine("Vous avez cliqué sur une touche autre que 1");
}

if (userKey.KeyChar == '1')
    Console.WriteLine("Vous avez cliqué sur la touche 1");
else
    Console.WriteLine("Vous avez cliqué sur une touche autre que 1");

Console.WriteLine(userKey.KeyChar == '1'
    ? "Vous avez cliqué sur la touche 1"
    : "Vous avez cliqué sur une touche autre que 1");

Console.WriteLine(userKey.KeyChar == '1'
    ? "Vous avez cliqué sur la touche 1"
    : userKey.KeyChar == '2'
        ? "Vous avez cliqué sur la touche 2"
        : userKey.KeyChar == '3'
            ? "Vous avez cliqué sur la touche 3"
            : "Vous avez cliqué sur une touche autre que 1, 2 ou 3");