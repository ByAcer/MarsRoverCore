using MarsRoverCore.Dll.Model.Constants;
using MarsRoverCore.Dll.Services.Position;
using System;

namespace MarsRoverCore.Dll.Commands
{
    internal class TurnRightCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            return currentPosition.Direction switch
            {
                Enums.DirectionsOfRoverTypes.North => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.East),
                Enums.DirectionsOfRoverTypes.East => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.South),
                Enums.DirectionsOfRoverTypes.South => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.West),
                Enums.DirectionsOfRoverTypes.West => new Position(currentPosition.Coordinate_X, currentPosition.Coordinate_Y, Enums.DirectionsOfRoverTypes.North),
                _ => throw new NotSupportedException(Messages.ER_BAD_PARAMETER),
            };
        }
    }
}
