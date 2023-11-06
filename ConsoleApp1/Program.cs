// zakladni datove typy
using System.ComponentModel.Design;


// simple poznamka

/*
 * viceradkova
 * poznamka
 */


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