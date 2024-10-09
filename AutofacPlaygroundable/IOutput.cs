namespace AutofacPlaygroundable
{
    public interface IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
