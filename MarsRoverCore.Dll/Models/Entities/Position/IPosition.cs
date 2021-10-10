using static MarsRoverCore.Dll.Model.Constants.Enums;

namespace MarsRoverCore.Dll.Services.Position
{
    public interface IPosition
    {
        int Coordinate_X { get;}
        int Coordinate_Y { get;}
        DirectionsOfRoverTypes Direction { get;}
    }
}
