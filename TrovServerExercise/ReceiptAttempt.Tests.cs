using NUnit.Framework;

namespace TrovServerExercise {
	[TestFixture] public partial class ReceiptAttempt {
		[TestFixture] public class Tests {//Not an inner class like normal testfixtures, because AttemptFor is generic.
			[Test] public void TryTest () {
				var message = "asdf";
				var failureForIntWithMessage = Make(() => {throw new GildedRoseClientComplaintException(message) {shouldBeLayUserVisible = true};});
				Assert.That(!failureForIntWithMessage.IsSuccess);
				Assert.AreEqual(message, failureForIntWithMessage.ErrorMessage);
			}
		}
	}
}
