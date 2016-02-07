using System.Linq;
using TrovServerExercise.Model;

namespace TrovServerExercise {
	public class GildedRoseService : IGildedRoseService {
		GildedRose model = new GildedRose();
		public Item[] GetItemsForSale () {return model.ItemsForSale.ToArray();}
	}
}
