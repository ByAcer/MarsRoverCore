using MarsRoverCore.Dll.Model.Constants;
using System;

namespace MarsRoverCore.Dll.Infrastructure.Helpers
{
    public static class CommandParseHelper
    {
        public static string[] ParsingParameters(string param)
        {
            if (String.IsNullOrEmpty(param))
                throw new ArgumentNullException(Messages.ER_NULL_PARAMETER);
            string[] parseString = param.Split(' ');
            return parseString;
        }
    }
}
