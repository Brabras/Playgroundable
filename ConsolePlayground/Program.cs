// using System.Text;
//
// const int MaxRowLimit = 20;
// var example = "123123 1312312312asdasasdasdasd 132123132 234 12312313";
// var result = NormalizeString(example);
//
// string NormalizeString(string str)
// {
//     var words = str.Split(' ');
//     var currentLength = 0;
//     var result = new StringBuilder();
//     var isFirstWord = true;
//     foreach (var word in words)
//     {
//         var firstGap = isFirstWord ? "" : " ";
//         if (currentLength + word.Length + 1 < MaxRowLimit)
//         {
//             result.Append($"{firstGap}{word}");
//             currentLength += word.Length;
//         }
//         else
//         {
//             result.Append($"{Environment.NewLine}{word}");
//             currentLength = word.Length;
//         }
//
//         isFirstWord = false;
//     }
//
//     return result.ToString();
// }
//
// Console.WriteLine(result);
//
// var sst = "asd";
// var st = $"{null}{sst}";
// Console.WriteLine(st);

// var numbersList = new List<long> { 1, 2, 3 };
//
// var numbersList2 = new List<long> { 4, 5, 6 };
//
// numbersList2.Append<List<long>>(numbersList);
//
// Console.WriteLine(string.Join(",", numbersList2));