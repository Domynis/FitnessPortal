// Importing necessary namespaces for the interface
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using System;
using System.Threading.Tasks;

// Defining an interface for user account-related operations within the Fitness Portal application
namespace FitnessPortal.Services
{
    /// <summary>
    /// Interface for managing user account-related operations such as login, user details retrieval,
    /// and updating user information within the Fitness Portal application.
    /// </summary>
    public interface IUserAccountService
    {
        /// <summary>
        /// Asynchronously attempts to authenticate a user by performing a login operation.
        /// </summary>
        /// <param name="user">The User object containing login credentials.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, when completed,
        /// contains a nullable User object representing the authenticated user.
        /// </returns>
        Task<User?> Login(User user);

        /// <summary>
        /// Asynchronously retrieves detailed information about a user.
        /// </summary>
        /// <param name="user">The User object for which to retrieve details.</param>
        /// <returns>
        /// A task representing the asynchronous operation that, when completed,
        /// contains a nullable User object representing the user details.
        /// </returns>
        Task<User?> GetUserDetails(Guid userID);

        /// <summary>
        /// Adds or updates user information based on the provided UserDTO object.
        /// </summary>
        /// <param name="userDTO">The UserDTO object containing user information to be added or updated.</param>
        void AddOrUpdateUserDTO(UserDTO userDTO);

        /// <summary>
        /// Retrieves a UserDTO object based on the provided user ID.
        /// </summary>
        /// <param name="UserID">The unique identifier of the user.</param>
        /// <returns>
        /// A nullable UserDTO object representing user information associated with the provided user ID.
        /// </returns>
        UserDTO? GetUserDTO(Guid UserID);
    }
}
