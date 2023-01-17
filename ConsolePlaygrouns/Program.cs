// See https://aka.ms/new-console-template for more information

using System.Text.Json;

var str = "[-1001521736518]";

long[] chats = JsonSerializer.Deserialize<long[]>(str);
Console.ReadLine();