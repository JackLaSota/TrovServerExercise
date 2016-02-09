using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Item {
		[TestFixture] public class Tests {
			[Datapoint] public Item defaultItem = new Item();
			[Theory] public static void Invariants (Item item) {
				Assume.That(item != null);
				// ReSharper disable once PossibleNullReferenceException
				item.AssertInvariants();
			}
		}
	}
}
