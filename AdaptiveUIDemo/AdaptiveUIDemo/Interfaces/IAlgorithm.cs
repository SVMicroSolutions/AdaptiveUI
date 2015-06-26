using System.Collections.Generic;

namespace AdaptiveUIDemo.Interfaces
{
    public interface IAlgorithm
    {
        void Learn(IData dataPoint);
        List<IData> OrderControls();
        string AlgorithmName { get; }
        void Reset();
    }
}
