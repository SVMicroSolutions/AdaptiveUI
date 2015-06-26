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
        {}

        public TomAlgorithm(string name)
            : base(name)
        {}

		public override List<IData> OrderControls()
		{
			Dictionary<IData, double> originalList = HitCountData;
			Dictionary<IData, double> listToReturn = new Dictionary<IData, double>();

			while (originalList.Count > 0)
			{
				double dta = originalList.ind;
				int indexToMax = 0;
				for (int index = 0; index < originalList.Count; index++)
				{
					
					if (originalLis[indexToMax]. > indexToMax)
						indexToMax = index;

				}
		}
	}
}
