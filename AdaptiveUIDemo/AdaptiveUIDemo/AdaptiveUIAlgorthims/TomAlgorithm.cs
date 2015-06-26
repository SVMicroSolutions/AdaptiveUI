using System.Collections;
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
			var retList = new List<IData>();

			// make deep copy of HitCountData so we do not modify the original values.
			var copyOfHitCountData = HitCountData.ToDictionary(item => item.Key, item => item.Value);

			double maxHitsEver = 0;
			while (copyOfHitCountData.Count > 0)
			{
				double maxHitsWithinLoop = 0;
				var kvp = new KeyValuePair<IData, double>();

				for (var index = 0; index < copyOfHitCountData.Count; index++)
				{
					var value = copyOfHitCountData.ElementAt(index).Value;
					if (!(value > maxHitsWithinLoop))
						continue;
					maxHitsWithinLoop = value;
					var indexToMax = index;
					kvp = copyOfHitCountData.ElementAt(indexToMax);
				}

				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (maxHitsEver == 0)
					maxHitsEver = maxHitsWithinLoop;
				kvp.Key.Rank = kvp.Value / maxHitsEver;
				copyOfHitCountData.Remove(kvp.Key);
				retList.Add(kvp.Key);
			}
			return retList;
		}
	}
}
