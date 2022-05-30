using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.Steps
{
    [TestClass]
    public class DisplayThirdRowStepTest
    {
        private DisplayThirdRowStep target;
        private DisplayVisualContext context;

        [TestInitialize]
        public void Setup()
        {
            this.target = new DisplayThirdRowStep();
            this.context = new DisplayVisualContext()
            {
                ToyDirection = ToyDirection.East,
                XToyPosition = 2,
                YToyPosition = (int)TableRow.ThirdRow,
            };
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        [TestMethod]
        public void Process_ToyIsInThirdRow_ReturnExpectedMessage()
        {
            var expected = "|     >     |\r\n";
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
            context.YToyPosition = (int)TableRow.FourthRow;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}
