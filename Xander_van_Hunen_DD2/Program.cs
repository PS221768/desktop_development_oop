using System;
using System.IO;
using System.Reflection;
using Xander_van_Hunen_DD2.Classes;


List<ICoronaCheckEvenement> check_evenementen = new List<ICoronaCheckEvenement>();

void Fill_list()
{
    BioscoopUitje bios = new BioscoopUitje("bee movie", DateTime.Now, 3600, "bee movie", "2.7", "54", DateTime.Now, false, true);
    check_evenementen.Add(bios);
    BioscoopUitje bios2 = new BioscoopUitje("be movie", DateTime.Now, 3600, "bee movie", "2.7", "54", DateTime.Now, false, true);
    check_evenementen.Add(bios2);

    MuseumUitje museum = new MuseumUitje("rijksmuseum", DateTime.Now, 20.85);
    check_evenementen.Add(museum);
    MuseumUitje museum2 = new MuseumUitje("rijkmuseum", DateTime.Now, 18.85);
    check_evenementen.Add(museum2);

    BuitenWedstrijd buitenWedstrijd = new BuitenWedstrijd("voetbal", DateTime.Now, 5400, true);
    check_evenementen.Add(buitenWedstrijd);

    BinnenWedstrijd binnenWedstrijd = new BinnenWedstrijd("volleybal", DateTime.Now, 2400, false);
    check_evenementen.Add(binnenWedstrijd);
}

Fill_list();

bool Show_all()
{
    foreach (ICoronaCheckEvenement e in check_evenementen)
    {
        // In this program all the objects should have the property Name, thus I can use this here.
        object? type = e.GetType().GetProperty("Name")?.GetValue(e, null);
        Console.WriteLine(type);

    }
    return true;
}

void getDetailsByName()
{
    Console.WriteLine("Enter the name of the event: ");
    string name = Console.ReadLine();
    var eventsWithMatchingName = check_evenementen.Where(e => e.Name == name);
    if (!eventsWithMatchingName.Any())
    {
        Console.WriteLine("No events found with that name.");
        return;
    }

    foreach (var ev in eventsWithMatchingName)
    {
        if (ev is BinnenWedstrijd binnenWedstrijd)
        {
            Console.WriteLine("Name: " + binnenWedstrijd.Name);
            Console.WriteLine("Start Date: " + binnenWedstrijd.StartDate);
            Console.WriteLine("Duration: " + binnenWedstrijd.Duration);
            Console.WriteLine("Buiten: " + binnenWedstrijd.Buiten());
            Console.WriteLine("Corona check required: " + binnenWedstrijd.CoronaCheckRequired());
        }
        else if (ev is BuitenWedstrijd buitenWedstijd)
        {
            Console.WriteLine("Name: " + buitenWedstijd.Name);
            Console.WriteLine("Start Date: " + buitenWedstijd.StartDate);
            Console.WriteLine("Duration: " + buitenWedstijd.Duration);
            Console.WriteLine("Buiten: " + buitenWedstijd.Buiten());
            Console.WriteLine("Corona check required: " + buitenWedstijd.CoronaCheckRequired());
        }
        else if (ev is MuseumUitje museumUitje)
        {
            Console.WriteLine("Name: " + museumUitje.Name);
            Console.WriteLine("Start Date: " + museumUitje.StartDate);
            Console.WriteLine("Entry price: " + museumUitje.Entry_price);
            Console.WriteLine("Buiten: " + museumUitje.Buiten());
            Console.WriteLine("Corona check required: " + museumUitje.CoronaCheckRequired());
        }
        else if (ev is BioscoopUitje bioscoopUitje)
        {
            Console.WriteLine("Name: " + bioscoopUitje.Name);
            Console.WriteLine("Start Date: " + bioscoopUitje.StartDate);
            Console.WriteLine("Duration: " + bioscoopUitje.Duration);
            Console.WriteLine("Movie: " + bioscoopUitje.Movie);
            Console.WriteLine("Room: " + bioscoopUitje.Room);
            Console.WriteLine("Seat: " + bioscoopUitje.Seat);
            Console.WriteLine("Buiten: " + bioscoopUitje.Buiten());
            Console.WriteLine("Corona check required: " + bioscoopUitje.CoronaCheckRequired());
        }
    }
}


bool Show<T>()
{
    foreach (ICoronaCheckEvenement e in check_evenementen.OfType<T>())
    {
        // In this program all the objects should have the property Name, thus I can use this here.
        object? type = e.GetType().GetProperty("Name")?.GetValue(e, null);

        Console.WriteLine(type);

    }
    return true;
}

bool Create()
{
    string list = "[inside_competitions, outside_competitions, museum_trips, cinema_trips]";
    Console.WriteLine("Select what you want to create: " + list);


    void explanation_input() { Console.WriteLine("Fill out the requested variables one by one:"); }

   switch(input())
    {
        case "inside_competitions":
            explanation_input();
            // make it a function for memory related things
            bool create_inside_competitions ()
            {
                string name;
                DateTime startDate;
                int duration;
                bool doorstroom;
                try
                {
                    Console.WriteLine("Name of the competition: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Start date (yyyy-mm-dd hh:mm:ss): ");
                    startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Duration (in seconds): ");
                    duration = int.Parse(Console.ReadLine());
                    Console.WriteLine("Is there doorstroom (true/false): ");
                    doorstroom = bool.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input format: " + e.Message);
                    return false;
                }
                BinnenWedstrijd binnenWedstrijd = new BinnenWedstrijd(name, startDate, duration, doorstroom);
                check_evenementen.Add(binnenWedstrijd);
                return true;
            }
            create_inside_competitions();

            break;
        case "outside_competitions":

            explanation_input();
            // make it a function for memory related things, this should most likely just be implemented in the class...
            bool create_outside_competitions()
            {
                string name;
                DateTime startDate;
                int duration;
                bool doorstroom;
                try
                {
                    Console.WriteLine("Name of the competition: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Start date (yyyy-mm-dd hh:mm:ss): ");
                    startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Duration (in seconds): ");
                    duration = int.Parse(Console.ReadLine());
                    Console.WriteLine("Is there doorstroom (true/false): ");
                    doorstroom = bool.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input format: " + e.Message);
                    return false;
                }
                BuitenWedstrijd buitenWedstrijd = new BuitenWedstrijd(name, startDate, duration, doorstroom);
                check_evenementen.Add(buitenWedstrijd);
                return true;
            }
            create_outside_competitions();

            break;
        case "museum_trips":
            explanation_input();

            bool create_museum_trip()
            {
                string name;
                DateTime startDate;
                double entry_price;
                try
                {
                    Console.WriteLine("Name of the museum: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Start date (yyyy-mm-dd hh:mm:ss): ");
                    startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Price of entry: ");
                    entry_price = double.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input format: " + e.Message);
                    return false;
                }
                MuseumUitje museumUitje = new MuseumUitje(name, startDate, entry_price);
                check_evenementen.Add(museumUitje);
                return true;
            }
            create_museum_trip();
            break;
        case "cinema_trips":
            explanation_input();

            bool create_cinema_trips()
            {
                string name;
                DateTime startDate;
                DateTime startTime;
                int duration;
                string movie;
                string room;
                string seat;
                try
                {
                    Console.WriteLine("Name of the bioscoop uitje: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Start date (yyyy-mm-dd hh:mm:ss): ");
                    startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Start time (hh:mm:ss): ");
                    startTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Duration (in seconds): ");
                    duration = int.Parse(Console.ReadLine());
                    Console.WriteLine("Movie: ");
                    movie = Console.ReadLine();
                    Console.WriteLine("Room: ");
                    room = Console.ReadLine();
                    Console.WriteLine("Seat: ");
                    seat = Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input format: " + e.Message);
                    return false;
                }
                BioscoopUitje bioscoopUitje = new BioscoopUitje(name, startTime, duration, movie, room, seat, startDate);
                check_evenementen.Add(bioscoopUitje);
                return true;
            }
            create_cinema_trips();
            break;

        default:
            return false;
    }
    return true;
}

string input(string option = "")
{
    string question = option == "" ? "answer: " : "";
    Console.Write("answer: ");
    string data = Console.ReadLine() ?? "";
    Console.WriteLine("");
    return data;
}

bool init = true;
bool state = true;
while (state)
{
    if (!init) Console.WriteLine("");
    if (init) init = false;
    Console.WriteLine("Fill in your commands: ");
    switch(input())
    {
        case "new":
            bool succes = Create();
            break;
        case "show_list":
            const string list = "[all, inside_competitions, outside_competitions, museum_trips, cinema_trips]";
            Console.WriteLine("Select one of the following subjects to check:\n" + list);
            switch(input())
            {
                case "all":
                    Show_all();
                    break;
                case "inside_competitions":
                    Show<BinnenWedstrijd>();
                    break;
                case "outside_competitions":
                    Show<BuitenWedstrijd>();
                    break;
                case "museum_trips":
                    Show<MuseumUitje>();
                    break;
                case "cinema_trips":
                    Show<BioscoopUitje>();
                    break;
            }
            break;

        case "show_details":
            getDetailsByName();
            break;

        case "exit":
            Console.WriteLine("Exiting application...");
            state = false;
            break;
        case "help":
            Console.WriteLine("These are the commands: new, show_details, show_list exit, help");
            break;

        default:
            Console.WriteLine("This is not an vallid command.\nTo see a list of valid commands try 'help'");
            break;
    }

}

return 1;