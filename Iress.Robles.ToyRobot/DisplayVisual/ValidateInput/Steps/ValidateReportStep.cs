using System;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps
{
    /// <summary>
    /// Validates if the input is REPORT command step.
    /// </summary>
    /// <seealso cref="ValidInputBaseStep" />
    /// <seealso cref="IValidateReportStep" />
    public class ValidateReportStep : ValidInputBaseStep, IValidateReportStep
    {
        private readonly string reportFormat = "{0}[Robot position]: {0}X-Axis: {1}{0}Y-Axis: {2}{0}Facing: {3}";

        /// <summary>
        /// Processes that validates if the input is REPORT command.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(ValidateInputContext context)
        {
            if (context.IsReportCommand)
            {
                var displayContext = context.DisplayContext;

                var message = string.Format(
                                this.reportFormat,
                                Environment.NewLine,
                                displayContext.XToyPosition,
                                4 - displayContext.YToyPosition,
                                displayContext.ToyDirection.ToString());

                Console.WriteLine(message);
            }

            this.Next(context);
        }
    }
}
