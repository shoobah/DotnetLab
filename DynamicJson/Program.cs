// See https://aka.ms/new-console-template for more information

using System.Dynamic;
using System.Text.Json;
using Microsoft.CSharp.RuntimeBinder;
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
        "someObject": {
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
static dynamic? NSReadJson(string json)
{
    return JObject.Parse(json);
}

static dynamic? TSReadJson(string json)
{
    return JsonSerializer.Deserialize<ExpandoObject>(json);
}

var NSThing1 = NSReadJson(json1);
var NSThing2 = NSReadJson(json2);
var TSThing1 = TSReadJson(json1);
var TSThing2 = TSReadJson(json2);

static int GetInt(dynamic? obj, string key)
{
    if (obj == null)
        return 0;
    if (obj[key] == null)
        return 0;
    return (int)obj[key];
}

Console.WriteLine("----------------------- Newtonsoft --------------------");
Console.WriteLine("NSThing1 type: " + NSThing1?.GetType());
Console.WriteLine("NSThing2 type: " + NSThing2?.GetType());
Console.WriteLine("thing1 account: " + (NSThing1?.account ?? "No account found"));
Console.WriteLine("thing2 account: " + (NSThing2?.account ?? "No account found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("thing1 -> some object id:" + (NSThing1?.someObject?.id ?? " not found"));
Console.WriteLine("thing2 -> some object id:" + (NSThing2?.someObject?.id ?? " not found"));
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("LINQ version");
Console.WriteLine($"thing1.account:{NSThing1?["account"] ?? "No account found"}");
Console.WriteLine($"thing2.account:{NSThing2?["account"] ?? "No account found"}");
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine("Cast to int version");
Console.WriteLine($"thing1.account:{GetInt(NSThing1, "account")}");
Console.WriteLine($"thing2.account:{GetInt(NSThing2, "account")}");

Console.WriteLine("----------------------- System.Text -------------------");
Console.WriteLine("NSThing2 type: " + TSThing1?.GetType());
Console.WriteLine("NSThing2 type: " + TSThing2?.GetType());
try
{
    Console.WriteLine("thing1 account: " + (TSThing1?.account ?? "No account found"));
}
catch (RuntimeBinderException)
{
    Console.WriteLine("thing1 account: no account");
}
try
{
    Console.WriteLine("thing2 account: " + (TSThing2?.account ?? "No account found"));
}
catch (RuntimeBinderException)
{
    Console.WriteLine("thing2 account: no account");
}
