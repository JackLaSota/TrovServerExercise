using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class CustomerRegistry {
		[TestFixture] public class Tests {
			[Datapoint] public CustomerRegistry example = MakeExample();
			[Theory] public static void Invariants (CustomerRegistry registry) {
				Assume.That(registry != null);
				// ReSharper disable once PossibleNullReferenceException
				Assert.NotNull(registry.customers);
				CollectionAssert.AllItemsAreNotNull(registry.customers);
				registry.customers.ForEach(Customer.Tests.Invariants);
			}
		}
	}
}
