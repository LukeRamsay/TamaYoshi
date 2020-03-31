using System;
namespace IDV300Term1.Objects
//Timer for yoshi's sleep need
{
    public class BedTimeKeeper
    {

        const string bedStartTimeKey = "bedStartTime";
        const string bedStoredTimekey = "bedStoredTime";

        public DateTime BedStartTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(bedStartTimeKey))
                {
                    return new DateTime((long)App.Current.Properties[bedStartTimeKey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[bedStartTimeKey] = value.Ticks;
            }
        }

        public DateTime BedStoredTime
        {
            get
            {
                if (App.Current.Properties.ContainsKey(bedStoredTimekey))
                {
                    return new DateTime((long)App.Current.Properties[bedStoredTimekey]);
                }
                else
                {
                    return DateTime.Now;
                }
            }

            set
            {
                App.Current.Properties[bedStoredTimekey] = value.Ticks;
            }
        }

        public BedTimeKeeper()
        {

        }

        public double GetTimeElapsed()
        {
            return (BedStoredTime - BedStartTime).TotalSeconds;
        }
    }
}
