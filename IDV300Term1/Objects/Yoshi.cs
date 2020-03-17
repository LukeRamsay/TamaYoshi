using System;
namespace IDV300Term1.Objects
{
    public class Yoshi
    {

        const string foodStateKey = "foodState";
        const string bathStateKey = "bathState";
        const string bedStateKey = "bedState";

        public FoodState CurrentFoodState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(foodStateKey))
                {
                    return FoodStates.GetFoodState((string)App.Current.Properties[foodStateKey]);
                }
                else
                {
                    return FoodState.good;
                }

            }
            set
            {
                App.Current.Properties[foodStateKey] = FoodStates.GetFoodString(value);

            }
        }

        public BathState CurrentBathState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(bathStateKey))
                {
                    return BathStates.GetBathState((string)App.Current.Properties[bathStateKey]);
                }
                else
                {
                    return BathState.good;
                }

            }
            set
            {
                App.Current.Properties[bathStateKey] = BathStates.GetBathString(value);

            }
        }

        public BedState CurrentBedState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(bedStateKey))
                {
                    return BedStates.GetBedState((string)App.Current.Properties[bedStateKey]);
                }
                else
                {
                    return BedState.good;
                }

            }
            set
            {
                App.Current.Properties[bedStateKey] = BedStates.GetBedString(value);

            }
        }

        public Yoshi()
        {

        }

        public void giveFood()
        {

        }

        public void giveBath()
        {

        }

        public void giveBed()
        {

        }
    }
}
