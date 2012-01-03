using System;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace Raven.TestApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			using(var documentStore = new DocumentStore(){Url = "http://localhost:8080"})
			{
				documentStore.Initialize();
				using(DocumentSession documentSession = (DocumentSession)documentStore.OpenSession())
				{
					documentSession.Store(new Item{Name = "RavenDB Test1", Description = "NoSQL Document Store1"});
					documentSession.Store(new Item{Name = "RavenDB Test2", Description = "NoSQL Document Store2"});
					documentSession.Store(new Item2{ x = 1, y = 2});
					documentSession.Store(new Item2{ x = 3, y = 4});
					documentSession.SaveChanges();
				}
				
				using(var documentSession = documentStore.OpenSession())
				{
					Item item1 = documentSession.Load<Item>("items/1");
					Item item2 = documentSession.Load<Item>("items/2");
					Item2 item21 = documentSession.Load<Item2>("item2s/1");
					Item2 item22 = documentSession.Load<Item2>("item2s/2");
					Console.WriteLine("{0}\n{1}\n",item1,item2);
					Console.WriteLine("{0}\n{1}\n",item21,item22);
					
					var itemResult = documentSession.Query<Item>()
						.Where(item => item.Name == "RavenDB Test2")
							.First();
					Console.WriteLine("{0}",itemResult);
				}
			}			
		}
	}
	class Item
	{
		//public string Id{get;set;}
		public string Name{get;set;}
		public string Description{get;set;}
		public Item ()
		{
			//Id = Guid.NewGuid().ToString();
		}
		public override string ToString ()
		{
			return string.Format ("[Item: Name={0}, Description={1}]", Name, Description);
		}
	}
	class Item2
	{
		//public string Id{get;set;}
		public int x{get;set;}
		public int y{get;set;}
		public Item2 ()
		{
			//Id = Guid.NewGuid().ToString();
		}
		public override string ToString ()
		{
			return string.Format ("[Item2: x={0}, y={1}]", x, y);
		}
	}
}
