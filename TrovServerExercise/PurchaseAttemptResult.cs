
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace TrovServerExercise {
	[DataContract] public abstract partial class PurchaseAttemptResult {
		public class Success : PurchaseAttemptResult {
			//todo add receipt information.
		}
		public class Failure : PurchaseAttemptResult {
			[DataMember, NotNull] public string Message {get; set;}
			public Failure (string messageForUser) {Message = messageForUser;}
		}
	}
}
