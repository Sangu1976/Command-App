using System;
using System.Collections.Generic;

namespace EkvipCommandApp
{
    // Base interface for all commands that can be executed and undone
    interface ICommand
    {
        int Execute(int current);
        int Undo(int current);
    }

    // Increments result by 1
    class IncrementCommand : ICommand
    {
        public int Execute(int current) => current + 1;
        public int Undo(int current) => current - 1;
    }

    // Decrements result by 1
    class DecrementCommand : ICommand
    {
        public int Execute(int current) => current - 1;
        public int Undo(int current) => current + 1;
    }

    // Double the result
    class DoubleCommand : ICommand
    {
        public int Execute(int current) => current * 2;
        public int Undo(int current) => current / 2; // Assumes integer division
    }

    // Adds a random number between 1 and 10, and stores it for undo
    class RandAddCommand : ICommand
    {
        private int _randValue;
        private static Random _rng = new Random();

        public int Execute(int current)
        {
            _randValue = _rng.Next(1, 11); // Random number between 1 and 10
            return current + _randValue;
        }

        public int Undo(int current) => current - _randValue;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Check if an initial value is provided via command line
            if (args.Length == 0 || !int.TryParse(args[0], out int result))
            {
                Console.WriteLine("Please provide an initial integer value as a command-line argument.");
                return;
            }

            // Stack to keep track of commands for undo feature

            Stack<ICommand> commandHistory = new Stack<ICommand>();

            while (true)
            {
                Console.Write("Enter command (increment, decrement, double, randadd, undo): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                // Check which command to execute
                ICommand command = input switch
                {
                    "increment" => new IncrementCommand(),
                    "decrement" => new DecrementCommand(),
                    "double" => new DoubleCommand(),
                    "randadd" => new RandAddCommand(),
                    "undo" => null,
                    _ => null
                };

                if (input == "undo")
                {
                    if (commandHistory.Count > 0)
                    {
                        ICommand lastCommand = commandHistory.Pop();
                        result = lastCommand.Undo(result);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to undo.");
                    }
                }
                else if (command != null)
                {
                    result = command.Execute(result);
                    commandHistory.Push(command);
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }

                // Shows the Current result
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
