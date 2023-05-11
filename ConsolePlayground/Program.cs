for (var i = 20; i < 20_000_000; i++)
{
    decimal walletAmount = i;

    //Console.WriteLine($"client want to send: {walletAmount}");

    var a = (walletAmount - walletAmount / 100M) * 100M;
    var walletShouldSend = Math.Round(a / 95M, 2);

    //Console.WriteLine($"wallet should send: {walletShouldSend}");

    var b = walletShouldSend - walletShouldSend / 100 * 5;
    var c = walletAmount - walletAmount / 100;

    if (Math.Abs(b - c) >= 0.01M) {
        Console.WriteLine($"2: {walletAmount}");
        Console.WriteLine($"2: {b}");
        Console.WriteLine($"3: {c}");
    }
}
Console.WriteLine("запись из ветки playing");