using AdaptiveUIDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    class TimeAlgorithm : DumbAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeanAlgorithm"/> class.
        /// </summary>
        public TimeAlgorithm()
            : base("OnlyTimeMatters")
        { }



        public override void Learn(IData dataPoint)
        {
            if (!HitCountData.ContainsKey(dataPoint))
            {
                HitCountData[dataPoint] = 1;
            }
            else
            {
                double oldCount = HitCountData[dataPoint];
                HitCountData.Remove(dataPoint);
                HitCountData[dataPoint] = oldCount += 1;

            }
        }

        public override List<IData> OrderControls()
        {
            return new List<IData>(HitCountData.Select(kvp =>
            {
                kvp.Key.Rank = CalculateRank(kvp.Value, kvp.Key.TimeOfInteraction);
                return kvp.Key;
            }).OrderByDescending(data => data.TimeOfInteraction));
        }

        /// <summary>
        /// Calculates the rank based on the following formula, 
        /// t = (time of click) - (June 25th, 2015)
        /// x = #of times clicked - 1 
        /// y = {1 if x > 0, 0 if x = 0, -1 if x < 0)
        /// z = {1 if x < 0, otherwise x}

        /// log(z) + (y * t)/WeightingFactor

        /// </summary>
        /// <param name="hitCount">The hit count.</param>
        /// <param name="pressedTime">The pressed time.</param>
        /// <returns></returns>
        protected double CalculateRank(double hitCount, DateTime pressedTime)
        {
            return 0.0; // Only rank matters 
        }

        private const double WeighingFactor = 120.0; // used to water down presses made futher down
        private const double NormalizationFactor = 10000; // Used to scale down the data   
        private readonly DateTime startingTime = new DateTime(2015, 6, 25);
    }
}
