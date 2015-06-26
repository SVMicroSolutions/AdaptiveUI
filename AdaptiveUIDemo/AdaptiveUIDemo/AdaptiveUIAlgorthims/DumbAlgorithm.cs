﻿using AdaptiveUIDemo.Interfaces;
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
            return new List<IData>(_hitCounts.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key));
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
