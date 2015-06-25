using AdaptiveUIDemo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    public class DumbAlgorithm : IAlgorithm
    {
        public DumbAlgorithm() 
            : this("Gomer")
        { }

        public DumbAlgorithm(string name)
        {
            AlgorithmName = name;
            _hitCounts = new Dictionary<IData, int>();
        }

        public string AlgorithmName { get; }

        public void Learn(IData dataPoint)
        {
            if (!_hitCounts.ContainsKey(dataPoint))
            {
                _hitCounts[dataPoint] = 1;
            }
            else
            {
                _hitCounts[dataPoint]++;
            }
        }

        public virtual List<IData> OrderControls()
        {
            return new List<IData>(_hitCounts.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key));
        }

        protected Dictionary<IData, int> HitCountData { get { return _hitCounts; } }

        private readonly Dictionary<IData, int> _hitCounts;
    }
}
