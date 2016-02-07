using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class GildedRose {
		[TestFixture] public class Tests {
			[Datapoint] public GildedRose defaultGildedRose = new GildedRose();
			[Theory] public static void Invariants (GildedRose gildedRose) {
				Inventory.Tests.Invariants(gildedRose.inventory);
			}
		}
	}
}
