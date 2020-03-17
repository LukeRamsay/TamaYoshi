using System;
namespace IDV300Term1.Objects
{
    public enum BedState
    {
        good,
        normal,
        bad
    }
    class BedStates
    {
        public static string GetBedString(BedState bedState)
        {
            switch (bedState)
            {
                case BedState.good:
                    return "good";
                case BedState.normal:
                    return "normal";
                case BedState.bad:
                    return "bad";
                default:
                    return "dead";

            }
        }

        public static BedState GetBedState(string bedString)
        {
            switch (bedString)
            {
                case "good":
                    return BedState.good;
                case "normal":
                    return BedState.normal;
                case "bad":
                    return BedState.bad;
                default:
                    return BedState.bad;

            }
        }
    }
}
