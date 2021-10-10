using MarsRoverCore.Dll.Model.Constants;
using static MarsRoverCore.Dll.Model.Constants.Enums;

namespace MarsRoverCore.Dll.Services.Position
{
    public class Position : IPosition
    {
        public int Coordinate_X { get;}
        public int Coordinate_Y { get;}
        public Enums.DirectionsOfRoverTypes Direction { get;}

        public Position(int coordinate_X, int coordinate_Y, DirectionsOfRoverTypes direction)
        {
            Coordinate_X = coordinate_X;
            Coordinate_Y = coordinate_Y;
            Direction = direction;
        }
    }
}
