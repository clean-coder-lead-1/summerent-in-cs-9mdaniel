using System;

namespace TypewiseAlert
{
    public class TypewiseAlert
    {
        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };
        public static BreachType inferBreach(double value, double upperLimit)
        {
            if (value < 0)
            {
                return BreachType.TOO_LOW;
            }
            if (value > upperLimit)
            {
                return BreachType.TOO_HIGH;
            }
            return BreachType.NORMAL;
        }
        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };
        public static int findUpperLimit(CoolingType coolingType)
        {
            if (coolingType == CoolingType.PASSIVE_COOLING)
            {
                return 35;
            }
            if (coolingType == CoolingType.HI_ACTIVE_COOLING)
            {
                return 45;
            }
            return 40;
        }

        public static BreachType classifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC)
        {
            int upperLimit = 0;
            upperLimit = findUpperLimit(coolingType);
            return inferBreach(temperatureInC, upperLimit);
        }
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL
        };
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
        }
        public static void checkAndAlert(
            AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {

            BreachType breachType = classifyTemperatureBreach(
              batteryChar.coolingType, temperatureInC
            );

            switch (alertTarget)
            {
                case AlertTarget.TO_CONTROLLER:
                    sendToController(breachType);
                    break;
                case AlertTarget.TO_EMAIL:
                    sendToEmail(breachType);
                    break;
            }
        }
        public static void sendToController(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{} : {}\n", header, breachType);

        }
        public static void sendToEmail(BreachType breachType)
        {
            switch (breachType)
            {
                case BreachType.TOO_LOW:
                    Console.WriteLine("To: {}\n Hi, the temperature is too low\n", "a.b@c.com");
                    break;
                case BreachType.TOO_HIGH:
                    Console.WriteLine("To: {}\n Hi, the temperature is too high\n", "a.b@c.com");
                    break;
            }

        }
    }
}
