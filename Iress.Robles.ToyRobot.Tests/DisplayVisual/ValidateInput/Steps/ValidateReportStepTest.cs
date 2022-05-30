using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps;
using Iress.Robles.ToyRobot.Enums;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.ValidateInput.Steps
{
    [TestClass]
    public class ValidateReportStepTest
    {
        private ValidateReportStep target;
        private ValidateInputContext context;

        [TestInitialize]
        public void Setup()
        {
            this.SetupContext();
            this.target = new ValidateReportStep();
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.context = null;
        }

        private void SetupContext()
        {
            var displayContext = new DisplayVisualContext()
            {
                XToyPosition = 1,
                YToyPosition = 2,
                ToyDirection = ToyDirection.East
            };

            this.context = new ValidateInputContext(displayContext);
        }

        [TestMethod]
        public void Process_IsReportCommandTrue_ReturnsExpectedMessage()
        {
            this.context.DisplayContext.InputCommand = InputCommand.Report;
            var expected = "\r\n[Robot position]: \r\nX-Axis: 1\r\nY-Axis: 2\r\nFacing: East\r\n";

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                var actual = consoleHelper.GetOuput();
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_IsReportCommandFalse_NoMessage()
        {
            this.context.DisplayContext.InputCommand = InputCommand.Move;

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(string.Empty, consoleHelper.GetOuput());
            }
        }
    }
}