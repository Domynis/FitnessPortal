using FitnessPortal.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace FitnessPortal.Authentication
{
	/// <summary>
	/// CustomAuthenticationStateProvider class responsible for managing authentication state. 
	/// </summary>
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ProtectedSessionStorage _sessionStorage;
		private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

		/// <summary>
		/// Constructor for CustomAuthenticationStateProvider.
		/// </summary>
		/// <param name="sessionStorage">ProtectedSessionStorage instance for storing user session data.</param>
		public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}
		/// <summary>
		/// Gets the authentication state asynchronously based on the user session.
		/// </summary>
		/// <returns>Task containing the AuthenticationState.</returns>
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
            try
			{
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
				var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

				if (userSession == null)
				{
					return await Task.FromResult(new AuthenticationState(_anonymous));
				}
				else
				{
					var claimsPrincipal = new ClaimsPrincipal(
						new ClaimsIdentity(
							new List<Claim>
							{
								new (ClaimTypes.Name, userSession.Name),
								new (ClaimTypes.Role, userSession.Role.GetRoleString()),
								new (ClaimTypes.NameIdentifier, userSession.ID.ToString())
							}, "CustomAuth"));
					return await Task.FromResult(new AuthenticationState(claimsPrincipal));
				}
			}
			catch (Exception)
			{
				Console.Write("Error @getauth");
				return await Task.FromResult(new AuthenticationState(_anonymous));
			}
		}
		/// <summary>
		/// Authenticates the user by updating the user session and notifying of the authentication state change.
		/// </summary>
		/// <param name="userSession">UserSession object representing the user's session.</param>
		public async Task AuthenticateUser(UserSession? userSession)
		{
			ClaimsPrincipal claimsPrincipal;
			if (userSession != null)
			{
				// Set the user session in protected session storage
				await _sessionStorage.SetAsync("UserSession", userSession);
				// Create a ClaimsPrincipal based on the user session data
				claimsPrincipal = new ClaimsPrincipal(
						new ClaimsIdentity(
							new List<Claim>
							{
								new (ClaimTypes.Name, userSession.Name),
								new (ClaimTypes.Role, userSession.Role.GetRoleString()),
								new (ClaimTypes.NameIdentifier, userSession.ID.ToString())
							}, "CustomAuth"));
			}
			else
			{
				// If no user session, delete the session data
				await _sessionStorage.DeleteAsync("UserSession");
				// Use the anonymous ClaimsPrincipal
				claimsPrincipal = _anonymous;
			}
			// Notify of the authentication state change
			NotifyAuthenticationStateChanged(
				Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
	}
}
