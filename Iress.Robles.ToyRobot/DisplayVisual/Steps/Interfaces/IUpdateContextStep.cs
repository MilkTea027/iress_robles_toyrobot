using Iress.Robles.ToyRobot.DisplayVisual.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;

namespace Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces
{
    /// <summary>
    /// Updates the <see cref="DisplayVisualContext"/> based on user input command
    /// so the display steps on the chain will display the toy visually correct.
    /// </summary>
    /// <seealso cref="IDisplayVisualBaseStep" />
    public interface IUpdateContextStep : IDisplayVisualBaseStep
    {
    }
}
