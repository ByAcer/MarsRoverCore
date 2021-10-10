using MarsRoverCore.Dll.Model.Constants;
using MarsRoverCore.Dll.Services.Position;
using System;

namespace MarsRoverCore.Dll.Commands
{
    internal class TurnLeftCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            return currentPosition.Direction switch
            {
                Enums.DirectionsOfRoverTypes.North => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.West),
                Enums.DirectionsOfRoverTypes.East => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.North),
                Enums.DirectionsOfRoverTypes.South => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.East),
                Enums.DirectionsOfRoverTypes.West => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.South),
                _ => throw new NotSupportedException(Messages.ER_BAD_PARAMETER),
            };
        }
    }
}
