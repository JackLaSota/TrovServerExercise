using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Inventory {
		[TestFixture] public class Tests {
			[Datapoint] Inventory defaultInventory = new Inventory();
			[Datapoint] Inventory example = MakeExample();
			[Theory] public static void Invariants (Inventory inventory) {
				Assume.That(inventory != null);
				// ReSharper disable once PossibleNullReferenceException
				CollectionAssert.AllItemsAreNotNull(inventory.items);
				inventory.items.ForEach(Item.Tests.Invariants);
			}
			[Test] public void StockTest () {
				var inventory = new Inventory();
				Assert.AreEqual(0, inventory.StockOfItemsNamed("a"));
				inventory.items.Add(new Item {Name = "a"});
			}
		}
	}
}
