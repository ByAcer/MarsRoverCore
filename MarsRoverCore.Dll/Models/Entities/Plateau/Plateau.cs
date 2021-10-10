using MarsRoverCore.Dll.Services.Position;
using System;

namespace MarsRoverCore.Dll.Services.Surface
{
    public class Plateau : IPlateau
    {
        public int Width { get; }
        public int Length { get; }
        public Plateau(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public bool IsInside(IPosition position)
        {
            return position.Coordinate_X <= Width && position.Coordinate_Y <= Length
                   && position.Coordinate_X >= 0 && position.Coordinate_Y >= 0;
        }
    }
}
