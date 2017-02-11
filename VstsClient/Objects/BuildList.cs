using System;
using System.Collections.Generic;

namespace Messier16.VstsClient.Objects
{
	public class User
	{
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public string UniqueName { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public bool IsContainer { get; set; }
	}

	public class Pool
	{
		public string Scope { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Queue
	{
		public Pool Pool { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class BuildProject : BasicProject
	{
		public int Revision { get; set; }
	}

	public class BasicBuild
	{
		public string quality { get; set; }
		public User AuthoredBy { get; set; }
		public Queue queue { get; set; }
		public string Uri { get; set; }
		public string Type { get; set; }
		public int Revision { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public BuildProject project { get; set; }
	}

	public class BuildList
	{
		public int Count { get; set; }
		public List<BasicBuild> Value { get; set; }
	}
}

