using System;
using System.Collections.Immutable;
using Newtonsoft.Json;

class CalendarApp
{
    public List<Event> events;

    public CalendarApp()
    {
        events = LoadEventsFromJson();
    }

    // nacte udalosti z "events.json"
    public List<Event> LoadEventsFromJson()
    {
        try
        {
            string json = File.ReadAllText("events.json");
            // vrací data z json do promene "json" (string)
            return JsonConvert.DeserializeObject<List<Event>>(json) ?? new List<Event>();
        }
        catch (FileNotFoundException)
        {
            return new List<Event>();
        }
    }

    // uklada do jsonu ("events.json")
    public void SaveEventsToJson()
    {
        string json = JsonConvert.SerializeObject(events, Formatting.Indented);
        File.WriteAllText("events.json", json);
    }

    // pridava event (nezapisuje do json)
    public void AddEvent()
    {
        Console.Write("Zadejte název události: "); // TODO - pridat kontorlu?
        string name = Console.ReadLine();
        Console.Write("Zadejte datum události (YYYY-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Event newEvent = new Event {Name = name, Date = date};
            events.Add(newEvent);
            Console.WriteLine("Událost byla přidána.");
        }
        else
        {
            Console.WriteLine("Neplatný formát data.");
        }
    }

    // upravuje udalost
    public void EditEvent()
    {
        Console.Write("Zadejte název události k úpravě: "); // vyhledava podle nazvu  TODO - filtrace podle data
        string searchName = Console.ReadLine();
        Event foundEvent = events.Find(e => e.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)); // Ignoruje case

        if (foundEvent != null)
        {
            Console.Write("Zadejte nový název události: "); // TODO - kontrola?
            foundEvent.Name = Console.ReadLine();
            Console.Write("Zadejte nové datum události (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
            {
                foundEvent.Date = newDate;
                Console.WriteLine("Událost byla upravena.");
            }
            else
            {
                Console.WriteLine("Neplatný formát data.");
            }
        }
        else
        {
            Console.WriteLine("Událost nebyla nalezena.");
        }
    }

    // smaze udalost
    public void DeleteEvent()
    {
        Console.Write("Zadejte název události k smazání: ");
        string searchName = Console.ReadLine(); // filtrace pouze podle nazvu  TODO - filtrace podle data
        Event foundEvent = events.Find(e => e.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (foundEvent != null)
        {
            events.Remove(foundEvent);
            Console.WriteLine("Událost byla smazána.");
        }
        else
        {
            Console.WriteLine("Událost nebyla nalezena.");
        }
    }

    // zobrazi udalosti podle data
    public void ShowEventsByDate()
    {
        Console.Write("Zadejte datum pro zobrazení událostí (YYYY-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            List<Event> eventsOnDate = events.FindAll(e => e.Date.Date == date.Date);
            PrintEvents(eventsOnDate);
        }
        else
        {
            Console.WriteLine("Neplatný formát data.");
        }
    }

    // filtruje udalosti podle nazvu
    public void SearchEventByName()
    {
        Console.Write("Zadejte název události pro vyhledání: ");
        string searchName = Console.ReadLine();
        List<Event> foundEvents = events.FindAll(e => e.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
        PrintEvents(foundEvents);
    }

    public void ShowAllEvents()
    {
        PrintEvents(events);
    }

    // Filtruje udalosti pro nadchazejici den
    public void ShowEventsForNextDay()
    {
        DateTime nextDay = DateTime.Now.Date.AddDays(1);
        List<Event> eventsForNextDay = events.FindAll(e => e.Date.Date == nextDay);
        PrintEvents(eventsForNextDay);
    }

    // (nevyuzivat samostatne)
    public void PrintEvents(List<Event> eventsToPrint)
    {
        if (eventsToPrint.Count > 0)
        {
            foreach (var e in eventsToPrint)
            {
                Console.WriteLine($"Název: {e.Name}, Datum: {e.Date:yyyy-MM-dd}");
            }
        }
        else
        {
            Console.WriteLine("Žádné události nebyly nalezeny.");
        }
    }
}

class Event
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
}
