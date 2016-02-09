using NUnit.Framework;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	public partial class Receipt {
		[TestFixture] public class Tests {
			[Datapoint] public Receipt example = new Receipt(Customer.MakeExample(), new Item());
			[Theory] public static void Invariants (Receipt receipt) {
				Assume.That(receipt != null);
				// ReSharper disable once PossibleNullReferenceException
				receipt.AssertInvariants();
			}
		}
	}
}
