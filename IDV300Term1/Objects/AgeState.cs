using System;
namespace IDV300Term1.Objects
{
    public enum AgeState
    {
        egg,
        hatchling,
        teen,
        adult,
        elder
    }
    class AgeStates
    {
        public static string GetAgeString(AgeState ageState)
        {
            switch (ageState)
            {
                case AgeState.egg:
                    return "egg";
                case AgeState.hatchling:
                    return "hatchling";
                case AgeState.teen:
                    return "teen";
                case AgeState.adult:
                    return "adult";
                case AgeState.elder:
                    return "elder";
                default:
                    return "dead";

            }
        }

        public static AgeState GetAgeState(string ageString)
        {
            switch (ageString)
            {
                case "egg":
                    return AgeState.egg;
                case "hatchling":
                    return AgeState.hatchling;
                case "teen":
                    return AgeState.teen;
                case "adult":
                    return AgeState.adult;
                case "elder":
                    return AgeState.elder;
                default:
                    return AgeState.egg;

            }
        }
    }
}
