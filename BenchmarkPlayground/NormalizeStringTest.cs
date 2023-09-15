using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkPlayground;

[MemoryDiagnoser]
public class NormalizeStringTest
{
    private const int MaxRowLength = 20;
    private const string Example = "123123 1312312312asdasasdasdasd 132123132 234 12312313";

    [Benchmark]
    public string NormalizeStringWithStringList()
    {
        var words = Example.Split(' ');
        var currentLength = 0;
        var result = new List<string>();
        var isFirstWord = true;
        foreach (var word in words)
        {
            if (currentLength + word.Length + 1 < MaxRowLength)
            {
                var gap = isFirstWord ? "" : " ";
                result.Add($"{gap}{word}");
                currentLength += word.Length;
            }
            else
            {
                result.Add($"{Environment.NewLine}{word}");
                currentLength = word.Length;
            }

            isFirstWord = false;
        }

        return string.Join(string.Empty, result);
    }

    [Benchmark]
    public string NormalizeStringWithStringBuilder()
    {
        var words = Example.Trim().Split(' ');
        var sb = new StringBuilder();
        var currentRowLength = 0;
        var isFirstWord = true;
        foreach (var word in words)
        {
            if (currentRowLength + word.Length + 1 < MaxRowLength)
            {
                var gap = isFirstWord ? null : " ";
                sb.Append($"{gap}{word}");
                currentRowLength += word.Length;
            }
            else
            {
                sb.Append($"{Environment.NewLine}{word}");
                currentRowLength = word.Length;
            }

            isFirstWord = false;
        }

        return sb.ToString();
    }
}