using System.ServiceModel;
using System.ServiceModel.Web;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	[ServiceContract] public interface IGildedRoseService {
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		[OperationContract] Item[] GetItemsForSale ();
	}
}
