using AdaptiveUIDemo.Interfaces;
using System;
using System.Collections.Generic;

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
        }

        public string AlgorithmName { get; private set; }

        public void Learn(IData dataPoint)
        {
            throw new NotImplementedException();
        }

        public List<IData> OrderControls()
        {
            throw new NotImplementedException();
        }
    }
}
