using System.Diagnostics.CodeAnalysis;
using Iress.Robles.ToyRobot.Base.Interfaces;

namespace Iress.Robles.ToyRobot.Base
{
    /// <summary>
    /// The base class used for chain of responsibility pattern.
    /// </summary>
    /// <typeparam name="TChainContext">The type of the chain context.</typeparam>
    /// <seealso cref="IChainStepBase&lt;TChainContext&gt;" />
    [ExcludeFromCodeCoverage]
    public abstract class ChainStepBase<TChainContext> : IChainStepBase<TChainContext>
    {
        /// <summary>
        /// Gets or sets the chain's successor.
        /// </summary>
        /// <value>The chain's successor.</value>
        public IChainStepBase<TChainContext> Successor { get; set; }

        /// <summary>
        /// Calls the next step in the chain, if any.
        /// </summary>
        /// <param name="context">The chain's context model.</param>
        public void Next(TChainContext context)
        {
            if (this.Successor != null)
            {
                this.Successor.Process(context);
            }
        }

        /// <summary>
        /// Sets the successor of the last step of the chain.
        /// </summary>
        /// <param name="successor">The chain's specified successor.</param>
        public void SetSuccessor(IChainStepBase<TChainContext> successor)
        {
            if (this.Successor == null)
            {
                this.Successor = successor;
            }
            else
            {
                this.Successor.SetSuccessor(successor);
            }
        }

        /// <summary>
        /// Perform's the current step in the chain's process.
        /// </summary>
        /// <param name="context">The chain's context model.</param>
        public abstract void Process(TChainContext context);
    }
}