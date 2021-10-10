using MarsRoverCore.Dll.Commands;
using MarsRoverCore.Dll.Services.Position;

namespace MarsRoverCore.Dll.Services.Rover
{
    public class Rover : IRover
    {
        public IPosition MainPosition { get; private set; }

        public Rover(IPosition position)
        {
            MainPosition = position;
        }
        public void Move(IMoveCommand moveCommandFactory)
        {
            MainPosition = moveCommandFactory.Execute(MainPosition);
        }
    }
}
