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
        ]
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

Console.WriteLine(thing1?.account ?? "No account found");
Console.WriteLine(thing2?.account ?? "No account found");
