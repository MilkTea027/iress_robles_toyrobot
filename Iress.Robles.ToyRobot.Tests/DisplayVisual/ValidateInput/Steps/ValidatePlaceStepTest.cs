using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.ValidateInput.Steps
{
    [TestClass]
    public class ValidatePlaceStepTest
    {
        private ValidatePlaceStep target;
        private ValidateInputContext context;
        private StubValidInputStep stubStep;

        [TestInitialize]
        public void Setup()
        {
            this.target = new ValidatePlaceStep();
            this.stubStep = new StubValidInputStep();
            this.target.SetSuccessor(this.stubStep);
        }

        public void Teardown()
        {
            this.target = null;
            this.context = null;
            this.stubStep = null;
        }

        private void SetupContext(bool isPlaced, string inputCommand)
        {
            var displayContext = new DisplayVisualContext()
            {
                IsPlaced = isPlaced,
                InputCommand = inputCommand
            };

            this.context = new ValidateInputContext(displayContext);
        }

        [TestMethod]
        public void Process_ToyNotPlacedAndInputIsNotPlace_ReturnExpectedMessage()
        {
            var expected = "Please type command 'PLACE' first to place toy on table.\r\n";
            this.SetupContext(isPlaced: false, inputCommand: InputCommand.Report);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyNotPlacedAndInputIsNotPlace_NextNotCalled()
        {
            this.SetupContext(isPlaced: false, inputCommand: InputCommand.Left);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_ToyNotPlacedButInputIsPlaced_NextIsCalled()
        {
            this.SetupContext(isPlaced: false, inputCommand: InputCommand.Place);
            this.target.Process(this.context);
            Assert.IsTrue(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_ToyPlacedAndCommandNotPlaced_NextIsCalled()
        {
            this.SetupContext(isPlaced: true, inputCommand: InputCommand.Right);
            this.target.Process(this.context);
            Assert.IsTrue(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_ToyPlacedAndInputPlaced_ReturnExpectedMessage()
        {
            var expected = "Toy already placed.\r\n";
            this.SetupContext(isPlaced: true, inputCommand: InputCommand.Place);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_ToyPlacedAndInputPlaced_NextNotCalled()
        {
            this.SetupContext(isPlaced: true, inputCommand: InputCommand.Place);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }
    }
}