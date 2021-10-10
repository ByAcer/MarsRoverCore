using MarsRoverCore.Dll.Commands;
using MarsRoverCore.Dll.Model.Constants;
using MarsRoverCore.Dll.Services.Rover;
using MarsRoverCore.Dll.Services.Surface;
using System;

namespace MarsRoverCore.Dll.Command
{
    public class CommandManager : ICommandManager
    {
        private readonly IRover _rover;
        private readonly IPlateau _plateau;
        private bool _inValidCommand;

        public CommandManager(IRover rover, IPlateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
            IsRoverInsidePlateau();
        }

        public void CommandExecute(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException(Messages.ER_NULL_PARAMETER);
            foreach (char c in command)
            {
                ProcessCommand(c);
                if (_inValidCommand)
                    throw new ArgumentException(Messages.ER_BAD_PARAMETER);
            }
        }
        private void ProcessCommand(char command)
        {
            if (MoveCommandFactory.TryCommand(command, out IMoveCommand moveCommandFactory))
            {
                _rover.Move(moveCommandFactory);
                IsRoverInsidePlateau();
            }
            else
                _inValidCommand = true;
        }
        private void IsRoverInsidePlateau()
        {
            if (!_plateau.IsInside(_rover.MainPosition))
                _inValidCommand = true;
        }
        public string GetRoverPosition() =>
           $"{_rover.MainPosition.Coordinate_X} {_rover.MainPosition.Coordinate_Y} {(char)_rover.MainPosition.Direction}";
    }
}
