using System;
using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class BoundedLearnerTest
    {
        [TestMethod]
        public void OrdersControlsCorrectly()
        {
            var data1 = new DataPoint { ControlName = "c1", TimeOfInteraction = DateTime.Now };
            var data2 = new DataPoint { ControlName = "c2", TimeOfInteraction = DateTime.Now };
            var data3 = new DataPoint { ControlName = "c3", TimeOfInteraction = DateTime.Now };

            var learner = new BoundedLearner();
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

            Assert.AreNotEqual(learnedPoints[0].Rank, learnedPoints[1].Rank, "First and second items shouldn't have same rank");
            Assert.IsTrue(learnedPoints[0].Rank > learnedPoints[1].Rank && learnedPoints[1].Rank > learnedPoints[2].Rank, "Points should be ordered");
        }
    }
}
