﻿using FitnessPortal.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace FitnessPortal.Authentication
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ProtectedSessionStorage _sessionStorage;
		private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
        //private bool authenticationStateChanged = false;
        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}
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

		public async Task AuthenticateUser(UserSession userSession)
		{
			ClaimsPrincipal claimsPrincipal;
			if (userSession != null)
			{
				await _sessionStorage.SetAsync("UserSession", userSession);
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
				await _sessionStorage.DeleteAsync("UserSession");
				claimsPrincipal = _anonymous;
			}
            NotifyAuthenticationStateChanged(
				Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}
	}
}