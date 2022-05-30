using Iress.Robles.ToyRobot.DisplayVisual.Base.Interfaces;

namespace Iress.Robles.ToyRobot.DisplayVisual.Interfaces
{
    /// <summary>
    /// The display of toy in table visual chain provider.
    /// </summary>
    public interface IDisplayVisualChainProvider
    {
        /// <summary>
        /// Gets the visual display of toy in table chain.
        /// </summary>
        /// <returns>The visual display of toy in table chain.</returns>
        IDisplayVisualBaseStep GetDisplayVisualChain();
    }
}
