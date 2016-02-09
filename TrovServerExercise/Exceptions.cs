using System;

namespace TrovServerExercise {
	///<summary>To be derived from by and only by types which can be thrown if GildedRoseService works correctly. Assertions must not throw this.</summary>
	public abstract class GildedRoseException : Exception {
		protected GildedRoseException (string messageToUser, Exception innerException) : base(messageToUser, innerException) {}
		protected GildedRoseException (string message) : base(message) {}
	}
	///<summary>To be derived from by and only by types which represent a final failure or refusal of bugless code in Dystheism to do what the user wants.</summary>>
	///<remarks>"Message" members of this class can be displayed to the end-user.</remarks>
	public abstract class GildedRoseComplaintException : Exception {
		protected GildedRoseComplaintException (string messageToUser, Exception innerException) : base(messageToUser, innerException) {}
		protected GildedRoseComplaintException (string messageToUser) : base(messageToUser) { }
	}
}
