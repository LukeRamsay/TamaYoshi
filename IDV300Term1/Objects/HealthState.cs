using System;
namespace IDV300Term1.Objects
//Getting and Setting health states to use in mainpage
{
    public enum HealthState
    {
        good,
        normal,
        bad
    }
    class HealthStates
    {
        public static string GetHealthString(HealthState healthState)
        {
            switch (healthState)
            {
                case HealthState.good:
                    return "good";
                case HealthState.normal:
                    return "normal";
                case HealthState.bad:
                    return "bad";
                default:
                    return "dead";

            }
        }

        public static HealthState GetHealthState(string healthString)
        {
            switch (healthString)
            {
                case "good":
                    return HealthState.good;
                case "normal":
                    return HealthState.normal;
                case "bad":
                    return HealthState.bad;
                default:
                    return HealthState.bad;

            }
        }
    }
}
