using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Customer {
		[TestFixture] public class Tests {
			[Datapoint] Customer example = MakeExample();
			[Theory] public static void Invariants (Customer customer) {
				Assert.NotNull(customer.name);
				Assert.NotNull(customer.username);
				Assert.NotNull(customer.password);
			}
		}
	}
}
