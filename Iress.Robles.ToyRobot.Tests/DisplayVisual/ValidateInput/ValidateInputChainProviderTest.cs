using System.Collections.Generic;
using Iress.Robles.ToyRobot.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual.ValidateInput
{
    [TestClass]
    public class ValidateInputChainProviderTest
    {
        private ValidateInputChainProvider target;
        private Mock<IValidateInputStep> validateInputStep;
        private Mock<IValidateMoveStep> validateMoveStep;
        private Mock<IValidatePlaceStep> validatePlaceStep;
        private Mock<IValidateReportStep> validateReportStep;
        private List<IChainStepBase<ValidateInputContext>> successorSteps;

        [TestInitialize]
        public void Setup()
        {
            this.SetupMocks();

            this.target = new ValidateInputChainProvider(
                                validateInputStep.Object,
                                validateMoveStep.Object,
                                validatePlaceStep.Object,
                                validateReportStep.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.validateInputStep = null;
            this.validateMoveStep = null;
            this.validatePlaceStep = null;
            this.validateReportStep = null;
        }

        private void SetupMocks()
        {
            this.successorSteps = new List<IChainStepBase<ValidateInputContext>>();
            this.validateInputStep = new Mock<IValidateInputStep>();
            this.validateMoveStep = new Mock<IValidateMoveStep>();
            this.validatePlaceStep = new Mock<IValidatePlaceStep>();
            this.validateReportStep = new Mock<IValidateReportStep>();

            this.validateInputStep
                .Setup(v => v.SetSuccessor(It.IsAny<IChainStepBase<ValidateInputContext>>()))
                .Callback((IChainStepBase<ValidateInputContext> step) => this.successorSteps.Add(step));
        }

        [TestMethod]
        public void GetValidateChain_MockedChainSteps_SetSuccessorCalled3Times()
        {
            this.target.GetValidateChain();
            this.validateInputStep.Verify(v =>
                    v.SetSuccessor(It.IsAny<IChainStepBase<ValidateInputContext>>()),
                    Times.Exactly(3));
        }

        [TestMethod]
        public void GetValidateChain_CalledTwice_SetSuccessorCalled3Times()
        {
            this.target.GetValidateChain();
            this.target.GetValidateChain();

            this.validateInputStep.Verify(v =>
                    v.SetSuccessor(It.IsAny<IChainStepBase<ValidateInputContext>>()),
                    Times.Exactly(3));
        }

        [TestMethod]
        public void GetValidateChain_MockedChainSteps_FirstStepIsValidateInputStep()
        {
            var actual = this.target.GetValidateChain();
            Assert.IsInstanceOfType(actual, typeof(IValidateInputStep));
        }

        [TestMethod]
        public void GetValidateChain_MockedChainSteps_SecondStepIsValidatePlaceStep()
        {
            this.target.GetValidateChain();
            Assert.IsInstanceOfType(this.successorSteps[0], typeof(IValidatePlaceStep));
        }

        [TestMethod]
        public void GetValidateChain_MockedChainSteps_ThirdStepIsValidateMoveStep()
        {
            this.target.GetValidateChain();
            Assert.IsInstanceOfType(this.successorSteps[1], typeof(IValidateMoveStep));
        }

        [TestMethod]
        public void GetValidateChain_MockedChainSteps_FourthStepIsValidateReportStep()
        {
            this.target.GetValidateChain();
            Assert.IsInstanceOfType(this.successorSteps[2], typeof(IValidateReportStep));
        }
    }
}
