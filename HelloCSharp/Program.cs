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
        Console.WriteLine("=========== SYSTEM JSON TEXT ===========");
        Console.WriteLine("Select Menu : ");
        Console.WriteLine("1. Demo Serialize");
        Console.WriteLine("2. Demo Deserialize");
        Console.WriteLine("========================================");
        do
        {
            Console.WriteLine("▶ Please the functions are on the menu : ");
            var inputValue =  Console.ReadLine();
            var parsed = int.TryParse(inputValue, out int itemSelected);
            if(!parsed)
            {
                Console.WriteLine("❌  Input menu not vaild. Please retry !");
                continue;
            }

            if(itemSelected > 2)
            {
                Console.WriteLine("❌  Input menu not vaild. Please retry !");
                continue;
            }

            ProcessDemo(itemSelected);
       
            Console.WriteLine("Do you want to choose another function ? y/n : ");
            var resultYN = Console.ReadLine();
            if (resultYN.Contains("y"))
                continue;
            break;

        } while (true);
        
    }

    private static void ProcessDemo(int itemSelected)
    {
       switch(itemSelected)
        {
            case 1:
                var classList = Class.MockClass();
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, //format beautiful json
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping //support display vietnamese on console
                };
                var jsonResult = JsonSerializer.Serialize<List<Class>>(classList, options);
                Console.WriteLine("\n▶ ▶ ▶  START : Serialize Execute\n");
                Console.WriteLine($"{jsonResult}");
                Console.WriteLine("\n▶ ▶ ▶  END : Serialize Execute : \n");
                break;
            case 2:
                Console.WriteLine("\n▶ ▶ ▶  START : Deserialize Execute\n");

                var optionsDeserialize = new JsonSerializerOptions
                {
                    WriteIndented = true, //format beautiful json
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping //support display vietnamese on console
                };

                try
                {
                    using var fs = File.Open("../../../Resources/data.json", FileMode.Open);
                    Console.WriteLine("\n✅  Load file json successfully \n");
                    var modelResults = JsonSerializer.Deserialize<List<Class>>(fs);

                    foreach (var model in modelResults)
                    {
                        Console.WriteLine(model.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n Load file was failed : {ex.Message} !");
                    return;
                }

                Console.WriteLine("\n▶ ▶ ▶  END : Deserialize Execute\n");
                break;
        }    
    }
}

