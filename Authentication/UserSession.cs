namespace FitnessPortal.Authentication
{
	/// <summary>
	/// UserSession class representing the user's session data.
	/// </summary>
	public class UserSession
	{
		/// <summary>
		/// Gets or sets the unique identifier for the user session.
		/// </summary>
		public Guid ID { get; set; }
		/// <summary>
		/// Gets or sets the required name of the user associated with the session.
		/// </summary>
		public required string Name { get; set; }
		/// <summary>
		/// Gets or sets the role of the user associated with the session.
		/// </summary>
		public int Role { get; set; }
	}
}
