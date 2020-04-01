using System;
namespace IDV300Term1.Objects
//Getting and Setting food states to use in mainpage
{
    public enum FoodState
    {
        good,
        normal,
        bad
    }
    public class FoodStates
    {
        public static string GetFoodString(FoodState foodState)
        {
            switch (foodState)
            {
                case FoodState.good:
                    return "good";
                case FoodState.normal:
                    return "normal";
                case FoodState.bad:
                    return "bad";
                default:
                    return "dead";
            }
        }

        public static FoodState GetFoodState(string foodString)
        {
            switch (foodString)
            {
                case "good":
                    return FoodState.good;
                case "normal":
                    return FoodState.normal;
                case "bad":
                    return FoodState.bad;
                default:
                    return FoodState.bad;

            }
        }
    }
}
