using NUnit.Framework;

namespace TrovServerExercise {
	[TestFixture] public class AttemptForTests {//Not an inner class like normal testfixtures, because AttemptFor is generic.
		[Test] public void TryTest () {
			var message = "asdf";
			var failureForIntWithMessage = AttemptFor<int>.Try(() => {throw new GildedRoseClientComplaintException(message) {shouldBeLayUserVisible = true};});
			Assert.IsInstanceOf<AttemptFor<int>.Failure>(failureForIntWithMessage);
			Assert.AreEqual(message, ((AttemptFor<int>.Failure) failureForIntWithMessage).Message);
		}
	}
}
