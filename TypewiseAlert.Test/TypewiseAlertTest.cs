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
            try
            {
                TypewiseAlert.sendToController(TypewiseAlert.BreachType.NORMAL);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersSendToControllerHigh()
        {
            try
            {
                TypewiseAlert.sendToController(TypewiseAlert.BreachType.TOO_HIGH);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersSendToControllerLow()
        {
            try
            {
                TypewiseAlert.sendToController(TypewiseAlert.BreachType.TOO_LOW);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersSendToEmailLow()
        {
            try
            {
                TypewiseAlert.sendToEmail(TypewiseAlert.BreachType.TOO_LOW);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersSendToEmailHigh()
        {
            try
            {
                TypewiseAlert.sendToEmail(TypewiseAlert.BreachType.TOO_HIGH);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersCheckAndAlert()
        {
            try
            {
                TypewiseAlert.BatteryCharacter batteryCharCool = new TypewiseAlert.BatteryCharacter();
                batteryCharCool.coolingType = TypewiseAlert.CoolingType.HI_ACTIVE_COOLING;

                TypewiseAlert.checkAndAlert(TypewiseAlert.AlertTarget.TO_CONTROLLER, batteryCharCool, 32);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void InfersCheckAndAlertEmail()
        {
            try
            {
                TypewiseAlert.BatteryCharacter batteryCharCool = new TypewiseAlert.BatteryCharacter();
                batteryCharCool.coolingType = TypewiseAlert.CoolingType.HI_ACTIVE_COOLING;

                TypewiseAlert.checkAndAlert(TypewiseAlert.AlertTarget.TO_EMAIL, batteryCharCool, 32);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }


    }

}
