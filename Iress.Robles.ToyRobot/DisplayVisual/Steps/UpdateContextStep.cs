using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Updates the <see cref="DisplayVisualContext"/> based on user input command
    /// so the display steps on the chain will show the toy visually correct.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IUpdateContextStep" />
    public class UpdateContextStep : DisplayVisualBaseStep, IUpdateContextStep
    {
        /// <summary>
        /// Processes that updates the <see cref="DisplayVisualContext"/> based on
        /// user input command so the display steps on the chain will show the toy visually correct.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            this.UpdatePosition(context);
            this.UpdateDirection(context);

            this.Next(context);
        }

        private void UpdatePosition(DisplayVisualContext context)
        {
            if (context.InputCommand == InputCommand.Move)
            {
                if (context.ToyDirection == ToyDirection.North)
                {
                    context.YToyPosition--;
                }
                else if (context.ToyDirection == ToyDirection.East)
                {
                    context.XToyPosition++;
                }
                else if (context.ToyDirection == ToyDirection.South)
                {
                    context.YToyPosition++;
                }
                else if (context.ToyDirection == ToyDirection.West)
                {
                    context.XToyPosition--;
                }
            }
        }

        private void UpdateDirection(DisplayVisualContext context)
        {
            if (context.InputCommand == InputCommand.Left)
            {
                var isNorth = context.ToyDirection == ToyDirection.North;
                context.ToyDirection = isNorth ? ToyDirection.West : context.ToyDirection - 1;
            }
            else if (context.InputCommand == InputCommand.Right)
            {
                var isWest = context.ToyDirection == ToyDirection.West;
                context.ToyDirection = isWest ? ToyDirection.North : context.ToyDirection + 1;
            }
        }
    }
}
