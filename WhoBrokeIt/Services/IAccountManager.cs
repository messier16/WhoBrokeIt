
namespace WhoBrokeIt.UI.Services
{
	public interface IAccountManager
	{
		void SaveTokenForInstance(string instance, string token);
		
		string GetTokenForInstance(string instance);

		void EraseAll();
	}
}