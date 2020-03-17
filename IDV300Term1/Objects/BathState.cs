using System;
namespace IDV300Term1.Objects
{
    public enum BathState
    {
        good,
        normal,
        bad
    }
    class BathStates
    {
        public static string GetBathString(BathState bathState)
        {
            switch (bathState)
            {
                case BathState.good:
                    return "good";
                case BathState.normal:
                    return "normal";
                case BathState.bad:
                    return "bad";
                default:
                    return "dead";

            }
        }

        public static BathState GetBathState(string bathString)
        {
            switch (bathString)
            {
                case "good":
                    return BathState.good;
                case "normal":
                    return BathState.normal;
                case "bad":
                    return BathState.bad;
                default:
                    return BathState.bad;

            }
        }
    }
}
