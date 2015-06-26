using System.Collections.Generic;
using System.Linq;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
	/// <summary>
	/// Implements a sigmoid function to impose lower and upper bounds on a control's rank.
	/// </summary>
	public class TomAlgorithm : DumbAlgorithm
	{
		public TomAlgorithm()
			: base("Europa")
		{
		}

		public TomAlgorithm(string name)
			: base(name)
		{
		}

		public override List<IData> OrderControls()
		{
			var listToReturn = new List<IData>();

			// make deep copy of HitCountData so we do not modify the original values.
			var hitListCopy = HitCountData.ToDictionary(item => item.Key, item => item.Value);

			while (hitListCopy.Count > 0)
			{
				var indexToMax = 0;
				double max = 0;

				for (var index = 0; index < hitListCopy.Count; index++)
				{
					var value = hitListCopy.ElementAt(index).Value;
					if (!(value > max))
						continue;
					max = value;
					indexToMax = index;
				}
				var item = hitListCopy.ElementAt(indexToMax);
				hitListCopy.Remove(item.Key);
				listToReturn.Add(item.Key);
			}
			return listToReturn;
		}
	}
}
