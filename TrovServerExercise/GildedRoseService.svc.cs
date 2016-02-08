using System.Linq;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	public class GildedRoseService : IGildedRoseService {
		GildedRose model =
#if DEBUG
			GildedRose.MakeExample();
#else
			new GildedRose();
#endif
		public Item[] GetItemsForSale () {return model.ItemsForSale.ToArray();}
	}
}
