using MarsRoverCore.Dll.Command;
using MarsRoverCore.Dll.Commands;
using MarsRoverCore.Dll.Services.Position;
using MarsRoverCore.Dll.Services.Rover;
using MarsRoverCore.Dll.Services.Surface;
using Microsoft.Extensions.DependencyInjection;
using System;
using MarsRoverCore.Dll.Model.Constants;
using MarsRoverCore.Dll.Infrastructure.Helpers;

namespace MarsRoverCore.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommandManager, CommandManager>()
                .AddSingleton<IMoveCommand, MoveForwardCommand>()
                .AddSingleton<IPlateau, Plateau>()
                .AddSingleton<IPosition, Position>()
                .AddSingleton<IRover, Rover>()
                .BuildServiceProvider();

            IPlateau plateau = CreatePlateau();
            IPosition position = CreatePosition();
            IRover rover = new Rover(position);
            ICommandManager commandCenter = new CommandManager(rover, plateau);

            commandCenter.CommandExecute(GetCommands());
            Console.WriteLine($"The New Position Of The Rover is \"{commandCenter.GetRoverPosition()}\"");
        }

        private static string GetCommands()
        {
            Console.Write("Enter Commands (ex: \"LMLMLMLMM\"):");
            var commands = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(commands))
                throw new Exception(Messages.ER_NULL_PARAMETER);
            return commands;
        }

        private static IPlateau CreatePlateau()
        {
            Console.Write("Enter Plateau Dimensions (ex: \"5 (Width) x 5 (Length)\"):");
            int width, length;
            GetPlateauInformation(out width, out length);
            return new Plateau(width, length);
        }

        private static void GetPlateauInformation(out int width, out int length)
        {
            string sizeText = Console.ReadLine();
            var result = CommandParseHelper.ParsingParameters(sizeText);
            if (result.Length != 2)
                throw new Exception(Messages.ER_BAD_PARAMETER);
            width = int.Parse(result[0]);
            length = int.Parse(result[1]);
        }

        private static IPosition CreatePosition()
        {
            Console.Write("Enter Rover Initial Position (ex: \"1(Coordinate X) 2(Coordinate Y) N(Direction)\"):");
            int coordinate_X, coordinate_Y;
            Enums.DirectionsOfRoverTypes direction;
            GetPositionInformation(out coordinate_X, out coordinate_Y, out direction);
            return new Position(coordinate_X, coordinate_Y, direction);
        }

        private static void GetPositionInformation(out int coordinate_X, out int coordinate_Y, out Enums.DirectionsOfRoverTypes direction)
        {
            string sizeText = Console.ReadLine();
            var result = CommandParseHelper.ParsingParameters(sizeText);
            if (result.Length != 3)
                throw new Exception(Messages.ER_BAD_PARAMETER);
            coordinate_X = ConsoleChechAndGetInt(result[0]);
            coordinate_Y = ConsoleChechAndGetInt(result[1]);
            direction = (Enums.DirectionsOfRoverTypes)Enum.ToObject(typeof(Enums.DirectionsOfRoverTypes), ConsoleChechAndGetChar(result[2].ToString()));
        }

        private static int ConsoleChechAndGetInt(string command)
        {
            int resultNumber;
            if (string.IsNullOrWhiteSpace(command))
                throw new Exception(Messages.ER_NULL_PARAMETER);
            command = command.Trim();
            if (command.Length != 1)
                throw new Exception(Messages.ER_BAD_PARAMETER);
            _ = int.TryParse(command, out resultNumber) ? resultNumber : throw new Exception(Messages.ER_NULL_PARAMETER);
            return resultNumber;
        }

        private static char ConsoleChechAndGetChar(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new Exception(Messages.ER_NULL_PARAMETER);
            command = command.Trim();
            if (command.Length != 1)
                throw new Exception(Messages.ER_BAD_PARAMETER);
            return command[0];
        }
    }
}
