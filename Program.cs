using System;

class TemperatureConverter
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter a temperature value and its unit of measurement (F or C):");
            string? userInput = Console.ReadLine();

            if (userInput == "exit")
            {
                Console.WriteLine("Program terminated.");
                break;
            }

            if (userInput != null && TryParseTemperature(userInput, out double temperature, out char unit))
            {
                char targetUnit = (unit == 'F') ? 'C' : 'F';
                double convertedTemperature = TempConvert(temperature, unit, targetUnit);

                Console.WriteLine($"{temperature} {unit} = {convertedTemperature:F2} {targetUnit}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature value and its unit of measurement (F or C):");
            }
        }
    }

    static bool TryParseTemperature(string userInput, out double temperature, out char unit)
    {
        temperature = 0.0;
        unit = ' ';

        if (userInput.Length < 2)
        {
            return false;
        }

        if (!double.TryParse(userInput.Substring(0, userInput.Length - 1), out temperature))
        {
            return false;
        }

        unit = char.ToUpper(userInput[userInput.Length - 1]);

        if (unit != 'F' && unit != 'C')
        {
            return false;
        }

        return true;
    }

    static double TempConvert(double temperature, char fromUnit, char toUnit)
    {
        if (fromUnit == 'F' && toUnit == 'C')
        {
            return (temperature - 32) * 5 / 9;
        }
        else if (fromUnit == 'C' && toUnit == 'F')
        {
            return (temperature * 9 / 5) + 32;
        }
        else
        {
            return temperature;
        }
    }
}
