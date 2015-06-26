using System;
using System.Collections.Generic;
using System.Linq;
using AdaptiveUIDemo.Interfaces;
using System.Collections;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
	/// <summary>
	/// Implements a sigmoid function to impose lower and upper bounds on a control's rank.
	/// </summary>
	public class TomAlgorithm : DumbAlgorithm
	{
		public TomAlgorithm()
			: base("Europa")
		{ }

		public TomAlgorithm(string name)
			: base(name)
		{ }

		public override List<IData> OrderControls()
		{
			Dictionary<IData, double> hitListCopy = new Dictionary<IData, double>();
			List<IData> listToReturn = new List<IData>();

			// make deep copy of HitCountData so we do not modify the original values.
			foreach (KeyValuePair<IData, double> item in HitCountData)
			{
				hitListCopy.Add(item.Key, item.Value);
			}

			while (hitListCopy.Count > 0)
			{
				int indexToMax = 0;
				double max = 0;

				for (int index = 0; index < hitListCopy.Count; index++)
				{
					var value = hitListCopy.ElementAt(index).Value;
					if (value > max)
					{
						max = value;
						indexToMax = index;
					}
				}
				var item = hitListCopy.ElementAt(indexToMax);
				hitListCopy.Remove(item.Key);
				listToReturn.Add(item.Key);
			}
			return listToReturn;
		}
	}
}
