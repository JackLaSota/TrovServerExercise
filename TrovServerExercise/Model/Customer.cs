using System.IdentityModel.Tokens;
using JetBrains.Annotations;

namespace TrovServerExercise.Model {
	public partial class Customer {
		[CanBeNull] public UserNameSecurityToken currentLoginToken;
		[NotNull] public readonly string name;//Not guaranteed unique.
		[NotNull] public readonly string username;//Guaranteed unique.
		public Customer (string username, string name) {this.username = username; this.name = name;}
		public static Customer MakeExample () {return new Customer("RulezThemAll973", "Sauron");}
	}
}
