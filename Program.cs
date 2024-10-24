using System.Globalization;
using System.Xml.Serialization;

namespace CSharpBasics;
class Program {

    static void Main() {
        Console.WriteLine("Welcome swimmer!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("\"1\" Creating a swim.");
        Console.WriteLine("\"2\" Getting all swims.");
        Console.WriteLine("\"3\" Searching a specific swim/swims.");
        int choice = 0;
        bool chosen = true;
        do {
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) {
                case 1:
                chosen = true;
                    Console.WriteLine("You choose 1");
                    CreateSwim();
                    break;
                case 2:
                chosen = true;
                    Console.WriteLine("You choose 2");
                    break;
                case 3:
                    chosen = true;
                    Console.WriteLine("You choose 3");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    chosen = false;
                    break;
            }
        } while(!chosen);

    }

    public static void CreateSwim(){
        // Getting Swim Time
        Console.WriteLine("How long did you swim? (hh:mm:ss)");
        string? Time = Console.ReadLine();
        double TotalSeconds = 0;
        if (!string.IsNullOrEmpty(Time))
        {
            // Parse the input time
            TimeSpan timeSpan;
            if (TimeSpan.TryParse(Time, out timeSpan))
            {
                // Calculate total seconds
                TotalSeconds = timeSpan.TotalSeconds;
            }
            else
            {
                Console.WriteLine("Invalid time format. Please use hh:mm:ss.");
            }
        }
        else
        {
            Console.WriteLine("No input provided.");
        }

        // Getting Swim Distance
        Console.WriteLine("How long was the pool? (in meter)");
        int? PoolLength = Convert.ToInt32(Console.ReadLine()?.Trim().Replace("m",""));
        Console.WriteLine("How many lenghts did you swim?");
        int? Lenghts = Convert.ToInt32(Console.ReadLine());
        string? Distance = Convert.ToString(PoolLength * Lenghts);

        // Getting Swim Style
        Console.WriteLine("What swimstyle did you do? (f:freestyle, ba:backstroke, br:breaststroke or bu:butterfly)");
        string? SwimStyle = Console.ReadLine();
        TextInfo textInfo = new CultureInfo("en-us",false).TextInfo;
        if(SwimStyle == "f") SwimStyle = "Freestyle"; 
        else if(SwimStyle == "ba") SwimStyle = "Backstroke";
        else if (SwimStyle == "br") SwimStyle = "Breaststroke";
        else if (SwimStyle == "bu") SwimStyle = "Butterfly";
        // Making sure the word starts with a capitle letter and no others
        if (!string.IsNullOrEmpty(SwimStyle))SwimStyle = textInfo.ToTitleCase(SwimStyle);

        // Calculating Swim Pace
        double SecondsFor100m = TotalSeconds /Convert.ToInt32(Distance) * 100;
        double Minutes = Math.Floor(SecondsFor100m/60);
        double Seconds = Math.Floor(SecondsFor100m - Minutes*60);
        // This adds a leading zero if minutes is less then 10 (only works for int not double)
        string FormatedMinutes = ((int)Minutes).ToString("D2");
        string FormatedSeconds = ((int)Seconds).ToString("D2");
        string swimPace = FormatedMinutes + ":" + FormatedSeconds;

        // Displaying Result
        Console.WriteLine($"Your swim: {Distance}m {SwimStyle} in {Time}! (pace: {swimPace})");

        // Ask To save swim
        Console.WriteLine("Do you want to save this swim? (y/n)");
        string? save = Console.ReadLine();

        // Saving swim
        if(save == "y" || save =="Yes") Console.WriteLine("Saved");
    }

    public static void GetAllSwims(){

    }

    public static void SearchSwim(){

    }

}