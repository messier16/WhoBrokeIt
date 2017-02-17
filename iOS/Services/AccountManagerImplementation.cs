using System;
using System.Linq;
using System.Collections.Generic;
using WhoBrokeIt.UI.Services;
using Xamarin.Auth;
using WhoBrokeIt.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AccountManagerImplementation))]
namespace WhoBrokeIt.iOS.Services
{
	public class AccountManagerImplementation : IAccountManager
	{
		public AccountManagerImplementation()
		{
		}

		public void EraseAll()
        {
            var accStore = AccountStore.Create();
            var accounts = accStore.FindAccountsForService("visualstudio");
            foreach (var item in accounts)
            {
                accStore.Delete(item, "visualstudio");
            }
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
			AccountStore.Create().Save(account,"visualstudio");
		}

	}
}
