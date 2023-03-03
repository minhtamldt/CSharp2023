using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using HelloCSharp.Models;

namespace HelloCSharp;
class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=========== SYSTEM JSON TEXT ===========");
        Console.WriteLine("Select Menu : ");
        Console.WriteLine("1. Demo Serialize Basic");
        Console.WriteLine("2. Demo Deserialize Basic");
        Console.WriteLine("========================================");
        Console.ResetColor(); 
        do
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("▶ Please the functions are on the menu : ");
                var readKey = Console.ReadLine();
                var parsed = int.TryParse(readKey, out int optionSelected);
                ProcessDemo(optionSelected);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌  Error! An error occurred: {ex.Message}. Please try again later!");
            }

        } while (true);
        
    }

    private static void ProcessDemo(int optionSelected)
    {
        if (optionSelected > 2)
            throw new IndexOutOfRangeException("The current App has only 2 functions !");

       switch(optionSelected)
        {
            case 1:
                {
                    var classList = Class.MockClass();
                    var options = new JsonSerializerOptions
                    {
                        //format beautiful json
                        WriteIndented = true,
                        //support display vietnamese on console
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };
                    var jsonResult = JsonSerializer.Serialize<List<Class>>(classList, options);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nSerialize ✅\n");
                    Console.WriteLine($"{jsonResult}");
                }
                break;
            case 2:
                {
                    Console.WriteLine("\n Deserialize ✅\n");

                    var optionsDeserialize = new JsonSerializerOptions
                    {
                        WriteIndented = true, //format beautiful json
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping //support display vietnamese on console
                    };

                    var fs = File.Open("../../../Resources/data.json", FileMode.Open);
                    var modelResults = JsonSerializer.Deserialize<List<Class>>(fs);

                    foreach (var model in modelResults)
                    {
                        Console.WriteLine(model.ToString());
                    }
                }
                
                break;
        }    
    }
}

