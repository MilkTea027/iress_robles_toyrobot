using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps
{
    /// <summary>
    /// The chain in the step that validates the MOVE command.
    /// Will execute the MOVE command if valid.
    /// </summary>
    /// <seealso cref="ValidInputBaseStep" />
    /// <seealso cref="IValidateMoveStep" />
    public class ValidateMoveStep : ValidInputBaseStep, IValidateMoveStep
    {
        /// <summary>
        /// Process that validates the MOVE command.
        /// Will execute the MOVE command if valid.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(ValidateInputContext context)
        {
            var dcontext = context.DisplayContext;

            if (dcontext.InputCommand == InputCommand.Move)
            {
                var validNorth = !(dcontext.YToyPosition == 0 && dcontext.ToyDirection == ToyDirection.North);
                var validSouth = !(dcontext.YToyPosition == 4 && dcontext.ToyDirection == ToyDirection.South);
                var validEast = !(dcontext.XToyPosition == 4 && dcontext.ToyDirection == ToyDirection.East);
                var validWest = !(dcontext.XToyPosition == 0 && dcontext.ToyDirection == ToyDirection.West);

                context.ValidInput = validNorth && validSouth && validEast && validWest;
            }

            this.ValidateAndCallNext(context, "Toy is on the edge. Cannot move.");
        }
    }
}