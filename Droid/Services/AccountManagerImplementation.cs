using System;
using System.Linq;
using System.Collections.Generic;
using WhoBrokeIt.UI.Services;
using Xamarin.Auth;
using WhoBrokeIt.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AccountManagerImplementation))]
namespace WhoBrokeIt.Droid.Services
{
	public class AccountManagerImplementation : IAccountManager
	{
		public AccountManagerImplementation()
		{
		}

		public void EraseAll()
		{
			throw new NotImplementedException();
		}

		public string GetTokenForInstance(string instance)
		{
			var accounts = AccountStore.Create()
									   .FindAccountsForService("visualstudio");

			return accounts
				.FirstOrDefault(
					(arg) => arg.Username.Equals(instance))?.Properties["token"];
		}

		public void SaveTokenForInstance(string instance, string token)
		{
			var account = new Account(instance,
			new Dictionary<string, string>
			{
				{"token", token}
			});
			AccountStore.Create().Save(account, "visualstudio");
		}

	}
}
