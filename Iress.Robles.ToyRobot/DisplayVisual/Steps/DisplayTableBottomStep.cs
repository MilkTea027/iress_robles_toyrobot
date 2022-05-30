using System;
using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Displays the table's bottom edge visually.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IDisplayTableBottomStep" />
    public class DisplayTableBottomStep : DisplayVisualBaseStep, IDisplayTableBottomStep
    {
        /// <summary>
        /// Processes the display for the table's bottom edge.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            Console.WriteLine("+ - - - - - +");

            this.Next(context);
        }
    }
}