using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;

namespace FitnessPortal.Services
{
    public interface IUserAccountService
    {
        Task<User?> Login(User user);
		Task<User?> GetUserDetails(User user);
		void AddOrUpdateUserDTO(UserDTO userDTO);
    }
}
