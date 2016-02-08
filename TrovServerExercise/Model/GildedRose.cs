using System.Collections.Generic;
using JetBrains.Annotations;

namespace TrovServerExercise.Model {
	public partial class GildedRose {
		[NotNull] Inventory inventory = new Inventory();
		[NotNull] CustomerRegistry customerRegistry = new CustomerRegistry();
		// ReSharper disable once UnusedAutoPropertyAccessor.Global
		public uint MoneyInRegister {get; set;}
		public IEnumerable<Item> ItemsForSale {get {return inventory.items;}}
		public static GildedRose MakeExample () {
			return new GildedRose {
				inventory = Inventory.MakeExample(),
				MoneyInRegister = 1000
			};
		}
	}
}
