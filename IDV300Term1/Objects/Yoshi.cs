using System;
namespace IDV300Term1.Objects
{
    public class Yoshi
    {

        const string foodStateKey = "foodState";
        const string bathStateKey = "bathState";
        const string bedStateKey = "bedState";
        const string healthStateKey = "healthState";
        const string ageStateKey = "ageState";
        const string nameKey = "yoshiName";

        //Getting and Setting yoshi's current hunger state
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

        //Getting and Setting yoshi's current age
        public AgeState CurrentAgeState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(ageStateKey))
                {
                    return AgeStates.GetAgeState((string)App.Current.Properties[ageStateKey]);
                }
                else
                {
                    return AgeState.egg;
                }

            }
            set
            {
                App.Current.Properties[ageStateKey] = AgeStates.GetAgeString(value);

            }
        }

        //Getting and Setting yoshi's current bath state
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

        //Getting and Setting yoshi's current sleep state
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

        //Getting and Setting yoshi's current health state
        public HealthState CurrentHealthState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(healthStateKey))
                {
                    return HealthStates.GetHealthState((string)App.Current.Properties[healthStateKey]);
                }
                else
                {
                    return HealthState.good;
                }

            }
            set
            {
                App.Current.Properties[healthStateKey] = HealthStates.GetHealthString(value);

            }
        }

        //Getting and Setting yoshi's name
        public string YoshiName
        {
            get
            {
                if (App.Current.Properties.ContainsKey(nameKey))
                {
                    return (string)App.Current.Properties[nameKey];
                }
                else
                {
                    return "No Name";
                }
            }
            set
            {
                App.Current.Properties[nameKey] = value;
            }
        }

        public Yoshi()
        {

        }
    }
}
