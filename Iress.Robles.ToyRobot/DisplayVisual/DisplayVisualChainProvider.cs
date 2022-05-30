using Iress.Robles.ToyRobot.DisplayVisual.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual
{
    /// <summary>
    /// The display of toy in table visual chain provider.
    /// </summary>
    /// <seealso cref="IDisplayVisualChainProvider" />
    public class DisplayVisualChainProvider : IDisplayVisualChainProvider
    {
        private readonly IDisplayFifthRowStep displayFifthRowStep;
        private readonly IDisplayFirstRowStep displayFirstRowStep;
        private readonly IDisplayFourthRowStep displayFourthRowStep;
        private readonly IDisplaySecondRowStep displaySecondRowStep;
        private readonly IDisplayTableBottomStep displayTableBottomStep;
        private readonly IDisplayTableTopStep displayTableTopStep;
        private readonly IDisplayThirdRowStep displayThirdRowStep;
        private readonly IUpdateContextStep updateContextStep;
        private readonly IValidateUserInputStep validateUserInputStep;

        private IDisplayVisualBaseStep displayVisualChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayVisualChainProvider"/> class.
        /// </summary>
        /// <param name="validateUserInputStep">The validate user input step.</param>
        /// <param name="updateContextStep">The update context step.</param>
        /// <param name="displayTableTopStep">The display table top step.</param>
        /// <param name="displayFirstRowStep">The display first row step.</param>
        /// <param name="displaySecondRowStep">The display second row step.</param>
        /// <param name="displayThirdRowStep">The display third row step.</param>
        /// <param name="displayFourthRowStep">The display fourth row step.</param>
        /// <param name="displayFifthRowStep">The display fifth row step.</param>
        /// <param name="displayTableBottomStep">The display table bottom step.</param>
        public DisplayVisualChainProvider(
            IValidateUserInputStep validateUserInputStep,
            IUpdateContextStep updateContextStep,
            IDisplayTableTopStep displayTableTopStep,
            IDisplayFirstRowStep displayFirstRowStep,
            IDisplaySecondRowStep displaySecondRowStep,
            IDisplayThirdRowStep displayThirdRowStep,
            IDisplayFourthRowStep displayFourthRowStep,
            IDisplayFifthRowStep displayFifthRowStep,
            IDisplayTableBottomStep displayTableBottomStep)
        {
            this.validateUserInputStep = validateUserInputStep;
            this.updateContextStep = updateContextStep;
            this.displayTableTopStep = displayTableTopStep;
            this.displayFirstRowStep = displayFirstRowStep;
            this.displaySecondRowStep = displaySecondRowStep;
            this.displayThirdRowStep = displayThirdRowStep;
            this.displayFourthRowStep = displayFourthRowStep;
            this.displayFifthRowStep = displayFifthRowStep;
            this.displayTableBottomStep = displayTableBottomStep;
        }

        /// <summary>
        /// Gets the visual display of toy in table chain.
        /// </summary>
        /// <returns>The visual display of toy in table chain.</returns>
        public IDisplayVisualBaseStep GetDisplayVisualChain()
        {
            if (this.displayVisualChain == null)
            {
                this.displayVisualChain = this.validateUserInputStep;
                this.displayVisualChain.SetSuccessor(this.updateContextStep);
                this.displayVisualChain.SetSuccessor(this.displayTableTopStep);
                this.displayVisualChain.SetSuccessor(this.displayFirstRowStep);
                this.displayVisualChain.SetSuccessor(this.displaySecondRowStep);
                this.displayVisualChain.SetSuccessor(this.displayThirdRowStep);
                this.displayVisualChain.SetSuccessor(this.displayFourthRowStep);
                this.displayVisualChain.SetSuccessor(this.displayFifthRowStep);
                this.displayVisualChain.SetSuccessor(this.displayTableBottomStep);
            }

            return this.displayVisualChain;
        }
    }
}
