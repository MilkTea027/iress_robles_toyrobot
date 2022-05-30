using System;
using System.Text;

namespace Iress.Robles.ToyRobot.Instructions.Builder
{
    /// <summary>
    /// The builder for instructions.
    /// </summary>
    /// <seealso cref="IInstructionsBuilder" />
    public class InstructionsBuilder : IInstructionsBuilder
    {
        /// <summary>
        /// Builds the welcome message.
        /// </summary>
        public void BuildWelcomeMessage()
        {
            var welcome = new StringBuilder();
            welcome.AppendLine("====[WELCOME IRESS TOY ROBOT ROBLES]====");
            welcome.AppendLine();

            Console.WriteLine(welcome);
        }

        /// <summary>
        /// Builds the explanation message.
        /// </summary>
        public void BuildExplanationMessage()
        {
            var explanation = new StringBuilder();
            explanation.AppendLine("You will have a table with a robot placed on top.");
            explanation.AppendLine();
            explanation.AppendLine("It is required to type PLACE command first to place robot.");
            explanation.AppendLine();
            explanation.AppendLine("Type LEFT command to make robot face left");
            explanation.AppendLine("Type RIGHT command to make robot face right");
            explanation.AppendLine("Type MOVE command to make robot step forward");
            explanation.AppendLine("Type REPORT to display X,Y,F position of robot");
            explanation.AppendLine();

            Console.WriteLine(explanation);
        }

        /// <summary>
        /// Builds the command message.
        /// </summary>
        public void BuildCommandMessage()
        {
            Console.WriteLine("Commands: PLACE, MOVE, LEFT, RIGHT, REPORT");
        }
    }
}