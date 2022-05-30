using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.ValidateInput.Steps
{
    [TestClass]
    public class ValidateInputStepTest
    {
        private ValidateInputStep target;
        private ValidateInputContext context;
        private StubValidInputStep stubStep;

        [TestInitialize]
        public void Setup()
        {
            this.SetupContext();
            this.target = new ValidateInputStep();
            this.stubStep = new StubValidInputStep();
            this.target.SetSuccessor(this.stubStep);
        }

        public void Teardown()
        {
            this.target = null;
            this.context = null;
            this.stubStep = null;
        }

        private void SetupContext()
        {
            var displayContext = new DisplayVisualContext();
            this.context = new ValidateInputContext(displayContext);
        }

        [TestMethod]
        public void Process_ValidInput_NextIsCalled()
        {
            this.context.DisplayContext.InputCommand = InputCommand.Report;
            this.target.Process(this.context);
            Assert.IsTrue(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidInput_NextIsNotCalled()
        {
            this.context.DisplayContext.InputCommand = "Hamburger";
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidInput_ReturnExpectedErrorMessage()
        {
            var expected = "Invalid command. Please try again.\r\n";
            this.context.DisplayContext.InputCommand = "Hot Pot";

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}