using System;
using System.Collections.Generic;

namespace Messier16.VstsClient.Objects
{
	public class BasicRepository
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public BasicProject Project { get; set; }
		public string RemoteUrl { get; set; }
		public string DefaultBranch { get; set; }
	}

	public class RepositoriesList
	{
		public int Count { get; set; }
		public List<BasicRepository> Value { get; set; }
	}
}

