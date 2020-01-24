using System;

namespace Kohde.Assessment.Container
{
    /// <summary>
    /// Container Interface
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Registers and adds a type in the container.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <exception cref="Register{TClass}">thrown when an instance of a type is already registered.</exception>
        /// <remarks>No remarks specified</remarks>
        void Register<TClass>();

        /// <summary>
        /// Registers a specified service / interface against a concrete class
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <exception cref="DuplicateRegistrationException">thrown when the service of specified type is already registered.</exception>
        /// <remarks>
        /// An instance of the class is not created in this method. It only associates a interface with a concrete class. 
        /// So when the interface is used, it will be injected with an instance of the concrete class
        /// </remarks>
        void Register<TService, TClass>() where TClass : TService;

        /// <summary>
        /// Registers a service instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <exception cref="DuplicateRegistrationException">thrown when the service of specified type is already registered.</exception>
        /// <remarks>No remarks specified</remarks>
        void RegisterInstance<TService>(TService instance);

        /// <summary>
        /// Resolves the instance based on the service type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>
        /// an instance of TService
        /// </returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resolves an instance based on the specified type.
        /// </summary>
        /// <param name="type">The type of the service.</param>
        /// <returns>
        /// an instance of the type specified
        /// </returns>
        /// <exception cref="System.NotSupportedException">No registration found for service of Type specified</exception>
        object Resolve(Type type);
    }
}