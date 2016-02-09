using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class GildedRose {
		[TestFixture] public class Tests {
			[Datapoint] public GildedRose defaultGildedRose = new GildedRose();
			[Datapoint] public GildedRose example = new GildedRose();
			[Theory] public static void Invariants (GildedRose gildedRose) {
				Assume.That(gildedRose != null);
				// ReSharper disable once PossibleNullReferenceException
				Assert.NotNull(gildedRose.inventory);
				Inventory.Tests.Invariants(gildedRose.inventory);
				Assert.NotNull(gildedRose.customerRegistry);
				CustomerRegistry.Tests.Invariants(gildedRose.customerRegistry);
			}
		}
	}
}
