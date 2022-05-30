using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.Steps
{
    [TestClass]
    public class DisplaySecondRowStepTest
    {
        private DisplaySecondRowStep target;
        private DisplayVisualContext context;

        [TestInitialize]
        public void Setup()
        {
            this.target = new DisplaySecondRowStep();
            this.context = new DisplayVisualContext()
            {
                ToyDirection = ToyDirection.South,
                XToyPosition = 1,
                YToyPosition = (int)TableRow.SecondRow,
            };
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        [TestMethod]
        public void Process_ToyIsInSecondRow_ReturnExpectedMessage()
        {
            var expected = "|   v       |\r\n";
            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyIsNotInSecondRow_ReturnEmptyMessage()
        {
            var expected = "|           |\r\n";
            context.YToyPosition = (int)TableRow.ThirdRow;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}
