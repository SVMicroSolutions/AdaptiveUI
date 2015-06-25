using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdaptiveUIDemo.Data;
using AdaptiveUIDemo.AdaptiveUIAlgorthims;

namespace AlgorithmTests
{
    [TestClass]
    public class DumbAlgorithmTest
    {
        [TestMethod]
        public void SimpleLearningTest()
        {
            var data1 = new DataPoint { ControlName = "c1", TimeOfInteraction = DateTime.Now };
            var data2 = new DataPoint { ControlName = "c2", TimeOfInteraction = DateTime.Now };
            var data3 = new DataPoint { ControlName = "c3", TimeOfInteraction = DateTime.Now };

            var learner = new DumbAlgorithm();
            learner.Learn(data2);
            learner.Learn(data3);
            learner.Learn(data2);
            learner.Learn(data1);
            learner.Learn(data3);
            learner.Learn(data2);

            var learnedPoints = learner.OrderControls();
            Assert.AreEqual(3, learnedPoints.Count, "Wrong number of learned controls");
            Assert.AreEqual(data2, learnedPoints[0], "First control should be c2");
            Assert.AreEqual(data3, learnedPoints[1], "Second control should be c3");
            Assert.AreEqual(data1, learnedPoints[2], "Third control should be c1");
        }
    }
}
