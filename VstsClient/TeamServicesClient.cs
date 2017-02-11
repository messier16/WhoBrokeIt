using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Messier16.VstsClient.Objects;
using static Newtonsoft.Json.JsonConvert;

namespace Messier16.VstsClient
{
	public class TeamServicesClient
	{
		#region Url templates
		const string Version = "1.0";
		private const string BaseAddress = "https://{0}.visualstudio.com/DefaultCollection";
		private const string ListOfProjects = "_apis/projects?api-version=" + Version; //"[&stateFilter{string}&$top={integer}&skip={integer}]"
		#endregion
		private string _endpoint;
		private string _token;
		private HttpClient _client; 

		public TeamServicesClient(string instance, string token)
		{
			_endpoint = String.Format(BaseAddress, instance);
			_token = token;
			_client = new HttpClient
			{
				BaseAddress = new Uri(_endpoint)
			};
			_client.DefaultRequestHeaders.Authorization = CreateAuth(token);
		}

		AuthenticationHeaderValue CreateAuth(string token)
		{
			string b64 = Convert.ToBase64String(
					 System.Text.Encoding.UTF8.GetBytes(
						 string.Format(":" + token)));
			return new AuthenticationHeaderValue("Basic", b64);
		}

		public async Task<ProjectList> GetProjects()
		{
			string response = await _client.GetStringAsync(ListOfProjects);
			var actualResponse = DeserializeObject<ProjectList>(response);
			return actualResponse;
		}

	}
}
