class Program
{
    static void Main(string[] args)
    {
        var s = @"class Program {{
            static void Main(string[] args) {{
                var s = @{0}{1}{0};
                System.Console.WriteLine(s, (char)34, s);
            }}
        }}";
        System.Console.WriteLine(s, (char)34, s);
    }
}