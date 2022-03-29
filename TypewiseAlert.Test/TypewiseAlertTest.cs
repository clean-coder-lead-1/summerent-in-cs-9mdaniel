using System;
using Xunit;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLowerLimits()
        {
            Assert.True(TypewiseAlert.inferBreach(-1, 30) ==
              TypewiseAlert.BreachType.TOO_LOW);
        }

        [Fact]
        public void InfersBreachAsPerHigherLimits()
        {
            Assert.True(TypewiseAlert.inferBreach(31, 30) ==
              TypewiseAlert.BreachType.TOO_HIGH);
        }

        [Fact]
        public void InfersBreachAsPerNormalLimits()
        {
            Assert.True(TypewiseAlert.inferBreach(28, 30) ==
              TypewiseAlert.BreachType.NORMAL);
        }

        [Fact]
        public void InfersUpperLimitPassive()
        {
            Assert.True(TypewiseAlert.findUpperLimit(TypewiseAlert.CoolingType.PASSIVE_COOLING) ==
              35);
        }

        [Fact]
        public void InfersUpperLimitHi()
        {
            Assert.True(TypewiseAlert.findUpperLimit(TypewiseAlert.CoolingType.HI_ACTIVE_COOLING) ==
              45);
        }

        [Fact]
        public void InfersUpperLimitMed()
        {
            Assert.True(TypewiseAlert.findUpperLimit(TypewiseAlert.CoolingType.MED_ACTIVE_COOLING) ==
              40);
        }

        [Fact]
        public void InfersSendToControllerNormal()
        {
            Assert.True(TypewiseAlert.sendToController(0) == true);
        }

        [Fact]
        public void InfersSendToControllerHigh()
        {
            Assert.True(TypewiseAlert.sendToController(2) == true);
        }

        [Fact]
        public void InfersSendToControllerLow()
        {
            Assert.True(TypewiseAlert.sendToController(1) == true);
        }

        [Fact]
        public void InfersSendToEmailLow()
        {
            Assert.True(TypewiseAlert.sendToEmail(1) == true);
        }

        [Fact]
        public void InfersSendToEmailHigh()
        {
            Assert.True(TypewiseAlert.sendToEmail(2) == true);
        }


    }

}
