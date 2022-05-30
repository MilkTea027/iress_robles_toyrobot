using Iress.Robles.ToyRobot.DisplayVisual.Base;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps
{
    /// <summary>
    /// Validates the user input step.
    /// </summary>
    /// <seealso cref="DisplayVisualBaseStep" />
    /// <seealso cref="IValidateUserInputStep" />
    public class ValidateUserInputStep : DisplayVisualBaseStep, IValidateUserInputStep
    {
        private readonly IValidInputBaseStep validateInputChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUserInputStep"/> class.
        /// </summary>
        /// <param name="validateInputChainProvider">The validate input chain provider.</param>
        public ValidateUserInputStep(IValidateInputChainProvider validateInputChainProvider)
        {
            this.validateInputChain = validateInputChainProvider.GetValidateChain();
        }

        /// <summary>
        /// Process that validates the user's input.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Process(DisplayVisualContext context)
        {
            var validateContext = new ValidateInputContext(context);
            this.validateInputChain.Process(validateContext);

            if (validateContext.ShouldProceedToDisplay)
            {
                this.Next(context);
            }
        }
    }
}