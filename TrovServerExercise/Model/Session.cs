using System.IdentityModel.Tokens;
using JetBrains.Annotations;

namespace TrovServerExercise.Model {
	public partial class Session {
		[NotNull] public readonly UserNameSecurityToken token;//Invariant: unique. //todo test this?
		public Session ([NotNull] UserNameSecurityToken token) {this.token = token;}
	}
}
