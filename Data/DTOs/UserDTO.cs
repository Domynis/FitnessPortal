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
		public int Roles { get; set; }
		[Required]
		public string FirstName {  get; set; }
		[Required]
		public string LastName { get; set; }
		public string? Gender { get; set; }
		public int? Age {  get; set; }
		public float? Weight { get; set; }
		public float? Height { get; set; }
		public float? BMI { get; set; }
		public int? KCalGoal { get; set; }
	}
}
