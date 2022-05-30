using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;

namespace Iress.Robles.ToyRobot.Tests.TestHelpers
{
    public class StubValidInputStep : ValidInputBaseStep, IValidInputBaseStep
    {
        public bool NextIsCalled { get; set; }

        public override void Process(ValidateInputContext context)
        {
            this.NextIsCalled = true;
        }
    }
}