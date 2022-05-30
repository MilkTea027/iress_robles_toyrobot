using System;
using Iress.Robles.ToyRobot.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Base
{
    /// <summary>
    /// The display visual chain base step.
    /// </summary>
    /// <seealso cref="ChainStepBase&lt;DisplayVisualContext&gt;" />
    /// <seealso cref="IDisplayVisualBaseStep" />
    public abstract class DisplayVisualBaseStep : ChainStepBase<DisplayVisualContext>, IDisplayVisualBaseStep
    {
        private readonly string emptyTableRowVisual = "|           |";

        /// <summary>
        /// Prints the toy in the table if it is currently in the specified table row.
        /// </summary>
        /// <param name="context">The <see cref="DisplayVisualContext"/>.</param>
        /// <param name="tableRow">The specified <see cref="TableRow"/>.</param>
        protected void PrintToyIfInRow(DisplayVisualContext context, TableRow tableRow)
        {
            if (context.YToyPosition == (int)tableRow)
            {
                this.PrintToyInTableRow(context);
            }
            else
            {
                this.PrintEmptyTableRow();
            }
        }

        private void PrintEmptyTableRow()
        {
            Console.WriteLine(this.emptyTableRowVisual);
        }

        private void PrintToyInTableRow(DisplayVisualContext context)
        {
            var direction = this.GetToyVisualDirection(context.ToyDirection);
            var location = this.GetToyRowLocation(context.XToyPosition);

            var toyInTable = this.emptyTableRowVisual.Remove(location, 1).Insert(location, direction);
            Console.WriteLine(toyInTable);
        }

        private string GetToyVisualDirection(ToyDirection toyDirection)
        {
            var toyVisual = "^";

            switch (toyDirection)
            {
                case ToyDirection.East:
                    toyVisual = ">";
                    break;
                case ToyDirection.South:
                    toyVisual = "v";
                    break;
                case ToyDirection.West:
                    toyVisual = "<";
                    break;
            }

            return toyVisual;
        }

        private int GetToyRowLocation(int rowPosition)
        {
            return (rowPosition + 1) * 2;
        }
    }
}