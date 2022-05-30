using Iress.Robles.ToyRobot.DisplayVisual;
using Iress.Robles.ToyRobot.DisplayVisual.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Steps;
using Iress.Robles.ToyRobot.DisplayVisual.Steps.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps;
using Iress.Robles.ToyRobot.DisplayVisual.ValidateInput.Steps.Interfaces;
using Iress.Robles.ToyRobot.Instructions.Builder;
using Iress.Robles.ToyRobot.Instructions.Director;
using Microsoft.Extensions.DependencyInjection;

namespace Iress.Robles.ToyRobot.Configurations
{
    /// <summary>
    /// The class that implements the project's inversion of control.
    /// </summary>
    public class InjectionConfiguration
    {
        /// <summary>
        /// Builds the inversion of controls.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The build service provider with injected services.</returns>
        public ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            this.InjectChainSteps(services);
            this.InjectBuildersAndDirectors(services);

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Injects the chain steps.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        private void InjectChainSteps(IServiceCollection services)
        {
            //// PROVIDERS
            services.AddScoped<IDisplayVisualChainProvider, DisplayVisualChainProvider>();
            services.AddScoped<IValidateInputChainProvider, ValidateInputChainProvider>();

            //// DISPLAY VISUAL STEPS
            services.AddScoped<IDisplayFifthRowStep, DisplayFifthRowStep>();
            services.AddScoped<IDisplayFirstRowStep, DisplayFirstRowStep>();
            services.AddScoped<IDisplayFourthRowStep, DisplayFourthRowStep>();
            services.AddScoped<IDisplaySecondRowStep, DisplaySecondRowStep>();
            services.AddScoped<IDisplayTableBottomStep, DisplayTableBottomStep>();
            services.AddScoped<IDisplayTableTopStep, DisplayTableTopStep>();
            services.AddScoped<IDisplayThirdRowStep, DisplayThirdRowStep>();
            services.AddScoped<IUpdateContextStep, UpdateContextStep>();
            services.AddScoped<IValidateUserInputStep, ValidateUserInputStep>();

            //// VALIDATE INPUT STEPS
            services.AddScoped<IValidateInputStep, ValidateInputStep>();
            services.AddScoped<IValidateMoveStep, ValidateMoveStep>();
            services.AddScoped<IValidatePlaceStep, ValidatePlaceStep>();
            services.AddScoped<IValidateReportStep, ValidateReportStep>();
        }

        /// <summary>
        /// Injects the builders and directors.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        private void InjectBuildersAndDirectors(IServiceCollection services)
        {
            services.AddScoped<IInstructionsBuilder, InstructionsBuilder>();
            services.AddScoped<IInstructionsDirector, InstructionsDirector>();
        }
    }
}