using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise {
	[DataContract] public abstract class AttemptFor <T> {
		[DataContract] public class Failure : AttemptFor<T>, IValidated {
			[DataMember, NotNull] public string Message {get; set;}
			[DataMember] public bool ShouldBeVisibleToLayUser {get; set;}
			public Failure () : this("Unknown error occured.", true) {}
			public Failure ([NotNull] string message, bool shouldBeVisibleToLayLayUser = false) {Message = message; ShouldBeVisibleToLayUser = shouldBeVisibleToLayLayUser;}
			public void AssertInvariants () {Assert.NotNull(Message);}
		}
		[DataContract] public class Success : AttemptFor<T> {//todo make implicit cast.
			[DataMember] public T result;
			public Success (T result) {this.result = result;}
		}
		public static AttemptFor<T> Try (Func<T> toTry) {
			try {return new Success(toTry());}
			catch (GildedRoseClientComplaintException exception) {return new Failure(exception.Message, exception.shouldBeLayUserVisible);}
			catch {return new Failure();}
		}
	}
}
