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
    public class ValidateMoveStepTest
    {
        private ValidateMoveStep target;
        private ValidateInputContext context;
        private StubValidInputStep stubStep;

        [TestInitialize]
        public void Setup()
        {
            this.target = new ValidateMoveStep();
            this.stubStep = new StubValidInputStep();
            this.target.SetSuccessor(this.stubStep);
        }

        public void Teardown()
        {
            this.target = null;
            this.context = null;
            this.stubStep = null;
        }

        private void SetupContext(string inputCommand, ToyDirection direction, int xpos, int ypos)
        {
            var displayContext = new DisplayVisualContext()
            {
                InputCommand = inputCommand,
                ToyDirection = direction,
                XToyPosition = (int)xpos,
                YToyPosition = (int)ypos,
            };

            this.context = new ValidateInputContext(displayContext)
            {
                ValidInput = true
            };
        }

        [TestMethod]
        public void Process_CommandIsNotMove_NextStepCalled()
        {
            this.SetupContext(InputCommand.Report, ToyDirection.East, 0, 0);
            this.target.Process(this.context);
            Assert.IsTrue(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_ValidPosition_NextStepCalled()
        {
            this.SetupContext(InputCommand.Move, ToyDirection.East, 2, 2);
            this.target.Process(this.context);
            Assert.IsTrue(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidNorth_NextStepNotCalled()
        {
            this.SetupContext(InputCommand.Move, ToyDirection.North, 4, 0);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidSouth_NextStepNotCalled()
        {
            this.SetupContext(InputCommand.Move, ToyDirection.South, 0, 4);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidEast_NextStepNotCalled()
        {
            this.SetupContext(InputCommand.Move, ToyDirection.East, 4, 4);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidWest_NextStepNotCalled()
        {
            this.SetupContext(InputCommand.Move, ToyDirection.West, 0, 4);
            this.target.Process(this.context);
            Assert.IsFalse(this.stubStep.NextIsCalled);
        }

        [TestMethod]
        public void Process_InvalidNorth_ReturnsExpectedMessage()
        {
            var expected = "Toy is on the edge. Cannot move.\r\n";
            this.SetupContext(InputCommand.Move, ToyDirection.North, 0, 0);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_InvalidSouth_ReturnsExpectedMessage()
        {
            var expected = "Toy is on the edge. Cannot move.\r\n";
            this.SetupContext(InputCommand.Move, ToyDirection.South, 0, 4);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_InvalidEast_ReturnsExpectedMessage()
        {
            var expected = "Toy is on the edge. Cannot move.\r\n";
            this.SetupContext(InputCommand.Move, ToyDirection.East, 4, 0);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void Process_InvalidWest_ReturnsExpectedMessage()
        {
            var expected = "Toy is on the edge. Cannot move.\r\n";
            this.SetupContext(InputCommand.Move, ToyDirection.West, 0, 0);

            using (var consoleHelper = new ConsoleHelper())
            {
                this.target.Process(this.context);
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}