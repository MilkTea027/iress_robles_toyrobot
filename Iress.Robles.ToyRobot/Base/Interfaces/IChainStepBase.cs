namespace Iress.Robles.ToyRobot.Base.Interfaces
{
    /// <summary>
    /// The base class used for chain of responsibility pattern.
    /// </summary>
    /// <typeparam name="TChainContext">The chain's context model.</typeparam>
    public interface IChainStepBase<TChainContext>
    {
        /// <summary>
        /// Gets or sets the chain's successor.
        /// </summary>
        /// <value>The chain's successor.</value>
        IChainStepBase<TChainContext> Successor { get; set; }

        /// <summary>
        /// Calls the next step in the chain, if any.
        /// </summary>
        /// <param name="context">The chain's context model.</param>
        void Next(TChainContext context);

        /// <summary>
        /// Perform's the current step in the chain's process.
        /// </summary>
        /// <param name="context">The chain's context model.</param>
        void Process(TChainContext context);

        /// <summary>
        /// Sets the successor of the last step of the chain.
        /// </summary>
        /// <param name="successor">The chain's specified successor.</param>
        void SetSuccessor(IChainStepBase<TChainContext> successor);
    }
}