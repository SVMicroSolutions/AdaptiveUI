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
            var learner = new BoundedLearner();
            learner.Learn(new DataPoint("c1"));
            learner.Learn(new DataPoint("c2"));
            learner.Learn(new DataPoint("c2"));

            var orderedControls = learner.OrderControls();
            Assert.AreEqual(2, orderedControls.Count, "Wrong number of controls returned");
            // TODO: Finish testing
        }
    }
}
