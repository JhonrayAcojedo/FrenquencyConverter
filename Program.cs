// See https://aka.ms/new-console-template for more information
bool run = true;
while (run)
{
    Console.WriteLine("1. Convert Period to Frequency");
    Console.WriteLine("2. Convert Frequency to Period");
    Console.WriteLine("3. End the program.");
    Console.Write("Enter your choice (1, 2 or 3): ");
    int choice = int.Parse(Console.ReadLine());
    try
    {
        switch (choice)
        {
            case 1:
                Console.Write("Enter the period value: ");
                double periodValue = double.Parse(Console.ReadLine());
                Console.Write("Enter the unit (s, ms, us, ns, ps): ");
                string periodUnit = Console.ReadLine();

                double frequency = PeriodToFrequency(periodValue, periodUnit);
                Console.WriteLine($"Frequency: {Math.Round(frequency, 6)} Hz");
                break;

            case 2:
                Console.Write("Enter the frequency value: ");
                double frequencyValue = double.Parse(Console.ReadLine());
                Console.Write("Enter the unit (Hz, KHz, MHz, GHz, THz): ");
                string frequencyUnit = Console.ReadLine();

                double period = FrequencyToPeriod(frequencyValue, frequencyUnit);
                Console.WriteLine($"Period: {period:0.############} seconds");
                break;
            case 3:
                Console.WriteLine($"Terminating program...");
                run = false;
                break;

            default:
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid choice.");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }   
}



static double PeriodToFrequency(double periodValue, string periodUnit)
{
    double periodInSeconds = ConvertToSeconds(periodValue, periodUnit);
    return 1 / periodInSeconds;
}

static double FrequencyToPeriod(double frequencyValue, string frequencyUnit)
{
    double frequencyInHz = ConvertToHz(frequencyValue, frequencyUnit);
    return 1 / frequencyInHz;
}

static double ConvertToSeconds(double value, string unit)
{
    switch (unit)
    {
        case "s":
        case "S":
            return value;
        case "ms":
        case "Ms":
            return value * 1e-3;
        case "us":
        case "Us":
            return value * 1e-6;
        case "ns":
        case "Ns":
            return value * 1e-9;
        case "ps":
        case "Ps":
            return value * 1e-12;
        default:
            throw new ArgumentException("Invalid unit.");
    }
}

static double ConvertToHz(double value, string unit)
{
    switch (unit)
    {
        case "Hz":
        case "hz":
            return value;
        case "KHz":
        case "khz":
            return value * 1e3;
        case "MHz":
        case "mhz":
            return value * 1e6;
        case "GHz":
        case "ghz":
            return value * 1e9;
        case "THz":
        case "thz":
            return value * 1e12;
        default:
            throw new ArgumentException("Invalid unit.");
    }
}