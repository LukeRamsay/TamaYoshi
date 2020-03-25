using System;
namespace IDV300Term1.Objects
{
    public class AgeTimeKeeper
    {

        const string ageStartTimeKey = "ageStartTime";
        const string ageStoredTimekey = "ageStoredTime";

        public DateTime AgeStartTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(ageStartTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[ageStartTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[ageStartTimeKey] = value.Ticks;
            }
        }

        public DateTime ageStoredTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(ageStoredTimekey))
                {
                    return new DateTime((long)App.Current.Properties[ageStoredTimekey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[ageStoredTimekey] = value.Ticks;
            }
        }

        public AgeTimeKeeper()
        {

        }

        public double GetTimeElapsed()
        {
            return (ageStoredTime - AgeStartTime).TotalSeconds;
        }
    }
}
