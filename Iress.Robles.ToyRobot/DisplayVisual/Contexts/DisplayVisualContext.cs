using Iress.Robles.ToyRobot.Enums;

namespace Iress.Robles.ToyRobot.DisplayVisual.Contexts
{
    /// <summary>
    /// The display visual chain of responsibility's context model.
    /// </summary>
    public class DisplayVisualContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayVisualContext"/> class.
        /// Default location should be SOUTH WEST.
        /// </summary>
        public DisplayVisualContext()
        {
            this.InputCommand = string.Empty;
            this.ToyDirection = ToyDirection.North;
            this.XToyPosition = 0;
            this.YToyPosition = 4;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the toy is placed on the table.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the toy is placed on the table; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlaced { get; set; }

        /// <summary>
        /// Gets or sets the user's input command.
        /// </summary>
        /// <value>The user's input command.</value>
        public string InputCommand { get; set; }

        /// <summary>
        /// Gets or sets the x-axis toy position.
        /// </summary>
        /// <value>The x-axis toy position.</value>
        public int XToyPosition { get; set; }

        /// <summary>
        /// Gets or sets the y-axis toy position.
        /// </summary>
        /// <value>The y-axis toy position.</value>
        public int YToyPosition { get; set; }

        /// <summary>
        /// Gets or sets the toy's direction.
        /// </summary>
        /// <value>The toy's direction.</value>
        public ToyDirection ToyDirection { get; set; }
    }
}