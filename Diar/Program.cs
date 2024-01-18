using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        CalendarApp calendarApp = new CalendarApp();

        while (true)
        {
            Console.WriteLine("1. Přidat událost");
            Console.WriteLine("2. Upravit událost");
            Console.WriteLine("3. Smazat událost");
            Console.WriteLine("4. Procházet události podle data");
            Console.WriteLine("5. Vyhledat událost podle názvu");
            Console.WriteLine("6. Zobrazit všechny události");
            Console.WriteLine("7. Zobrazit události na následující den");
            Console.WriteLine("8. Ukončit program");

            Console.Write("Zadejte číslo operace: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        calendarApp.AddEvent();
                        calendarApp.SaveEventsToJson();
                        break;
                    case 2:
                        calendarApp.EditEvent();
                        calendarApp.SaveEventsToJson();
                        break;
                    case 3:
                        calendarApp.DeleteEvent();
                        break;
                    case 4:
                        calendarApp.ShowEventsByDate();
                        break;
                    case 5:
                        calendarApp.SearchEventByName();
                        break;
                    case 6:
                        calendarApp.ShowAllEvents();
                        break;
                    case 7:
                        calendarApp.ShowEventsForNextDay();
                        break;
                    case 8:
                        calendarApp.SaveEventsToJson();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zadejte prosím platné číslo operace.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Neplatný vstup. Zadejte prosím platné číslo operace.");
            }

            Console.WriteLine();
        }
    }
}
