using QRPlayground;

List<string> results = [];
foreach (var fileName in Directory.GetFiles("Content"))
{
    await using var stream       = new FileStream(fileName, FileMode.Open);
    using var       memoryStream = new MemoryStream();
    await stream.CopyToAsync(memoryStream);

    var bytes = memoryStream.ToArray();

    var result = Decoder.Decode(bytes, fileName);

    var resultString = $"{fileName} result: " + string.Join(", ", result);
    IterationCounter.End();
    Console.WriteLine(resultString);
    results.Add(resultString);
    Console.WriteLine();
}

Console.WriteLine(string.Join('\n', results));
Console.WriteLine("IterationsTotal: " + IterationCounter.Total);