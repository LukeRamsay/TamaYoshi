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
using Rg.Plugins.Popup.Services;

namespace IDV300Term1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Yoshi yoshi = new Yoshi();

        private TimeKeeper timeKeeper = new TimeKeeper();

        private FoodTimeKeeper foodTimeKeeper = new FoodTimeKeeper();

        private BedTimeKeeper bedTimeKeeper = new BedTimeKeeper();

        private HealthTimeKeeper healthTimeKeeper = new HealthTimeKeeper();

        private AgeTimeKeeper ageTimeKeeper = new AgeTimeKeeper();

        private static Timer timer;

        private static Timer foodTimer;

        private static Timer bedTimer;

        private static Timer healthTimer;

        private static Timer ageTimer;

        public MainPage()
        {
            InitializeComponent();

            updateUI();

            updateFoodUI();

            updateBedUI();

            updateHealthUI();

            StartTimer();

            StartFoodTimer();

            StartBedTimer();

            StartHealthTimer();

            StartAgeTimer();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                    lbltime.Text = DateTime.Now.ToString("HH.mm:ss")
                );
                return true;
            });

        }

        void feedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetFoodTimer();

            updateFoodUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void bathYoshiTapped(System.Object sender, System.EventArgs e)
        {
            if (NameButton.Text != yoshi.YoshiName)
            {
                NameButton.Text = yoshi.YoshiName;
            }

            ResetTimer();

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

            updateBedUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void healthYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetHealthTimer();

            updateHealthUI();

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("button_click.mp3");
            player.Play();
        }

        void updateUI()
        {
            if (NameButton.Text != yoshi.YoshiName)
            {
                NameButton.Text = yoshi.YoshiName;
            }

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

        void updateHealthUI()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                healthImage.Source = "health_" + yoshi.CurrentHealthState;

                if (yoshi.CurrentHealthState == HealthState.bad)
                {
                    YoshiSick();
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

        private async void YoshiSick()
        {
            await DisplayAlert("Sick", "Yoshi has died form being sick", "Try Again");
            yoshi.CurrentHealthState = HealthState.good;
            ResetHealthTimer();
            updateHealthUI();
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

        private void StartAgeTimer()
        {
            ageTimer = new Timer();
            ageTimer.Interval = 1000;
            ageTimer.Enabled = true;
            ageTimer.Elapsed += UpdateAgeData;
            ageTimer.Start();
        }

        private void StartBedTimer()
        {
            bedTimer = new Timer();
            bedTimer.Interval = 1000;
            bedTimer.Enabled = true;
            bedTimer.Elapsed += UpdateBedData;
            bedTimer.Start();
        }

        private void StartHealthTimer()
        {
            healthTimer = new Timer();
            healthTimer.Interval = 1000;
            healthTimer.Enabled = true;
            healthTimer.Elapsed += UpdateHealthData;
            healthTimer.Start();
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

        private void ResetHealthTimer()
        {
            healthTimeKeeper.HealthStartTime = DateTime.Now;
            StartHealthTimer();
        }

        private void ResetAgeTimer()
        {
            ageTimeKeeper.ageStartTime = DateTime.Now;
            StartAgeTimer();
        }

        private void UpdateTimedData(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeElapsed = e.SignalTime - timeKeeper.StartTime;


            BathState newBathState = yoshi.CurrentBathState;

            if (yoshi.YoshiName != NameButton.Text)
            {
                NameButton.Text = yoshi.YoshiName.ToString();
            }

            if (timeElapsed.TotalSeconds < 10)
            {
                newBathState = BathState.good;
              
            }
            else if (timeElapsed.TotalSeconds < 20)
            {

                newBathState = BathState.normal;
              
            }
            else if (timeElapsed.TotalSeconds >= 20)
            {

                newBathState = BathState.bad;
            
            }
            if (newBathState != yoshi.CurrentBathState)
            {

                yoshi.CurrentBathState = newBathState;
                updateUI();

            }
        }

        public void UpdateAgeData(object sender, ElapsedEventArgs e)
        {
            TimeSpan ageTimeElapsed = e.SignalTime - ageTimeKeeper.ageStartTime;

            double daysOld = ageTimeElapsed.Seconds;

            AgeState newAgeState = yoshi.CurrentAgeState;

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

        private void UpdateHealthData(object sender, ElapsedEventArgs e)
        {
            TimeSpan healthTimeElapsed = e.SignalTime - healthTimeKeeper.HealthStartTime;

            HealthState newHealthState = yoshi.CurrentHealthState;

            if (healthTimeElapsed.TotalSeconds < 10)
            {
                newHealthState = HealthState.good;

            }
            else if (healthTimeElapsed.TotalSeconds < 20)
            {
                newHealthState = HealthState.normal;

            }
            else if (healthTimeElapsed.TotalSeconds >= 20)
            {
                newHealthState = HealthState.bad;

            }
            if (newHealthState != yoshi.CurrentHealthState)
            {
                yoshi.CurrentHealthState = newHealthState;

                updateHealthUI();
            }

        }

        async void SwipeLeft(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new GamePage());
        }

    }
}
