using Iress.Robles.ToyRobot.Instructions.Builder;
using Iress.Robles.ToyRobot.Tests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iress.Robles.ToyRobot.Tests.Instructions.Builder
{
    [TestClass]
    public class InstructionsBuilderTest
    {
        private InstructionsBuilder target;

        [TestInitialize]
        public void Setup()
        {
            this.target = new InstructionsBuilder();
        }

        [TestCleanup]
        public void Teardown()
        {
        }

        [TestMethod]
        public void BuildWelcomeMessage_StaticString_ReturnExpectedString()
        {
            var expected = "====[WELCOME IRESS TOY ROBOT ROBLES]====\r\n\r\n\r\n";

            using (var consoleHelper = new ConsoleHelper())
            {
                target.BuildWelcomeMessage();
                var actual = consoleHelper.GetOuput();
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void BuildCommandMessage_StaticString_ReturnExpectedString()
        {
            var expected = "Commands: PLACE, MOVE, LEFT, RIGHT, REPORT\r\n";

            using (var consoleHelper = new ConsoleHelper())
            {
                target.BuildCommandMessage();
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }

        [TestMethod]
        public void BuildExplanationMessage_StaticString_ReturnExpectedString()
        {
            var expected = "You will have a table with a robot placed on top.\r\n\r\n"
                + "It is required to type PLACE command first to place robot.\r\n\r\n"
                + "Type LEFT command to make robot face left\r\n"
                + "Type RIGHT command to make robot face right\r\n"
                + "Type MOVE command to make robot step forward\r\n"
                + "Type REPORT to display X,Y,F position of robot\r\n\r\n\r\n";

            using (var consoleHelper = new ConsoleHelper())
            {
                target.BuildExplanationMessage();
                Assert.AreEqual(expected, consoleHelper.GetOuput());
            }
        }
    }
}