using FitnessPortal.Data;
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace FitnessPortal.Services
{
	public class UserAccountService : IUserAccountService
	{
		private readonly ApplicationDbContext _context;
		public UserAccountService(ApplicationDbContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

		private User AddOrUpdateUser(User user)
		{
			var model = user.ID != Guid.Empty ? _context.Users.Where(x => x.ID == user.ID).FirstOrDefault() : user;
			if (model?.ID != Guid.Empty)
			{
				model.UserName = user.UserName;
				model.Password = user.Password;
				model.Role = user.Role;
			}
			else
			{
				_context.Users.Add(model);
			}
			_context.SaveChanges();
			return model;
		}

		private UserDetails AddOrUpdateUserDetails(UserDetails userDetails)
		{
			var model = userDetails.ID != Guid.Empty ? _context.UsersDetails.Where(x => x.ID == userDetails.ID).FirstOrDefault() : userDetails;
			if (model?.ID != Guid.Empty)
			{
				model.FirstName = userDetails.FirstName;
				model.LastName = userDetails.LastName;
				model.Gender = userDetails.Gender;
				model.Age = userDetails.Age;
				model.Weight = userDetails.Weight;
				model.Height = userDetails.Height;
				model.BMI = userDetails.BMI;
				model.KCalGoal = userDetails.KCalGoal;
			}
			else
			{
				_context.UsersDetails.Add(model);
			}
			_context.SaveChanges();
			return model;
		}

		public void AddOrUpdateUserDTO(UserDTO userDTO)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				userDTO.Password = PasswordHasher.GetHash(sha256Hash, userDTO.Password);
			}

			User user = new()
			{
				ID = userDTO.UserID,
				UserName = userDTO.UserName,
				Password = userDTO.Password,
				Role = userDTO.Role
			};
			var modelUser = AddOrUpdateUser(user);

			UserDetails userDetails = new()
			{
				ID = userDTO.UserDetailsID,
				UserID = modelUser.ID,
				FirstName = userDTO.FirstName,
				LastName = userDTO.LastName,
				Gender = userDTO.Gender,
				Age = userDTO.Age,
				Weight = userDTO.Weight,
				Height = userDTO.Height,
				BMI = (userDTO.Weight != null && userDTO.Height != null) ? BMICalculator.Calc(userDTO.Height ?? 0, userDTO.Weight ?? 0) : 0,
				KCalGoal = userDTO.KCalGoal
			};
			AddOrUpdateUserDetails(userDetails);
		}

		public async Task<User?> GetUserDetails(User user)
		{
			var dbUser = await _context.Users.Include(x => x.UserDetails).FirstOrDefaultAsync(x => x.ID == user.ID);
			return dbUser;
		}

		public UserDTO? GetUserDTO(Guid ID)
		{
			var result = _context.Users.Include(x => x.UserDetails)
				.FirstOrDefault(x => x.ID == ID);
			return UserDTO.From(result);
		}

		public async Task<User?> Login(User user)
		{

			using (SHA256 sha256Hash = SHA256.Create())
			{
				var dbUser = await _context.Users.FirstOrDefaultAsync(
					x => x.UserName == user.UserName &&
					x.Password.Equals(PasswordHasher.GetHash(sha256Hash, user.Password)));
				return dbUser;
			}
		}
	}
}
