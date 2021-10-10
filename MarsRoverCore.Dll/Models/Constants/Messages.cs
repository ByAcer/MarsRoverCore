namespace MarsRoverCore.Dll.Model.Constants
{
    public class Messages
    {
        #region General
        
        public const string ER_NULL_PARAMETER = "Null or Empty Parameter";
        public const string ER_BAD_PARAMETER = "Bad Parameter";

        #endregion

        #region PLATEU MESSAGES

        public const string ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR = "Incorrect parameter was given in the PLATEAU Constructor";

        #endregion

        #region ROVER MESSAGES

        public const string ER_ROVER_MISSING_PARAMETERS_IN_NEWPOSITIONROVER = "Missing Parameter(s) in New Position Rover";
        public const string ER_ROVER_GREATER_THAN_PLATEU_LIMIT = "The given coordinate exceeds the limits.";
        
        #endregion

    }
}
