using System.Linq;
using NUnit.Framework;
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
		public ReceiptAttempt ProcessPurchaseAttempt (string username, string password, Item clientDescriptionOfItem) {
			return ReceiptAttempt.Make(() => {
				Global.DoWrappingExceptions<GildedRoseClientComplaintException>(() => {
					username = username.NullHandlingNormalize();
					password = password.NullHandlingNormalize();
					clientDescriptionOfItem = clientDescriptionOfItem.WithNormalizedStrings();
					Assert.NotNull(username);
					Assert.NotNull(password);
					clientDescriptionOfItem.AssertNotNullAndInvariantsIfAny();
				}, "Invalid data.");
				lock (model) {//todo find a way to not do this.
					var customer = model.AuthenticateOrThrow(username, password);
					return model.ConductSaleOrThrow(customer, clientDescriptionOfItem);
				}
			});
		}
#if DEBUG
		public void ResetForTests () {lock (model) {model = GildedRose.MakeExample();}}
#endif
	}
}
