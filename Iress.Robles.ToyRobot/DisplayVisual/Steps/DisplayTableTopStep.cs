using System;
using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Displays the table's top edge visually.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IDisplayTableTopStep" />
    public class DisplayTableTopStep : DisplayVisualBaseStep, IDisplayTableTopStep
    {
        /// <summary>
        /// Processes the display for the table's top edge.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            Console.WriteLine("+ - - - - - +");

            this.Next(context);
        }
    }
}
