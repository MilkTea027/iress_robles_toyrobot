using System;
using System.IO;

namespace Iress.Robles.ToyRobot.Tests.TestHelpers
{
    public class ConsoleHelper : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleHelper()
        {
            this.stringWriter = new StringWriter();
            this.originalOutput = Console.Out;
            Console.SetOut(this.stringWriter);
        }

        public string GetOuput()
        {
            return this.stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(this.originalOutput);
            this.stringWriter.Dispose();
        }
    }
}
