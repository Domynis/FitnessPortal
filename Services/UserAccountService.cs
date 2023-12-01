using FitnessPortal.Data;
using FitnessPortal.Data.DTOs;
using FitnessPortal.Data.Entities;
using FitnessPortal.Services;
using Microsoft.EntityFrameworkCore;

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
				model.Roles = user.Roles;
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
			User user = new User();
			user.ID = userDTO.UserID;
			user.UserName = userDTO.UserName;
			user.Password = userDTO.Password;
			user.Roles = userDTO.Roles;
			var modelUser = AddOrUpdateUser(user);

			UserDetails userDetails = new UserDetails();
			userDetails.ID = userDTO.UserDetailsID;
			userDetails.UserID = modelUser.ID;
			userDetails.FirstName = userDTO.FirstName;
			userDetails.LastName = userDTO.LastName;
			userDetails.Gender = userDTO.Gender;
			userDetails.Age = userDTO.Age;
			userDetails.Weight = userDTO.Weight;
			userDetails.Height = userDTO.Height;
			userDetails.BMI = (userDTO.Weight != null && userDTO.Height != null) ? BMICalculator.calc((float)userDTO.Height, (float)userDTO.Weight) : null;
			userDetails.KCalGoal = userDTO.KCalGoal;
			AddOrUpdateUserDetails(userDetails);
		}

		public async Task<User?> GetUserDetails(User user)
		{
			var dbUser = await _context.Users.Include(x => x.UserDetails).FirstOrDefaultAsync(x => x.ID == user.ID); 
			return dbUser;
		}



		public async Task<User?> Login(User user)
		{
			var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
			return dbUser;
		}
	}
}
