using System;
using Iress.Robles.ToyRobot.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base
{
    /// <summary>
    /// The validation of input base step in the chain.
    /// </summary>
    /// <seealso cref="ChainStepBase&lt;ValidateInputContext&gt;" />
    /// <seealso cref="IValidInputBaseStep" />
    public abstract class ValidInputBaseStep : ChainStepBase<ValidateInputContext>, IValidInputBaseStep
    {
        /// <summary>
        /// Validates the input if valid then calls the next step, else write specified error message.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="errorMessage">The specified error message.</param>
        protected void ValidateAndCallNext(ValidateInputContext context, string errorMessage)
        {
            if (context.ValidInput)
            {
                this.Next(context);
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}