using System.Linq;
using System.ServiceModel;
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
		public Receipt ProcessPurchaseAttempt (string username, string password, Item clientDescriptionOfItem) {
			return Global.GetWrappingExceptionsForClient(() => {
				Global.DoWrappingExceptions<GildedRoseClientComplaintException>(() => {
					username = username.NullHandlingNormalize();
					password = password.NullHandlingNormalize();
					clientDescriptionOfItem = clientDescriptionOfItem.WithNormalizedStrings();
					Assert.NotNull(username);
					Assert.NotNull(password);
					clientDescriptionOfItem.AssertNotNullAndInvariantsIfAny();
				}, "Invalid data.");
				lock (model) {//todo find a way to not do this.
					var customer = model.CustomerWithUsername(username);
					if (customer == null) RespondWithFault("Username not found.", true);
					// ReSharper disable once PossibleNullReferenceException
					if (!customer.PasswordIs(password)) RespondWithFault("Wrong password.", true);
					var actualItem = model.ItemMatching(clientDescriptionOfItem);
					if (actualItem == null) RespondWithFault("Item not carried.", true);
					if (!customer.CanAfford(actualItem)) RespondWithFault("Insufficient money.", true);
					return model.ConductSale(customer, actualItem);
				}
			});
		}
		public static void RespondWithFault (string messageToClient, bool messageShouldBeLayUserVisible) {
			throw new FaultException<FaultDetail>(new FaultDetail(messageToClient, messageShouldBeLayUserVisible));
		}
	}
}
