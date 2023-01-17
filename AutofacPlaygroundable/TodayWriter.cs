namespace AutofacPlayGround
{
    public class TodayWriter : IDateWriter
    {
        public int Number { get; private set; }

        private readonly ConsoleOutput _output;

        public TodayWriter(ConsoleOutput output)
        {
            _output = output;
        }

        public void Rase(int i)
        {
            Number += i;
        }

        public void WriteDate()
        {
            //ConsoleOutput.Instance.Write

            this._output.Write(DateTime.Today.ToShortDateString());
        }

    }
}
