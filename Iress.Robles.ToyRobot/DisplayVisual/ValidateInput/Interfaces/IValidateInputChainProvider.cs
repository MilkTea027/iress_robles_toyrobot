using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Interfaces
{
    /// <summary>
    /// Validation input chain provider.
    /// </summary>
    public interface IValidateInputChainProvider
    {
        /// <summary>
        /// Gets the validate chain.
        /// </summary>
        /// <returns>The validation chain.</returns>
        IValidInputBaseStep GetValidateChain();
    }
}