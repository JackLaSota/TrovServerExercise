using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Inventory : IValidated {
		public readonly List<Item> items = new List<Item>();//Invariant: contents not null.
		public static Inventory MakeExample () {
			var inventory = new Inventory();
			inventory.items.Add(new Item {Name = "Bat", Description = "A sturdy wooden bat.", Price = 105});
			inventory.items.Add(new Item {Name = "Ball", Description = "A white ball bound in red thread. Costs 100 less than the bat and in total they cost 110. How much does it cost?", Price = 5});
			return inventory;
		}
		public int StockOfItemsNamed (string name) {return items.Count(i => i.Name == name);}
		public void AssertInvariants () {
			CollectionAssert.AllItemsAreNotNull(items);
			items.ForEach(Item.Tests.Invariants);
		}
		public Item ItemMatching (Item description) {return items.FirstOrDefault(i => i.InterchangeableWith(description));}
		public void Remove (Item item) {items.Remove(item);}
	}
}
