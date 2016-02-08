using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace TrovServerExercise.Model {
	[DataContract] public partial class Item {
		[DataMember, NotNull] public string Name {get {return name;} set {name = value;}}
		string name = "Thneed";
		[DataMember, NotNull] public string Description {get {return description;} set {description = value;}}
		string description = "Everyone needs one.";
		[DataMember] public uint Price {get {return price;} set {price = value;}}
		uint price = 10;//Invariant: positive.
	}
}
