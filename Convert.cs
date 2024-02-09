using System;

public class Converter
{
    public double InchesToMillimeters(double inches)
    {
        return inches * 25.4;
    }

    public double InchesToCentimeters(double inches)
    {
        return inches * 2.54;
    }

    public double InchesToMeters(double inches)
    {
        return inches * 0.0254;
    }

    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: convert <inches> <-mm/-cm/-m> [-t]");
            return;
        }

        double inches;
        if (!double.TryParse(args[0], out inches))
        {
            Console.WriteLine("Not valiid, provide a valid number for inches.");
            return;
        }

        string outputUnit = args[1];

        Converter converter = new Converter();
        double result = 0;

        switch (outputUnit)
        {
            case "-mm":
                result = converter.InchesToMillimeters(inches);
                Console.WriteLine($"{result} mm");
                break;
            case "-cm":
                result = converter.InchesToCentimeters(inches);
                Console.WriteLine($"{result} cm");
                break;
            case "-m":
                result = converter.InchesToMeters(inches);
                Console.WriteLine($"{result} m");
                break;
            default:
                Console.WriteLine("Invalid output unit. Please specify -mm, -cm, or -m.");
                break;
        }

        if (args.Length > 2 && args[2] == "-t")
        {
            RunTests(inches, outputUnit, result);
        }
    }

    private static void RunTests(double inches, string unit, double result)
    {
        double expected = 0;
        switch (unit)
        {
            case "-mm":
                expected = inches * 25.4;
                break;
            case "-cm":
                expected = inches * 2.54;
                break;
            case "-m":
                expected = inches * 0.0254;
                break;
        }

        if (Math.Abs(result - expected) < 0.001)
        {
            Console.WriteLine("🟢 Test passed");
        }
        else
        {
            Console.WriteLine($"🔴 Test failed | Expected: {expected}, Actual: {result}");
        }
    }
}