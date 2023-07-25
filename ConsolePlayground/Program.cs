using ConsolePlayground;

var list = new List<long> { 1, 3, 5 };
var anotherList = new List<long> { 1, 2, 6 };
var except = list.Except(anotherList);
Console.Write(string.Join(" ,", except));
var example = new Example(1);

var brabras = example.ToBrabrasExt();

Console.WriteLine(brabras);

Example example1 = null;

var bras = example1.ToBrabrasExt();

Console.WriteLine(brabras);