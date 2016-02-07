using System.Collections.Generic;

namespace TrovServerExercise.Model {
	public partial class GildedRose {
		Inventory inventory = new Inventory();
		public uint MoneyInRegister {get; set;}
		public IEnumerable<Item> ItemsForSale {get {return inventory.items;}}
	}
}
