using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Displays the table's third row visually.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IDisplayThirdRowStep" />
    public class DisplayThirdRowStep : DisplayVisualBaseStep, IDisplayThirdRowStep
    {
        /// <summary>
        /// Processes the display for the table's third row.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            this.PrintToyIfInRow(context, TableRow.ThirdRow);
            this.Next(context);
        }
    }
}