using MarsRoverCore.Dll.Commands;
using MarsRoverCore.Dll.Services.Position;

namespace MarsRoverCore.Dll.Services.Rover
{
    public interface IRover
    {
        public IPosition MainPosition { get; }
        void Move(IMoveCommand moveCommandFactory);
    }
}
