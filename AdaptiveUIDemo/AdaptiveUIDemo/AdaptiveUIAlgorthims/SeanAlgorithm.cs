using AdaptiveUIDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.AdaptiveUIAlgorthims
{
    /// <summary>
    /// Uses a method that takes into acount the the age when a control 
    /// was pressed in determin the ranking
    /// </summary>
    public class SeanAlgorithm : DumbAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeanAlgorithm"/> class.
        /// </summary>
        public SeanAlgorithm()
            : base("AgeBased")
        { }

        public override List<IData> OrderControls()
        {
            return new List<IData>(HitCountData.OrderByDescending(kvp => CalculateRank(kvp.Value, kvp.Key.TimeOfInteraction)).Select(kvp => kvp.Key));
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
            double t = pressedTime.Subtract(startingTime).TotalSeconds;
            double x = hitCount - 1.0;
            double y = 0.0;
            if (x > 0.0)
            {
                y = 1.0;
            }
            else if (x == 0.0)
            {
                y = 0.0;
            }
            else if (y < 0.0)
            {
                y = -1;
            }

            double z = x < 0.0 ? 1 : x;  
            return Math.Log10(z) + ((y*t) / WeighingFactor);
        }

        private const double  WeighingFactor = 60.0; // used to water down presses made futher down 
        private readonly DateTime startingTime = new DateTime(2015, 6, 25);
    }
}
