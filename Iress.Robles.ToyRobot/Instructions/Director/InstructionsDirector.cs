using Iress.Robles.ToyRobot.Instructions.Builder;

namespace Iress.Robles.ToyRobot.Instructions.Director
{
    /// <summary>
    /// The instruction's builder director.
    /// </summary>
    /// <seealso cref="IInstructionsDirector" />
    public class InstructionsDirector : IInstructionsDirector
    {
        private readonly IInstructionsBuilder instructionsBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructionsDirector"/> class.
        /// </summary>
        /// <param name="instructionsBuilder">The instructions builder.</param>
        public InstructionsDirector(IInstructionsBuilder instructionsBuilder)
        {
            this.instructionsBuilder = instructionsBuilder;
        }

        /// <summary>
        /// Builds the instructions.
        /// </summary>
        public void BuildInstructions()
        {
            this.instructionsBuilder.BuildWelcomeMessage();
            this.instructionsBuilder.BuildExplanationMessage();
            this.instructionsBuilder.BuildCommandMessage();
        }
    }
}