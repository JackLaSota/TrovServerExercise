using System;
using System.ServiceModel;

namespace TrovServerExercise {
	public static partial class Global {
		#region Copied_From_My_Game
		// ReSharper disable once MemberCanBePrivate.Global
		public static S GetWrappingExceptions <T, S> (Func<S> toTry, string exceptionMessage, Func<Exception, bool> acceptor) where T : GildedRoseException {
			var toReturn = default(S);//Never used. If assignment fails then this throws instead of returning.
			DoWrappingExceptions<T>(() => toReturn = toTry(), exceptionMessage, acceptor);
			return toReturn;
		}
		public static S GetWrappingExceptions <T, S> (Func<S> toTry, string exceptionMessage) where T : GildedRoseException {
			return GetWrappingExceptions<T, S>(toTry, exceptionMessage, e => true);
		}
		public static void DoWrappingExceptions <T> (Action toTry, string exceptionMessage) where T : GildedRoseException {
			DoWrappingExceptions<T>(toTry, exceptionMessage, e => true);
		}
		// ReSharper disable once MemberCanBePrivate.Global
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
			catch (GildedRoseClientComplaintException exception) {
				throw new FaultException<FaultDetail>(new FaultDetail(exception.Message, exception.shouldBeLayUserVisible));
			}
			catch {
				throw new FaultException<FaultDetail>(new FaultDetail());
			}
			return toReturn;
		}
	}
}
