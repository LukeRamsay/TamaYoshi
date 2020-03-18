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

        private FoodTimeKeeper foodTimeKeeper = new FoodTimeKeeper();

        private BedTimeKeeper bedTimeKeeper = new BedTimeKeeper();

        private static Timer timer;

        private static Timer foodTimer;

        private static Timer bedTimer;

        public MainPage()
        {
            InitializeComponent();

            updateUI();

            updateFoodUI();

            updateBedUI();

            StartTimer();

            StartFoodTimer();

            StartBedTimer();
        }

        void feedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetFoodTimer();

            yoshi.giveFood();

            updateFoodUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void bathYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetTimer();

            yoshi.giveBath();

            updateUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void bedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetBedTimer();

            yoshi.giveBath();

            updateBedUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void updateUI()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                bathImage.Source = "shower_" + yoshi.CurrentBathState;
                

                if (yoshi.CurrentBathState == BathState.bad)
                {
                    YoshiDirty();
                }
            });
        }


        void updateFoodUI()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                foodImage.Source = "food_" + yoshi.CurrentFoodState;

                if (yoshi.CurrentFoodState == FoodState.bad)
                {
                    YoshiStarved();
                }
            });
        }

        void updateBedUI()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                bedImage.Source = "bed_" + yoshi.CurrentBedState;

                if (yoshi.CurrentBedState == BedState.bad)
                {
                    YoshiExuasted();
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
            ResetBedTimer();
            updateBedUI();
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

        private void StartBedTimer()
        {
            bedTimer = new Timer();
            bedTimer.Interval = 1000;
            bedTimer.Enabled = true;
            bedTimer.Elapsed += UpdateBedData;
            bedTimer.Start();
        }

        private void ResetFoodTimer()
        {
            foodTimeKeeper.FoodStartTime = DateTime.Now;
            StartFoodTimer();
        }

        private void ResetBedTimer()
        {
            bedTimeKeeper.BedStartTime = DateTime.Now;
            StartBedTimer();
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
            TimeSpan foodTimeElapsed = e.SignalTime - foodTimeKeeper.FoodStartTime;

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

        private void UpdateBedData(object sender, ElapsedEventArgs e)
        {
            TimeSpan bedTimeElapsed = e.SignalTime - bedTimeKeeper.BedStartTime;

            BedState newBedState = yoshi.CurrentBedState;

            if (bedTimeElapsed.TotalSeconds < 10)
            {
                newBedState = BedState.good;

            }
            else if (bedTimeElapsed.TotalSeconds < 20)
            {
                newBedState = BedState.normal;

            }
            else if (bedTimeElapsed.TotalSeconds >= 20)
            {
                newBedState = BedState.bad;

            }
            if (newBedState != yoshi.CurrentBedState)
            {
                yoshi.CurrentBedState = newBedState;


                updateBedUI();
            }

        }

        async void SwipeLeft(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new GamePage());
        }

    }
}
