using System;

namespace Kohde.Assessment.Container
{
    /// <summary>
    /// Duplicate Registration Exception Class
    /// </summary>
    public class DuplicateRegistrationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateRegistrationException"/> class.
        /// </summary>
        public DuplicateRegistrationException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateRegistrationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DuplicateRegistrationException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateRegistrationException" /> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public DuplicateRegistrationException(string message, Exception inner) : base(message, inner) { }
    }
}