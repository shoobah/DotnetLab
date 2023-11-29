// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json.Linq;

var json1 = """
    {
        "name": "John",
        "age": 30,
        "cars": [
            "Ford",
            "BMW",
            "Fiat"
        ],
        someObject: {
            "id": 1,
            "name": "Some object"
        }
    }
    """;

var json2 = """
    {
        "account": 8987,
        "name": "Ruben",
        "age": 72,
        "cars": [
            "Skoda",
            "VW",
            "Auto Bianchi"
        ]
    }
    """;

//function to read dynamic json
static dynamic? ReadJson(string json)
{
    return JObject.Parse(json);
}

var thing1 = ReadJson(json1);
var thing2 = ReadJson(json2);

Console.WriteLine("thing1 account: " +(thing1?.account ?? "No account found"));
Console.WriteLine("thing2 account: " +(thing2?.account ?? "No account found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("thing1 -> some object id:" + (thing1?.someObject?.id ?? " not found"));
Console.WriteLine("thing2 -> some object id:" + (thing2?.someObject?.id ?? " not found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("LINQ version");
Console.WriteLine($"thing1.account:{thing1?["account"] ?? "No account found"}");
Console.WriteLine($"thing2.account:{thing2?["account"] ?? "No account found"}");