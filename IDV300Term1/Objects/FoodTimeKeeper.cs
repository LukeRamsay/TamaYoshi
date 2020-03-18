using System;
namespace IDV300Term1.Objects
{
    public class FoodTimeKeeper
    {
        const string foodStartTimeKey = "foodStartTime";
        const string foodStoredTimekey = "foodStoredTime";

        public DateTime FoodStartTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(foodStartTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[foodStartTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[foodStartTimeKey] = value.Ticks;
            }
        }

        public DateTime FoodStoredTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(foodStoredTimekey))
                {
                    return new DateTime((long)App.Current.Properties[foodStoredTimekey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[foodStoredTimekey] = value.Ticks;
            }
        }

        public FoodTimeKeeper()
        {

        }

        public double GetTimeElapsed()
        {
            return (FoodStoredTime - FoodStartTime).TotalSeconds;
        }
    }
}
