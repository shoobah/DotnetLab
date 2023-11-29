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

static int GetInt(dynamic? obj, string key)
{
    if (obj == null)
        return 0;
    if (obj[key] == null)
        return 0;
    return (int)obj[key];
}

var a1 = thing1?.account as int?;
var a2 = thing2?.account as int?;

Console.WriteLine("thing1 account: " +(thing1?.account ?? "No account found"));
Console.WriteLine("thing2 account: " +(thing2?.account ?? "No account found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("thing1 -> some object id:" + (thing1?.someObject?.id ?? " not found"));
Console.WriteLine("thing2 -> some object id:" + (thing2?.someObject?.id ?? " not found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("LINQ version");
Console.WriteLine($"thing1.account:{thing1?["account"] ?? "No account found"}");
Console.WriteLine($"thing2.account:{thing2?["account"] ?? "No account found"}");
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("Cast to int version");
Console.WriteLine($"thing1.account:{GetInt(thing1, "account")}");
Console.WriteLine($"thing2.account:{GetInt(thing2, "account")}");