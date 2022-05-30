using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces
{
    /// <summary>
    /// The chain in the step that validates the MOVE command.
    /// Will execute the move command if valid.
    /// </summary>
    /// <seealso cref="IValidInputBaseStep" />
    public interface IValidateMoveStep : IValidInputBaseStep
    {
    }
}
