using MarsRoverCore.Dll.Model.Constants;
using MarsRoverCore.Dll.Services.Position;
using System;

namespace MarsRoverCore.Dll.Commands
{
    public class MoveForwardCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            return currentPosition.Direction switch
            {
                Enums.DirectionsOfRoverTypes.North => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y + 1, currentPosition.Direction),
                Enums.DirectionsOfRoverTypes.East => new Position(currentPosition.Coordinate_X + 1, currentPosition.Coordinate_Y, currentPosition.Direction),
                Enums.DirectionsOfRoverTypes.South => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y - 1, currentPosition.Direction),
                Enums.DirectionsOfRoverTypes.West => new Position(currentPosition.Coordinate_X - 1, currentPosition.Coordinate_Y, currentPosition.Direction),
                _ => throw new NotSupportedException(Messages.ER_BAD_PARAMETER),
            };
        }
    }
}
