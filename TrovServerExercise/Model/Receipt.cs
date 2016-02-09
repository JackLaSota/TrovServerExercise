using System.Runtime.Serialization;
using JetBrains.Annotations;
using NUnit.Framework;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	[DataContract] public partial class Receipt : IValidated {
		public Receipt ([NotNull] Customer customer, [NotNull] Item item) {CustomerName = customer.name; ItemName = item.Name; Price = item.Price;}
		[DataMember, NotNull] string CustomerName {get; set;}
		[DataMember, NotNull] string ItemName {get; set;}
		[DataMember] uint Price {get; set;}
		//todo maybe add date.
		public void AssertInvariants () {
			Assert.NotNull(CustomerName);
			Assert.NotNull(ItemName);
		}
	}
}
