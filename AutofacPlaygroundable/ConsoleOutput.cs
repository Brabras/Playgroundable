using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacPlayGround
{
    public class ConsoleOutput : IOutput
    {
        public static readonly ConsoleOutput Instance = new ConsoleOutput();

        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
