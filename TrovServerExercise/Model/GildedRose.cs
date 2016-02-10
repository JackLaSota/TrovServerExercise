using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class GildedRose : IValidated {
		[NotNull] Inventory inventory = new Inventory();
		[NotNull] CustomerRegistry customerRegistry = new CustomerRegistry();
		// ReSharper disable once UnusedAutoPropertyAccessor.Global
		public uint MoneyInRegister {get; set;}
		public IEnumerable<Item> ItemsForSale {get {return inventory.items;}}
		public static GildedRose MakeExample () {
			return new GildedRose {
				inventory = Inventory.MakeExample(),
				customerRegistry = CustomerRegistry.MakeExample(),
				MoneyInRegister = 1000
			};
		}
		public void AssertInvariants () {
			Assert.NotNull(inventory);
			Inventory.Tests.Invariants(inventory);
			Assert.NotNull(customerRegistry);
			CustomerRegistry.Tests.Invariants(customerRegistry);
		}
		public Customer CustomerWithUsername (string username) {
			return customerRegistry.CustomerWithUsername(username);
		}
		public Item ItemMatching (Item description) {return inventory.ItemMatching(description);}
		///<summary>Precondition: sale is valid.</summary>
		public Receipt ConductSale (Customer customer, Item item) {
			customer.MoneyInWallet -= item.Price;
			MoneyInRegister += item.Price;
			inventory.Remove(item);
			return new Receipt(customer, item);
		}
	}
}
