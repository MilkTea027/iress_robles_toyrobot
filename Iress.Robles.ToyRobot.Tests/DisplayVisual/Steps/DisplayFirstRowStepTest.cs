using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.Steps
{
    [TestClass]
    public class DisplayFirstRowStepTest
    {
        private DisplayFirstRowStep target;
        private DisplayVisualContext context;

        [TestInitialize]
        public void Setup()
        {
            this.target = new DisplayFirstRowStep();
            this.context = new DisplayVisualContext()
            {
                ToyDirection = ToyDirection.North,
                XToyPosition = 0,
                YToyPosition = (int)TableRow.FirstRow,
            };
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        [TestMethod]
        public void Process_ToyIsInFirstRow_ReturnExpectedMessage()
        {
            var expected = "| ^         |\r\n";
            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyIsNotInFirstRow_ReturnEmptyMessage()
        {
            var expected = "|           |\r\n";
            context.YToyPosition = (int)TableRow.SecondRow;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}
