using System.Collections.Generic;

namespace TrovServerExercise.Model {
	public partial class GildedRose {
		Inventory inventory = new Inventory();
		public IEnumerable<Item> ItemsForSale {get {return inventory.items;}}
	}
}
