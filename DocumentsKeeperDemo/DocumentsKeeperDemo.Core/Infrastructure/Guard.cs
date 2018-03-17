using System;

namespace DocumentsKeeperDemo.Core.Infrastructure
{
    /// <summary>
    /// The guard class.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Logs error message and throw argument exception if an 
        /// argument is null.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argumentName">The name of an argument.</param>
        public static void ArgumentNotNull(object arg, string argumentName)
        {
            if(arg == null)
            {
                throw new ArgumentNullException($"{argumentName} is null argument.");
            }
        }

        /// <summary>
        /// Checks if a string is null or epmty. 
        /// If a string is null or empty logs error and throws an exception.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="argumentName">The name of an argument.</param>
        public static void StringIsNotNullOrNotEmpty(string str, string argumentName)
        {
            Guard.ArgumentNotNull(str, argumentName);

            if(str == string.Empty)
            {
                throw new ArgumentException($"Argument {argumentName} is empty string.");
            }
        }

        /// <summary>
        /// Checks does argument is empty guid or not.
        /// If true then throws an exception.
        /// </summary>
        /// <param name="guid">The guid.</param>
        /// <param name="argumentName">The name of an argument.</param>
        public static void NotEmptyGuid(Guid guid, string argumentName)
        {
            if(guid == Guid.Empty)
            {
                throw new ArgumentException($"Argument {argumentName} is empty guid.");
            }
        }
    }
}
