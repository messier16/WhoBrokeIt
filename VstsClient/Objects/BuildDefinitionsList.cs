using System;
using System.Collections.Generic;

namespace Messier16.VstsClient.Objects
{
	public class BuildDefinitionUser : User
	{
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

	public class BasicBuildDefinition
	{
		public string quality { get; set; }
		public BuildDefinitionUser AuthoredBy { get; set; }
		public Queue queue { get; set; }
		public string Uri { get; set; }
		public string Type { get; set; }
		public int Revision { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public BasicProject project { get; set; }
	}

	public class BuildDefinitionsList
	{
		public int Count { get; set; }
		public List<BasicBuildDefinition> Value { get; set; }
	}
}

