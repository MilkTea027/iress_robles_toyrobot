using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps
{
    /// <summary>
    /// The step in the chain that validates the PLACE command.
    /// </summary>
    /// <seealso cref="ValidInputBaseStep" />
    /// <seealso cref="IValidatePlaceStep" />
    public class ValidatePlaceStep : ValidInputBaseStep, IValidatePlaceStep
    {
        /// <summary>
        /// Processes that validates the PLACE command or if the toy is in place already.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(ValidateInputContext context)
        {
            var errMessage = string.Empty;
            var isPlaced = context.DisplayContext.IsPlaced;
            var isPlaceCommand = context.DisplayContext.InputCommand == InputCommand.Place;

            if (!isPlaced)
            {
                if (isPlaceCommand)
                {
                    context.DisplayContext.IsPlaced = isPlaceCommand;
                }
                else
                {
                    errMessage = "Please type command 'PLACE' first to place toy on table.";
                }
            }
            else if (isPlaced && isPlaceCommand)
            {
                errMessage = "Toy already placed.";
            }

            context.ValidInput = string.IsNullOrWhiteSpace(errMessage);
            this.ValidateAndCallNext(context, errMessage);
        }
    }
}
