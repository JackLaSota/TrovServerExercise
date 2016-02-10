using System.ServiceModel;
using System.ServiceModel.Web;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	[ServiceContract] public interface IGildedRoseService {
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		[OperationContract] Item[] GetItemsForSale ();
		[
			OperationContract, WebInvoke(
				Method = "POST",
				RequestFormat = WebMessageFormat.Json,
				ResponseFormat = WebMessageFormat.Json,
				BodyStyle = WebMessageBodyStyle.Wrapped
			)
		]
		ReceiptAttempt ProcessPurchaseAttempt (string username, string password, Item clientDescriptionOfItem);//Including full description of item here prevents customer from accidentally buying something if the price or details changed since they requested that data.
	}
}
