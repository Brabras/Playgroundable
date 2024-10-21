namespace QRPlayground;

public static class IterationCounter
{
    public static long Total { get; private set; }
    public static long Iteration { get; private set; }

    static IterationCounter()
    {
        Iteration = 0;
        Total     = 0;
    }

    public static void Increment()
    {
        Iteration++;
    }

    public static void End()
    {
        Console.WriteLine($"Iterations: {Iteration}");
        Total+= Iteration;
        Iteration = 0;
    }
}