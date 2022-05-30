using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.Steps
{
    [TestClass]
    public class DisplayFourthRowStepTest
    {
        private DisplayFourthRowStep target;
        private DisplayVisualContext context;

        [TestInitialize]
        public void Setup()
        {
            this.target = new DisplayFourthRowStep();
            this.context = new DisplayVisualContext()
            {
                ToyDirection = ToyDirection.West,
                XToyPosition = 3,
                YToyPosition = (int)TableRow.FourthRow,
            };
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        [TestMethod]
        public void Process_ToyIsInFourthRow_ReturnExpectedMessage()
        {
            var expected = "|       <   |\r\n";
            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyIsNotInFourthRow_ReturnEmptyMessage()
        {
            var expected = "|           |\r\n";
            context.YToyPosition = (int)TableRow.FifthRow;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}
