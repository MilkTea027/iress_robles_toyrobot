using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Displays the table's second row visually.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IDisplaySecondRowStep" />
    public class DisplaySecondRowStep : DisplayVisualBaseStep, IDisplaySecondRowStep
    {
        /// <summary>
        /// Processes the display for the table's second row.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            this.PrintToyIfInRow(context, TableRow.SecondRow);
            this.Next(context);
        }
    }
}