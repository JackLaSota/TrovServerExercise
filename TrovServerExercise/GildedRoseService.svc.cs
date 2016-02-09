using System;
using System.Linq;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	///<remarks>
	/// No invalid data from the client may leave the methods of this class.
	/// No strings not in Unicode Normalization Form C may leave the methods of this class.
	/// This is excepting methods whose sole purposes are to check and/or correct data with these shortcomings.
	///	(such as string.Normalize().)
	///</remarks>
	public class GildedRoseService : IGildedRoseService {
		GildedRose model =
#if DEBUG
			GildedRose.MakeExample();
#else
			new GildedRose();
#endif
		public Item[] GetItemsForSale () {return model.ItemsForSale.ToArray();}
		public PurchaseAttemptResult ProcessPurchaseAttempt (string username, string password, Item toPurchase) {
			throw new NotImplementedException();
			username = username.Normalize();
			password = password.Normalize();
			toPurchase = toPurchase.WithNormalizedStrings();
			try {}
			catch {
				
			}
			//if (!Item.Tests.Invariants(toPurchase)) return new PurchaseAttemptResult.Failure("Invalid item.");
		}
	}
}
