using System;

namespace VisitingStolac.Common
{
    /// <summary>
    /// Custom exception 
    /// if key already exists in the db
    /// </summary>
    public class KeyAlreadyExistsException : Exception
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public KeyAlreadyExistsException()
        {
        }

        /// <summary>
        /// constructor with 1 parameter
        /// </summary>
        /// <param name="message">exception message</param>
        public KeyAlreadyExistsException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// constructor with 2 parameters
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">instance of <see cref="Exception"/></param>
        public KeyAlreadyExistsException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
