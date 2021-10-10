using MarsRoverCore.Dll.Services.Position;

namespace MarsRoverCore.Dll.Services.Surface
{
    public interface IPlateau
    {
        int Width { get; }
        int Length { get;}
        bool IsInside(IPosition position);
    }
}
