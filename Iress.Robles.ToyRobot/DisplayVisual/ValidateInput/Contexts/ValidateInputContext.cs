using Iress.Robles.ToyRobot.Constants;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts
{
    /// <summary>
    /// The validation input chain of responsibility's context model.
    /// </summary>
    public class ValidateInputContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateInputContext"/> class.
        /// </summary>
        /// <param name="displayVisualContext">The display visual context.</param>
        public ValidateInputContext(DisplayVisualContext displayVisualContext)
        {
            this.DisplayContext = displayVisualContext;
        }

        /// <summary>
        /// Gets the <see cref="DisplayVisualContext"/>.
        /// </summary>
        /// <value>The <see cref="DisplayVisualContext"/>.</value>
        public DisplayVisualContext DisplayContext { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether user's input is valid.
        /// </summary>
        /// <value><c>true</c> if user's input is valid; otherwise, <c>false</c>.</value>
        public bool ValidInput { get; set; }

        /// <summary>
        /// Gets a value indicating whether the user input is a report command.
        /// </summary>
        /// <value><c>true</c> if the user input is a report command; otherwise, <c>false</c>.</value>
        public bool IsReportCommand
        {
            get
            {
                return this.DisplayContext.InputCommand == InputCommand.Report;
            }
        }

        /// <summary>
        /// Gets a value indicating whether toy on table should be displayed.
        /// </summary>
        /// <value><c>true</c> if toy on table should be displayed; otherwise, <c>false</c>.</value>
        public bool ShouldProceedToDisplay
        {
            get
            {
                return this.ValidInput && !this.IsReportCommand;
            }
        }
    }
}