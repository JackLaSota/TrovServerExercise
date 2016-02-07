using System.ServiceModel;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	[ServiceContract] public interface IGildedRoseService {
		[OperationContract] Item[] GetItemsForSale ();
	}
}
