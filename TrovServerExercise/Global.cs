using System;
using System.ServiceModel;

namespace TrovServerExercise {
	public static partial class Global {
		#region Copied_From_My_Game
		public static void DoWrappingExceptions <T> (Action toTry, string exceptionMessage) where T : GildedRoseException {
			DoWrappingExceptions<T>(toTry, exceptionMessage, e => true);
		}
		public static void DoWrappingExceptions <T> (Action toTry, string exceptionMessage, Func<Exception, bool> acceptor) where T : GildedRoseException {
			try {toTry();}
			catch (Exception caught) {
				if (!acceptor(caught))
					throw;
				// ReSharper disable once PossibleNullReferenceException
				throw (Exception) typeof(T).GetConstructor(new[] {typeof(string), typeof(Exception)}).Invoke(new object[] {exceptionMessage, caught});
			}
		}
		#endregion
		public static S GetWrappingExceptionsForClient <S> (Func<S> toTry) {
			S toReturn;
			try {toReturn = toTry();}
			catch (FaultException) {throw;}
			catch (GildedRoseClientComplaintException exception) {
				throw new FaultException<FaultDetail>(new FaultDetail(exception.Message, exception.shouldBeLayUserVisible));
			}
			catch {throw new FaultException<FaultDetail>(new FaultDetail());}
			return toReturn;
		}
		public static void ThrowComplaint (string messageToClient, bool messageShouldBeLayUserVisible) {
			throw new GildedRoseClientComplaintException(messageToClient) { shouldBeLayUserVisible = messageShouldBeLayUserVisible };
		}
	}
}
