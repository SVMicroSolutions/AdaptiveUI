using System;
using System.Collections.Generic;
using System.Linq;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    /// <summary>
    /// This learning algorithm attempts to adapt to new usage patterns by penalizing
    /// controls that haven't been used recently.
    /// </summary>
    public class AvereageAlgorithm : BoundedLearner
    {
        public AvereageAlgorithm()
            : base("Average")
        {
            _usedControls = new Dictionary<IData, IData>();
        }

        public override void Learn(IData dataPoint)
        {
            // Cap the maximum hit count value so that it's easier to forget. The maximum
            // value is highly correlated to the sigmoid function parameters used in bounded
            // learning. That equations parameters are currently set so that learning stop safter
            // about 6 or 7 clicks. Capping the maximum clicks at 10 means that a super popular
            // control will have to be ignored a few times before we start to forget about it (i.e.,
            // it's ranking starts to decrease).
            if (HitCountData.ContainsKey(dataPoint) && HitCountData[dataPoint] < LEARNING_CAP)
            {
                base.Learn(dataPoint);
            }
            else if (!HitCountData.ContainsKey(dataPoint))
            {
                base.Learn(dataPoint);
            }
            _usedControls[dataPoint] = dataPoint;
        }

        public override List<IData> OrderControls()
        {
            var ordering = base.OrderControls();
            // Penalize any controls that weren't selected
            var ignoredControls = HitCountData.Keys.Where(d => !_usedControls.ContainsKey(d)).ToList();
            foreach (var c in ignoredControls)
            {
                // Limit how much can be "forgotten" (i.e., limit how low the ranking can go)
                HitCountData[c] = Math.Max(0, HitCountData[c] - IGNORE_PENALTY);
            }
            // Every time we show what we've learned, we reset the controls that were used.
            // The next time we have a learning opportunity we could potentially ignore a new set of controls.
            _usedControls.Clear();
            return ordering;
        }

        // The penalty for being ignored during a "session"
        private const double IGNORE_PENALTY = 0.5;
        private const int LEARNING_CAP = 10;

        private readonly Dictionary<IData, IData> _usedControls;
    }
}
