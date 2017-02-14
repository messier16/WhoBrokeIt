using System;
using System.Collections.Generic;

namespace Messier16.VstsClient.Objects
{

	public class CommitUser
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTimeOffset Date { get; set; }
	}

	public class ChangeCounts
	{
		public int? Edit { get; set; }
		public int? Add { get; set; }
		public int? Delete { get; set; }
	}

	public class Commit
	{
		public string CommitId { get; set; }
		public CommitUser Author { get; set; }
		public CommitUser Committer { get; set; }
		public string Comment { get; set; }
		public ChangeCounts ChangeCounts { get; set; }
		public string Url { get; set; }
		public string RemoteUrl { get; set; }
	}

	public class CommitList
	{
		public int Count { get; set; }
		public List<Commit> Value { get; set; }
	}

}
