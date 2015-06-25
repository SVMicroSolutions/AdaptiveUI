using System;
using System.Collections.Generic;
using System.Linq;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    /// <summary>
    /// The maximum sort rank for a given control will have an upper bound.
    /// </summary>
    public class BoundedLearner : DumbAlgorithm
    {
        public BoundedLearner()
            : base("Icarus")
        {}

        public override List<IData> OrderControls()
        {
            return new List<IData>(HitCountData.OrderByDescending(kvp => CalculateRank(kvp.Value)).Select(kvp => kvp.Key));
        }

        /// <summary>
        /// Uses a sigmoid function to calculate the rank of a control based on the number of times it has been hit. Higher
        /// ranks will be ordered first in the UI. The sort order will be between 0 and 1. The function is tailored so that 
        /// learning stops after about 8 clicks.
        /// </summary>
        /// <param name="hitCount"></param>
        /// <returns></returns>
        protected double CalculateRank(int hitCount)
        {
            return 1.0 / (1.0 + Math.Exp(-1 * LEARNING_RATE * (hitCount - SHIFT_TO_ZERO)));
        }

        // This controls how many number of clicks it takes for a control to hit its maximum rank. Values > 1 will hit the maximum in about 6 clicks.
        private const double LEARNING_RATE = 0.85;
        // Shifts the value of a single click to be around 0. After about 9 clicks the control will hit its maximum rank.
        private const double SHIFT_TO_ZERO = 5;
    }
}
