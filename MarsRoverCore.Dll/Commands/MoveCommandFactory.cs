using MarsRoverCore.Dll.Model.Constants;

namespace MarsRoverCore.Dll.Commands
{
    public class MoveCommandFactory
    {
        public static bool TryCommand(char command, out IMoveCommand moveCommand)
        {
            switch (char.ToUpper(command))
            {
                case (char)Enums.ControlOfRoverTypes.TurnRight:
                    moveCommand = new TurnRightCommand();
                    return true;
                case (char)Enums.ControlOfRoverTypes.TurnLeft:
                    moveCommand = new TurnLeftCommand();
                    return true;
                case (char)Enums.ControlOfRoverTypes.MoveForward:
                    moveCommand = new MoveForwardCommand();
                    return true;
                default:
                    throw new System.ArgumentException(Messages.ER_ROVER_MISSING_PARAMETERS_IN_NEWPOSITIONROVER);
            }
        }
    }
}
