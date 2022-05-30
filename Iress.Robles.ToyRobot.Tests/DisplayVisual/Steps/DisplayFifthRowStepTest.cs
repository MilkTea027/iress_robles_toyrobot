using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.Steps
{
    [TestClass]
    public class DisplayFifthRowStepTest
    {
        private DisplayFifthRowStep target;
        private DisplayVisualContext context;

        [TestInitialize]
        public void Setup()
        {
            this.target = new DisplayFifthRowStep();
            this.context = new DisplayVisualContext()
            {
                ToyDirection = ToyDirection.North,
                XToyPosition = 4,
                YToyPosition = (int)TableRow.FifthRow,
            };
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        [TestMethod]
        public void Process_ToyIsInFifthRow_ReturnExpectedMessage()
        {
            var expected = "|         ^ |\r\n";
            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyIsNotInFifthRow_ReturnEmptyMessage()
        {
            var expected = "|           |\r\n";
            context.YToyPosition = (int)TableRow.FirstRow;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}
