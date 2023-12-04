// zakladni datove typy
using System.ComponentModel.Design;


// simple poznamka

/*
 * viceradkova
 * poznamka
 */

/*
int test = 0;

if (test == 0)
{

    char charakter = 's';
    string slovo = "slovo";
    int cislo = 0;
    double desetine = 0;   // vypsalo by "0.0";
    float desetine2 = 0;
    const double pi = 3.14;

    cislo = 1;
    //pi = 5;

    if ((cislo == 1) || (cislo == 2))
    {
        // to do
    }
    else if (cislo == 3)
    {

    }
    else { }

    /*
     * kamen - 0
     * nuzky - 1
     * papir - 2
    */


/*
string enemy;
string input;
*/
/*
int number;
Console.WriteLine("Zadej cislo: ");
while (Int32.TryParse(Console.ReadLine(), out number)) { Console.Clear(); }

Console.WriteLine($"Zadal jsi cislo {number}");
Console.ReadLine();


string input;
string enemy;
string[] tahy = { "k", "n", "p" };
Random random = new Random();


Console.Clear();
Console.Write("Vase volba -> ");
input = Console.ReadLine();
random.Next(0, 3);
enemy = tahy[random.Next(0, 3)];
Console.Clear();

if (input == "k")
{
    switch (enemy)
    {
        case "k":
            Console.WriteLine("Výhra!");
            break;

        case "n":
            Console.WriteLine("Remíza.");
            break;

        case "p":
            Console.WriteLine("Prohra.");
            break;
        default: Console.WriteLine("error"); break;
    }
}
else if (input == "n")
{
    switch (input = "p")
    {
        case "k":
            Console.WriteLine("Výhra!");
            break;

        case "n":
            Console.WriteLine("Remíza.");
            break;

        case "p":
            Console.WriteLine("Prohra.");
            break;
        default: Console.WriteLine("error"); break;
    }
}

Console.WriteLine($"Uzivatel dal {input} a oponent {enemy}");
Console.WriteLine("Stiskni cokoliv aby jsi hru zavřel.");
}
*/
/*
// 1
string name;
int age;
int year = 2023;
int birth_year;

Console.Clear();
Console.Write("Zadejte jméno -> ");
name = Console.ReadLine();

Console.Write("Zadejte věk -> ");
while (Int32.TryParse(Console.ReadLine(), out age))

Console.Write($"{name}, narodil(a) jsi se v roce {year - age}");

// 3
Random rnd = new Random();
int nahoda = rnd.Next(0, 100);
int guess;

Console.Clear();
Console.Write("Hádejte číslo 1-100 -> ");
while (Int32.TryParse(Console.ReadLine(), out guess)) ;

if (nahoda == guess)
{
    Console.WriteLine($"Správně! Číslo bylo: {nahoda}");
}
else
{
    Console.WriteLine($"Bohužel.. číslo bylo: {nahoda}");
}


// 4
static void cisla()
{

    Console.Write("Zadej číslo -> ");
    int cislo = int.Parse(Console.ReadLine());

    if (cislo % 2 == 0)
    {
        Console.WriteLine("Zadané číslo je sudé.");
    }
    else
    {
        Console.WriteLine("Zadané číslo je liché.");
    }
}
cisla();
*/
// 5
static void prvocislo()
{   
    Console.Write("Zadej číslo -> ");
    int cislo = int.Parse(Console.ReadLine());

    if (prime_num(cislo))
    {
        Console.WriteLine($"{cislo} je prvočíslo.");
    }
    else
    {
        Console.WriteLine($"{cislo} není prvočíslo.");
    }
}

static bool prime_num(int cislo)
{
    if (cislo < 2)
    {
        return false;
    }

    for (int i = 2; i <= Math.Sqrt(cislo); i++)
    {
        if (cislo % i == 0)
        {
            return false;
        }
    }

    return true;
}

int n = 5;
// A
static void a(int n)
{
    n=n*4;
    for (int i = 1; i < n; i=i+4)
    {
        Console.WriteLine(i);
    }
}
// a(n);
// (po konecne kontrole zadani jsem zjisti, ze funkce nefunguje uplne podle zadni)

// B
static void b(int n)
{
    for (n=n; n < 100; n++)
    {
        if (prime_num(n))
        {
            Console.WriteLine(n);
        }
    }
}
// b(n);

// C
static void c(int n)
{
    for (int i = 1; i < n; ++i)
    {
        Console.WriteLine(i);
    }
}
c(n);
