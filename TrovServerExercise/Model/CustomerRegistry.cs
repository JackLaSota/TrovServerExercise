using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class CustomerRegistry : IValidated {
		[NotNull] public readonly List<Customer> customers = new List<Customer>();
		public static CustomerRegistry MakeExample () {
			var registry = new CustomerRegistry();
			registry.customers.Add(Customer.MakeExample());
			return registry;
		}
		public void AssertInvariants () {
			Assert.NotNull(customers);
			CollectionAssert.AllItemsAreNotNull(customers);
			customers.ForEach(Customer.Tests.Invariants);
		}
		public Customer CustomerWithUsername (string username) {return customers.FirstOrDefault(c => c.username == username);}
	}
}
