namespace Iress.Robles.ToyRobot.Instructions.Builder
{
    /// <summary>
    /// The builder for instructions.
    /// </summary>
    public interface IInstructionsBuilder
    {
        /// <summary>
        /// Builds the welcome message.
        /// </summary>
        void BuildWelcomeMessage();

        /// <summary>
        /// Builds the explanation message.
        /// </summary>
        void BuildExplanationMessage();

        /// <summary>
        /// Builds the command message.
        /// </summary>
        void BuildCommandMessage();
    }
}
