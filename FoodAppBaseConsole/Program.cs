using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

class Program
{
    static string[] eBlacklist = {
        "E100", "E101", "E102", "E103", "E104", "E105", "E106", "E107", "E108",
        "E110", "E120", "E121", "E122", "E123", "E124", "E125", "E126", "E127",
        "E128", "E130", "E131", "E132", "E133", "E140", "E141", "E142", "E143",
        // Add more E-numbers as needed
    };

    static bool IsECodeInBlacklist(string eCode)
    {
        return Array.Exists(eBlacklist, b => b.Equals(eCode, StringComparison.OrdinalIgnoreCase));
    }
    static async Task GetFoodInfo(string code)
    {
        string url = $"https://world.openfoodfacts.org/api/v0/product/{code}.json";
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        
        using JsonDocument doc = JsonDocument.Parse(body);
        JsonElement root = doc.RootElement;
        if (root.GetProperty("status").GetInt32() == 0)
        {
            Console.WriteLine("Product not found");
            return;
        }

        var product = root.GetProperty("product");

        string brand = product.GetProperty("brands").GetString();
        string name = product.GetProperty("product_name").GetString();

        JsonElement additives;
        if (product.TryGetProperty("additives_tags", out additives) && additives.ValueKind == JsonValueKind.Array && additives.GetArrayLength() > 0)
        {
            Console.WriteLine("additives found");
            foreach (JsonElement additive in additives.EnumerateArray())
            {
                string eCode = additive.GetString();
                eCode = eCode.Replace("en:", "").ToUpper();
                Console.WriteLine($"- {eCode}");

                if (IsECodeInBlacklist(eCode))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"WARNING: {eCode} is in the blacklist!");
                    Console.ResetColor();
                }
            }
        }
        else
        {
            Console.WriteLine("No data about this product yet");
        }
        Console.WriteLine($"Brand: {brand}");
        Console.WriteLine($"Name: {name}");

    }
    static async Task Main(string[] args)
    {
        Console.Write("Enter the barcode of the food item: ");
        string barcode = Console.ReadLine();
        if (string.IsNullOrEmpty(barcode))
        {
            Console.WriteLine("No barcode provided.");
            return;
        }
        else
        {
            await GetFoodInfo(barcode);
        }
    }
}