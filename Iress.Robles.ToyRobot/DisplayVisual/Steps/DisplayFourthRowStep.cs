using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Displays the table's fourth row visually.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IDisplayFourthRowStep" />
    public class DisplayFourthRowStep : DisplayVisualBaseStep, IDisplayFourthRowStep
    {
        /// <summary>
        /// Processes the display for the table's third row.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            this.PrintToyIfInRow(context, TableRow.FourthRow);
            this.Next(context);
        }
    }
}
