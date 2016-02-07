using System.Collections.Generic;
using System.Linq;

namespace TrovServerExercise.Model {
	public partial class Inventory {
		public readonly List<Item> items = new List<Item>();//Invariant: contents not null.
		public static Inventory MakeExample () {
			var inventory = new Inventory();
			inventory.items.Add(new Item {Name = "Bat", Description = "A sturdy wooden bat.", Price = 105});
			inventory.items.Add(new Item {Name = "Ball", Description = "A white ball bound in red thread. Costs 100 less than the bat and in total they cost 110. How much does it cost?", Price = 5});
			return inventory;
		}
		public int StockOfItemsNamed (string name) {return items.Count(i => i.Name == name);}
	}
}
