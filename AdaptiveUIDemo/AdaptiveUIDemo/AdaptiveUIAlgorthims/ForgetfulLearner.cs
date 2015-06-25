using System.Collections.Generic;
using System.Linq;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    /// <summary>
    /// This learning algorithm attempts to adapt to new usage patterns by penalizing
    /// controls that haven't been used recently.
    /// </summary>
    public class ForgetfulLearner : BoundedLearner
    {
        public ForgetfulLearner()
            : base("Lethe")
        {
            _usedControls = new Dictionary<IData, IData>();
        }

        public override void Learn(IData dataPoint)
        {
            base.Learn(dataPoint);
            _usedControls[dataPoint] = dataPoint;
        }

        public override List<IData> OrderControls()
        {
            var ordering = base.OrderControls();
            // Penalize any controls that weren't selected
            var ignoredControls = HitCountData.Keys.Where(d => !_usedControls.ContainsKey(d)).ToList();
            foreach (var c in ignoredControls)
            {
                HitCountData[c] -= IGNORE_PENALTY;
            }
            // Every time we show what we've learned, we reset the controls that were used.
            // The next time we have a learning opportunity we could potentially ignore a new set of controls.
            _usedControls.Clear();
            return ordering;
        }

        // The penalty for being ignored during a "session"
        private const double IGNORE_PENALTY = 0.5;

        private readonly Dictionary<IData, IData> _usedControls;
    }
}
