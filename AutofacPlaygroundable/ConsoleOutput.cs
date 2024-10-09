namespace AutofacPlaygroundable
{
    public class ConsoleOutput : IOutput
    {
        // private readonly string _configSectionName;
        //
        // public ConsoleOutput(string configSectionName)
        // {
        //     _configSectionName = configSectionName;
        // }

        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}