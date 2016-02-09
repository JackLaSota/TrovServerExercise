using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Customer {
		[TestFixture] public class Tests {
			[Datapoint] Customer example = MakeExample();
			[Theory] public static void Invariants (Customer customer) {
				Assume.That(customer != null);
				Assert.That(customer.StringsAreNormalized);
				// ReSharper disable once PossibleNullReferenceException
				Assert.NotNull(customer.name);
				Assert.NotNull(customer.username);
				Assert.NotNull(customer.password);/*
				if (customer.currentSession != null)
					Session.Tests.Invariants(customer.currentSession);*/
			}
		}
	}
}
