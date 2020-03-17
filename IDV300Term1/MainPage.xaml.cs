using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using IDV300Term1.Objects;
using System.Timers;
using Xamarin.Essentials;

namespace IDV300Term1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Yoshi yoshi = new Yoshi();

        private TimeKeeper timeKeeper = new TimeKeeper();

        private static Timer timer;

        private static Timer foodTimer;

        public MainPage()
        {
            InitializeComponent();

            updateUI();

            updateFoodUI();

            StartTimer();

            StartFoodTimer();
        }

        void feedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetFoodTimer();

            yoshi.giveFood();

            updateFoodUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

        }

        void bathYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetTimer();

            yoshi.giveBath();

            updateUI();
        }

        void bedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetTimer();

            yoshi.giveBath();

            updateUI();
        }

        void updateUI()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                bathImage.Source = "shower_" + yoshi.CurrentBathState;
                bedImage.Source = "bed_" + yoshi.CurrentBedState;

                if (yoshi.CurrentBathState == BathState.bad)
                {
                    YoshiDirty();
                }
                if (yoshi.CurrentBedState == BedState.bad)
                {
                    YoshiExuasted();
                }
            });
        }


        void updateFoodUI()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                foodImage.Source = "food_" + yoshi.CurrentFoodState;

                if (yoshi.CurrentFoodState == FoodState.bad)
                {
                    YoshiStarved();
                }
            });
        }

        private async void YoshiStarved()
        {
            await DisplayAlert("Starved", "Yoshi has starved to death", "Try Again");
            yoshi.CurrentFoodState = FoodState.good;
            ResetFoodTimer();
            updateFoodUI();
        }

        private async void YoshiDirty()
        {
            await DisplayAlert("Dirty", "Yoshi has died form being dirty", "Try Again");
            yoshi.CurrentBathState = BathState.good;
            ResetTimer();
            updateUI();
        }

        private async void YoshiExuasted()
        {
            await DisplayAlert("Exuasted", "Yoshi has died form being too tired", "Try Again");
            yoshi.CurrentBedState = BedState.good;
            ResetTimer();
            updateUI();
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += UpdateTimedData;
            timer.Start();
        }

        private void ResetTimer()
        {
            timeKeeper.StartTime = DateTime.Now;
            StartTimer();
        }

        private void StartFoodTimer()
        {
            foodTimer = new Timer();
            foodTimer.Interval = 1000;
            foodTimer.Enabled = true;
            foodTimer.Elapsed += UpdateFoodData;
            foodTimer.Start();
        }

        private void ResetFoodTimer()
        {
            timeKeeper.StartTime = DateTime.Now;
            StartFoodTimer();
        }

        private void UpdateTimedData(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeElapsed = e.SignalTime - timeKeeper.StartTime;


            BathState newBathState = yoshi.CurrentBathState;
            BedState newBedState = yoshi.CurrentBedState;

            if (timeElapsed.TotalSeconds < 10)
            {
                newBathState = BathState.good;
                newBedState = BedState.good;
            }
            else if (timeElapsed.TotalSeconds < 20)
            {

                newBathState = BathState.normal;
                newBedState = BedState.normal;
            }
            else if (timeElapsed.TotalSeconds >= 20)
            {

                newBathState = BathState.bad;
                newBedState = BedState.bad;
            }
            if (newBedState != yoshi.CurrentBedState || newBathState != yoshi.CurrentBathState)
            {

                yoshi.CurrentBathState = newBathState;
                yoshi.CurrentBedState = newBedState;
                updateUI();

            }
        }

        private void UpdateFoodData(object sender, ElapsedEventArgs e)
        {
            TimeSpan foodTimeElapsed = e.SignalTime - timeKeeper.StartTime;

            FoodState newFoodState = yoshi.CurrentFoodState;

            if (foodTimeElapsed.TotalSeconds < 10)
            {
                newFoodState = FoodState.good;

            }
            else if (foodTimeElapsed.TotalSeconds < 20)
            {
                newFoodState = FoodState.normal;

            }
            else if (foodTimeElapsed.TotalSeconds >= 20)
            {
                newFoodState = FoodState.bad;

            }
            if (newFoodState != yoshi.CurrentFoodState)
            {
                yoshi.CurrentFoodState = newFoodState;


                updateFoodUI();
            }

        }

        async void SwipeLeft(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new GamePage());
        }

    }
}
