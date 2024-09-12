using System.Text.RegularExpressions;

var input = new LargeStruct<string>("Phone number: 123-456-7890");


var returningNewReplaceResult = ReturningNewReplace(input);
Console.WriteLine(returningNewReplaceResult.Value);
Console.WriteLine();

var returningInputReplaceResult = ReturningInputReplace(input);
Console.WriteLine(returningInputReplaceResult.Value);
Console.WriteLine();


LargeStruct<string> ReturningNewReplace(LargeStruct<string> xml)
{
    var regex = new Regex(@"\d", RegexOptions.Multiline | RegexOptions.Compiled);

    var result = new LargeStruct<string>(regex.Replace(xml.Value, "#"));

    return result;
}


LargeStruct<string> ReturningInputReplace(LargeStruct<string> xml)
{
    var regex = new Regex(@"\d", RegexOptions.Multiline | RegexOptions.Compiled);

    regex.Replace(xml.Value, "#");

    return xml;
}

public struct LargeStruct<TValue>(TValue value)
{
    public TValue Value { get; } = value;
}