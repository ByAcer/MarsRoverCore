namespace MarsRoverCore.Dll.Command
{
    public interface ICommandManager
    {
        void CommandExecute(string command);
        string GetRoverPosition();
    }
}
