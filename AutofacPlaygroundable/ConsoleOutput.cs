namespace AutofacPlaygroundable
{
    public class ConsoleOutput : IOutput
    {
        private readonly string ConfigSectionName;

        public ConsoleOutput(string configSectionName)
        {
            ConfigSectionName = configSectionName;
        }

        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}