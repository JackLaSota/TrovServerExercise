using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using NUnit.Framework;

namespace TrovServerExercise {
	[DataContract] public partial class ReceiptAttempt : IValidated {
		public static ReceiptAttempt Make (Func<Receipt> toTry) {
			try {return Success(toTry());}
			catch (GildedRoseClientComplaintException exception) {return Failure(exception.Message, exception.shouldBeLayUserVisible);}
			catch {return Failure();}
		}
		public bool IsSuccess {get {return ErrorMessage == null;}}
		[DataMember] public string ErrorMessage {get; set;}
		[DataMember] public bool ErrorShouldBeVisibleToLayUser {get; set;}
		[DataMember] public Receipt result;
		public static ReceiptAttempt Failure () {return Failure("Unknown error occured.", true);}
		public static ReceiptAttempt Failure ([NotNull] string errorMessage, bool shouldBeVisibleToLayLayUser = false) {
			return new ReceiptAttempt {
				ErrorMessage = errorMessage,
				ErrorShouldBeVisibleToLayUser = shouldBeVisibleToLayLayUser
			};
		}
		public static ReceiptAttempt Success (Receipt result) {return new ReceiptAttempt {result = result};}
		public void AssertInvariants () {Assert.NotNull(ErrorMessage);}
	}
}
