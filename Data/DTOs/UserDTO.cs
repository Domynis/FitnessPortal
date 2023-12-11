using FitnessPortal.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FitnessPortal.Data.DTOs
{
	public class UserDTO
	{
		public Guid UserID { get; set; }
		public Guid UserDetailsID {  get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password{ get; set; }
		[Required]
		public int Role { get; set; }
		[Required]
		public string FirstName {  get; set; }
		[Required]
		public string LastName { get; set; }
		public string? Gender { get; set; }
		public int? Age {  get; set; }
		public double? Weight { get; set; }
		public double? Height { get; set; }
		public double? BMI { get; set; }
		public int? KCalGoal { get; set; }

		public static UserDTO From(User user)
		{
			return new UserDTO
			{
				UserName = user.UserName,
				Role = user.Role,
				UserID = user.ID,
				FirstName = user.UserDetails.FirstName,
				LastName = user.UserDetails.LastName,
				Age = user.UserDetails.Age,
				Gender = user.UserDetails.Gender,
				Weight = user.UserDetails.Weight,
				Height = user.UserDetails.Height,
				KCalGoal = user.UserDetails.KCalGoal,
				UserDetailsID = user.UserDetails.ID,
			};
		}
	}
}
