using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput
{
    /// <summary>
    /// Validation input chain provider.
    /// </summary>
    /// <seealso cref="IValidateInputChainProvider" />
    public class ValidateInputChainProvider : IValidateInputChainProvider
    {
        private readonly IValidateInputStep validateInputStep;
        private readonly IValidateMoveStep validateMoveStep;
        private readonly IValidatePlaceStep validatePlaceStep;
        private readonly IValidateReportStep validateReportStep;
        private IValidInputBaseStep validateInputChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateInputChainProvider"/> class.
        /// </summary>
        /// <param name="validateInputStep">The validate input step.</param>
        /// <param name="validateMoveStep">The validate move step.</param>
        /// <param name="validatePlaceStep">The validate place step.</param>
        /// <param name="validateReportStep">The validate report step.</param>
        public ValidateInputChainProvider(
            IValidateInputStep validateInputStep,
            IValidateMoveStep validateMoveStep,
            IValidatePlaceStep validatePlaceStep,
            IValidateReportStep validateReportStep)
        {
            this.validateInputStep = validateInputStep;
            this.validateMoveStep = validateMoveStep;
            this.validatePlaceStep = validatePlaceStep;
            this.validateReportStep = validateReportStep;
        }

        /// <summary>
        /// Gets the validate chain.
        /// </summary>
        /// <returns>The validation chain.</returns>
        public IValidInputBaseStep GetValidateChain()
        {
            if (this.validateInputChain == null)
            {
                this.validateInputChain = this.validateInputStep;
                this.validateInputChain.SetSuccessor(this.validatePlaceStep);
                this.validateInputChain.SetSuccessor(this.validateMoveStep);
                this.validateInputChain.SetSuccessor(this.validateReportStep);
            }

            return this.validateInputChain;
        }
    }
}