using Iress.Robles.ToyRobot.Instructions.Builder;
using Iress.Robles.ToyRobot.Instructions.Director;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Iress.Robles.ToyRobot.Tests.Instructions.Director
{
    [TestClass]
    public class InstructionsDirectorTest
    {
        private InstructionsDirector target;
        private Mock<IInstructionsBuilder> instructionsBuilder;

        [TestInitialize]
        public void Setup()
        {
            this.SetupMocks();
            this.target = new InstructionsDirector(this.instructionsBuilder.Object);
        }

        private void SetupMocks()
        {
            this.instructionsBuilder = new Mock<IInstructionsBuilder>();
            this.instructionsBuilder.Setup(ib => ib.BuildCommandMessage());
            this.instructionsBuilder.Setup(ib => ib.BuildExplanationMessage());
            this.instructionsBuilder.Setup(ib => ib.BuildWelcomeMessage());
        }

        [TestMethod]
        public void BuildInstructions_MockedBuilder_BuildWelcomeMessageCalled()
        {
            this.target.BuildInstructions();
            this.instructionsBuilder.Verify(ib => ib.BuildWelcomeMessage(), Times.Once);
        }

        [TestMethod]
        public void BuildInstructions_MockedBuilder_BuildExplanationMessageCalled()
        {
            this.target.BuildInstructions();
            this.instructionsBuilder.Verify(ib => ib.BuildExplanationMessage(), Times.Once);
        }

        [TestMethod]
        public void BuildInstructions_MockedBuilder_BuildCommandMessageCalled()
        {
            this.target.BuildInstructions();
            this.instructionsBuilder.Verify(ib => ib.BuildCommandMessage(), Times.Once);
        }
    }
}