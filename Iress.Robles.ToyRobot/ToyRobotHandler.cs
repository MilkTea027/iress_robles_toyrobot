using System;
using System.Diagnostics.CodeAnalysis;
using Iress.Robles.ToyRobot.Configurations;
using Iress.Robles.ToyRobot.DisplayVisual.Base.Interfaces;
using Iress.Robles.ToyRobot.DisplayVisual.Contexts;
using Iress.Robles.ToyRobot.DisplayVisual.Interfaces;
using Iress.Robles.ToyRobot.Instructions.Director;
using Microsoft.Extensions.DependencyInjection;

namespace Iress.Robles.ToyRobot
{
    /// <summary>
    /// The entry point class for the console application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ToyRobotHandler
    {
        private static IInstructionsDirector instructionDirector;
        private static IDisplayVisualChainProvider visualChainProvider;
        private static IDisplayVisualBaseStep displayVisualChain;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            try
            {
                SetupConfigurations();
                instructionDirector.BuildInstructions();
                displayVisualChain = visualChainProvider.GetDisplayVisualChain();
                var context = new DisplayVisualContext();

                DisplayVisual(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred");
                Console.WriteLine(ex.Message);
            }

            //// PREVENTS APPLICATION FROM JUST EXITING
            Console.Read();
        }

        private static void SetupConfigurations()
        {
            var services = new ServiceCollection();
            var injections = new InjectionConfiguration();
            var serviceProvider = injections.BuildServiceProvider(services);

            instructionDirector = serviceProvider.GetService<IInstructionsDirector>();
            visualChainProvider = serviceProvider.GetService<IDisplayVisualChainProvider>();
        }

        private static void DisplayVisual(DisplayVisualContext context)
        {
            Console.WriteLine();
            if (context.IsPlaced)
            {
                Console.WriteLine("Commands: MOVE, LEFT, RIGHT, REPORT");
            }

            Console.Write("User Input: ");
            context.InputCommand = Console.ReadLine().ToUpper().Trim();

            displayVisualChain.Process(context);

            DisplayVisual(context);
        }
    }
}
