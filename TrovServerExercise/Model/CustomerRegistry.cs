using System.Collections.Generic;
using JetBrains.Annotations;

namespace TrovServerExercise.Model {
	public partial class CustomerRegistry {
		[NotNull] public readonly List<Customer> customers = new List<Customer>();
		public static CustomerRegistry MakeExample () {
			var registry = new CustomerRegistry();
			registry.customers.Add(Customer.MakeExample());
			return registry;
		}
	}
}
