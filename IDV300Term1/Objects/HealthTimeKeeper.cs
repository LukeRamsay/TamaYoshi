using System;
namespace IDV300Term1.Objects
//Timer for yoshi's health need
{
    public class HealthTimeKeeper
    {

        const string healthStartTimeKey = "healthStartTime";
        const string healthStoredTimekey = "healthStoredTime";

        public DateTime HealthStartTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(healthStartTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[healthStartTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[healthStartTimeKey] = value.Ticks;
            }
        }

        public DateTime HealthStoredTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(healthStoredTimekey))
                {
                    return new DateTime((long)App.Current.Properties[healthStoredTimekey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[healthStoredTimekey] = value.Ticks;
            }
        }

        public HealthTimeKeeper()
        {

        }

        public double GetTimeElapsed()
        {
            return (HealthStoredTime - HealthStartTime).TotalSeconds;
        }
    }
}
