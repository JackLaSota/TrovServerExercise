using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Item {
		[TestFixture] public class Tests {
			[Datapoint] public Item defaultItem = new Item();
			[Theory] public static void Invariants (Item item) {
				Assert.NotNull(item.Name);
				Assert.NotNull(item.Description);
				Assert.Greater(item.Price, 0);
			}
		}
	}
}
