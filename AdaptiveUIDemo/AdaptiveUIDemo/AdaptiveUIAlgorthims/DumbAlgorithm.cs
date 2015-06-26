using AdaptiveUIDemo.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

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
            _hitCounts = new Dictionary<IData, double>();
        }

        public string AlgorithmName { get; }

        public virtual void Learn(IData dataPoint)
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
            var maxHits = _hitCounts.Values.Max();
            return new List<IData>(HitCountData.Select(kvp =>
            {
                kvp.Key.Rank = kvp.Value / maxHits;
                return kvp.Key;
            }).OrderByDescending(data => data.Rank));
        }
        public override string ToString()
        {
            return this.AlgorithmName;
        }

        public void Reset()
        {
            _hitCounts.Clear();
        }

        protected Dictionary<IData, double> HitCountData { get { return _hitCounts; } }

        private readonly Dictionary<IData, double> _hitCounts;
    }
}
