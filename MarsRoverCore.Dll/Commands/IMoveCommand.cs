using MarsRoverCore.Dll.Services.Position;

namespace MarsRoverCore.Dll.Commands
{
    public interface IMoveCommand
    {
        IPosition Execute(IPosition currentPosition);
    }
}
