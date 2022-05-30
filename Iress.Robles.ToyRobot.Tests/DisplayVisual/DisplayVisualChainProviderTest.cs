using System.Collections.Generic;
using Iress.Robles.ToyRobot.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Iress.Robles.ToyRobot.Tests.DisplayVisual
{
    [TestClass]
    public class DisplayVisualChainProviderTest
    {
        private DisplayVisualChainProvider target;
        private Mock<IDisplayFifthRowStep> displayFifthRowStep;
        private Mock<IDisplayFirstRowStep> displayFirstRowStep;
        private Mock<IDisplayFourthRowStep> displayFourthRowStep;
        private Mock<IDisplaySecondRowStep> displaySecondRowStep;
        private Mock<IDisplayTableBottomStep> displayTableBottomStep;
        private Mock<IDisplayTableTopStep> displayTableTopStep;
        private Mock<IDisplayThirdRowStep> displayThirdRowStep;
        private Mock<IUpdateContextStep> updateContextStep;
        private Mock<IValidateUserInputStep> validateUserInputStep;
        private List<IChainStepBase<DisplayVisualContext>> successorSteps;

        [TestInitialize]
        public void Setup()
        {
            this.SetupMocks();

            this.target = new DisplayVisualChainProvider(
                this.validateUserInputStep.Object,
                this.updateContextStep.Object,
                this.displayTableTopStep.Object,
                this.displayFirstRowStep.Object,
                this.displaySecondRowStep.Object,
                this.displayThirdRowStep.Object,
                this.displayFourthRowStep.Object,
                this.displayFifthRowStep.Object,
                this.displayTableBottomStep.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.validateUserInputStep = null;
            this.updateContextStep = null;
            this.displayTableTopStep = null;
            this.displayFirstRowStep = null;
            this.displaySecondRowStep = null;
            this.displayThirdRowStep = null;
            this.displayFourthRowStep = null;
            this.displayFifthRowStep = null;
            this.displayTableBottomStep = null;
        }

        private void SetupMocks()
        {
            this.successorSteps = new List<IChainStepBase<DisplayVisualContext>>();

            this.validateUserInputStep = new Mock<IValidateUserInputStep>();
            this.updateContextStep = new Mock<IUpdateContextStep>();
            this.displayTableTopStep = new Mock<IDisplayTableTopStep>();
            this.displayFirstRowStep = new Mock<IDisplayFirstRowStep>();
            this.displaySecondRowStep = new Mock<IDisplaySecondRowStep>();
            this.displayThirdRowStep = new Mock<IDisplayThirdRowStep>();
            this.displayFourthRowStep = new Mock<IDisplayFourthRowStep>();
            this.displayFifthRowStep = new Mock<IDisplayFifthRowStep>();
            this.displayTableBottomStep = new Mock<IDisplayTableBottomStep>();

            this.validateUserInputStep
                .Setup(v => v.SetSuccessor(It.IsAny<IChainStepBase<DisplayVisualContext>>()))
                .Callback((IChainStepBase<DisplayVisualContext> step) => this.successorSteps.Add(step));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_SetSuccessorCalled8Times()
        {
            this.target.GetDisplayVisualChain();
            this.validateUserInputStep.Verify(v =>
                    v.SetSuccessor(It.IsAny<IChainStepBase<DisplayVisualContext>>()),
                    Times.Exactly(8));
        }

        [TestMethod]
        public void GetDisplayVisualChain_CalledTwice_SetSuccessorCalled8Times()
        {
            this.target.GetDisplayVisualChain();
            this.target.GetDisplayVisualChain();

            this.validateUserInputStep.Verify(v =>
                    v.SetSuccessor(It.IsAny<IChainStepBase<DisplayVisualContext>>()),
                    Times.Exactly(8));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_FirstStepIsValidateUserInputStep()
        {
            var actual = this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(actual, typeof(IValidateUserInputStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_SecondStepIsUpdateContextStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[0], typeof(IUpdateContextStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_ThirdStepIsDisplayTableTopStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[1], typeof(IDisplayTableTopStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_FourthStepIsDisplayFirstRowStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[2], typeof(IDisplayFirstRowStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_FifthStepIsDisplaySecondRowStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[3], typeof(IDisplaySecondRowStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_SixthStepIsDisplayThirdRowStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[4], typeof(IDisplayThirdRowStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_SeventhStepIsDisplayFourthRowStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[5], typeof(IDisplayFourthRowStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_EightStepIsDisplayFifthRowStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[6], typeof(IDisplayFifthRowStep));
        }

        [TestMethod]
        public void GetDisplayVisualChain_MockedChainSteps_NinthStepIsDisplayTableBottomStep()
        {
            this.target.GetDisplayVisualChain();
            Assert.IsInstanceOfType(this.successorSteps[7], typeof(IDisplayTableBottomStep));
        }
    }
}