﻿using Raven.Client.Document;
using Xunit;

namespace Raven.Tests.MailingList
{
	public class Stats : RavenTest
	{
		[Fact]
		public void Embedded()
		{
			using(var store = NewDocumentStore())
			{
				Assert.NotNull(store.DatabaseCommands.GetStatistics());
			}
		}

		[Fact]
		public void Server()
		{
			using(GetNewServer())
			using (var store = new DocumentStore
			{
				Url = "http://localhost:8080"
			}.Initialize())
			{
				Assert.NotNull(store.DatabaseCommands.GetStatistics());
			}
		}
	}
}