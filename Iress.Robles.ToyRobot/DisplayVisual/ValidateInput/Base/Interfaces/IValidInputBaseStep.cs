using Iress.Robles.ToyRobot.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces
{
    /// <summary>
    /// The validation of input base step in the chain.
    /// </summary>
    /// <seealso cref="IChainStepBase&lt;ValidateInputContext&gt;" />
    public interface IValidInputBaseStep : IChainStepBase<ValidateInputContext>
    {
    }
}