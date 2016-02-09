using System.Runtime.Serialization;
using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise.Model {
	[DataContract] public partial class Item : IAllowsBitwiseCloning, IValidated {
		[DataMember, NotNull] public string Name {get {return name;} set {name = value;}}
		string name = "Thneed";
		[DataMember, NotNull] public string Description {get {return description;} set {description = value;}}
		string description = "Everyone needs one.";
		[DataMember] public uint Price {get {return price;} set {price = value;}}
		uint price = 10;//Invariant: positive.
		public bool InterchangeableWith (Item other) {return name == other.name && description == other.description && price == other.price;}
		public void AssertInvariants () {
			Assert.That(this.StringsAreNormalized);
			Assert.NotNull(Name);
			Assert.NotNull(Description);
			Assert.Greater(Price, 0);
		}
	}
}
