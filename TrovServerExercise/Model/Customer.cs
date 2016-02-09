using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise.Model {
	public partial class Customer : IValidated {
		[NotNull] public readonly string name;//Not guaranteed unique.
		[NotNull] public readonly string username;//Guaranteed unique. //Invariant: in Unicode normalized form C.
		[NotNull] string password;//Invariant: in Unicode normalized form C. //todo Salt instead of storing this. (Make sure to normalize before salting).
		public Customer ([NotNull] string username, [NotNull] string password, [NotNull] string name) {
			this.username = username;
			this.password = password;
			this.name = name;
		}
		public static Customer MakeExample () {return new Customer("RulezThemAll973", "password123", "Sauron") {MoneyInWallet = 10000};}
		public void SetPassword (string newPassword) {password = newPassword;}
		public bool PasswordIs (string allegedPassword) {return allegedPassword.Normalize() == password;}
		public uint MoneyInWallet {get; set;}
		public bool CanAfford (Item item) {return item.Price <= MoneyInWallet;}
		public void AssertInvariants () {
			Assert.That(this.StringsAreNormalized);
			Assert.NotNull(name);
			Assert.NotNull(username);
			Assert.NotNull(password);
		}
		//todo maybe keep store of past receipts.
	}
}
