using System.Collections.Generic;
using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps
{
    /// <summary>
    /// The step in the chain that validates user input if it is using specified commands.
    /// </summary>
    /// <seealso cref="ValidInputBaseStep" />
    /// <seealso cref="IValidateInputStep" />
    public class ValidateInputStep : ValidInputBaseStep, IValidateInputStep
    {
        private readonly List<string> validCommands = new List<string>()
        {
            InputCommand.Left,
            InputCommand.Move,
            InputCommand.Place,
            InputCommand.Report,
            InputCommand.Right,
        };

        /// <summary>
        /// Process that validates the user input that it uses valid commands.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(ValidateInputContext context)
        {
            context.ValidInput = this.validCommands.Contains(context.DisplayContext.InputCommand);
            this.ValidateAndCallNext(context, "Invalid command. Please try again.");
        }
    }
}