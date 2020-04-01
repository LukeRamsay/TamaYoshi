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

            StartAgeTimer();

            ResetAgeTimer();

            updateAgeUI();

            updateUI();

            updateFoodUI();

            updateBedUI();

            updateHealthUI();

            StartTimer();

            StartFoodTimer();

            StartBedTimer();

            StartHealthTimer();

            var bSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            bSound.Load("yoshi-background.mp3");
            bSound.Play();

            //Getting the current time(will be used to determine how old the yoshi is)

            Device.BeginInvokeOnMainThread(() =>
            {

                lbltime.Text = "Your yoshi was born on " + DateTime.Now.ToString("HH.mm:ss");

            });
             
               
        

            //This messagign centre was used to try and update the label for the name automatically but
            //MessagingCenter.Subscribe<MainPage>(this, "Hi", (GamePage) =>
            //{
            //    updateNameUI();
            //});

        }

        //trying to update the name ui whenever the page appears or disapears
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    updateNameUI();
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    updateNameUI();
        //}


        //Starting all of the timers once the egg is ready to hatch
        void hatchYoshiTapped(System.Object sender, System.EventArgs e)
        {

            //AgeState newAgeState = yoshi.CurrentAgeState;

            //newAgeState = AgeState.hatchling;
            //reset and start age timer

        }

        //Grouping the button sounds and vibration when clicked 
        void buttonFunctionality(System.Object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            //var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load("button_click.mp3");
            //player.Play();

        }


        //Resetign timer for the hunger need and food ui
        void feedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetFoodTimer();

            updateFoodUI();

            var foodSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            foodSound.Load("yoshi-eat.mp3");
            foodSound.Play();
        }

        //Reseting timer for hygiene need and bath ui
        void bathYoshiTapped(System.Object sender, System.EventArgs e)
        {

            ResetTimer();

            updateUI();

            var bathSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            bathSound.Load("yoshi-shower.mp3");
            bathSound.Play();

        }

        //Reseting timer for sleep need and sleep ui
        void bedYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetBedTimer();

            updateBedUI();

            var bedSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            bedSound.Load("yoshi-sleep.mp3");
            bedSound.Play();
        }

        //Resetting the timer for health and its ui
        void healthYoshiTapped(System.Object sender, System.EventArgs e)
        {
            ResetHealthTimer();

            updateHealthUI();

            var healSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            healSound.Load("yoshi-heal.mp3");
            healSound.Play();
        }

        //Updating the name text when it is changed (trying to call it on the name page so it automactically updates when navigating.)
        public void updateNameUI(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if(NameButton.Text != yoshi.YoshiName)
                {
                    NameButton.Text = yoshi.YoshiName;
                };

            });

        }

        //Changing the bath image based on the state of the hygiene need
        void updateUI()
        {

            Device.BeginInvokeOnMainThread( () =>
            {
              
                bathImage.Source = "shower_" + yoshi.CurrentBathState;

            });
        }

        //Changing the food image based on the state of the hunger need
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

        //Changing the bed image based on the state of the sleep need
        void updateBedUI()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                bedImage.Source = "bed_" + yoshi.CurrentBedState;

            });
        }

        //Changing the Yoshi image based on the age state so if he is an egg or an elder ect (This might chnage)
        void updateAgeUI()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                yoshiImage.Source = "yoshi_" + yoshi.CurrentAgeState;

                if (yoshi.CurrentAgeState == AgeState.egg)
                {
                    yoshiImage.Scale = 0.4;
                }
                else if (yoshi.CurrentAgeState == AgeState.teen)
                {
                    yoshiImage.Scale = 0.5;
                }
                else
                {
                    yoshiImage.Scale = 1;
                }
               
            });
        }

        //Changing the health image based on the state of the health need
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

        //Alerting the user if the yoshi has not been fed for too long
        private async void YoshiStarved()
        {
            updateHealthUI();
            await DisplayAlert("Starved", "Yoshi has starved to death", "Try Again");
            yoshi.CurrentFoodState = FoodState.good;
            yoshi.CurrentBathState = BathState.good;
            yoshi.CurrentHealthState = HealthState.good;
            yoshi.CurrentBedState = BedState.good;
            ResetBedTimer();
            ResetFoodTimer();
            ResetHealthTimer();
            ResetTimer();
            updateBedUI();
            updateUI();
            updateHealthUI();
            updateFoodUI();

            var deadSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            deadSound.Load("yoshi-dead.mp3");
            deadSound.Play();
        }

        //Alerting the user if the yoshi has become too sick
        private async void YoshiSick()
        {
            updateFoodUI();
            await DisplayAlert("Sick", "Yoshi has died form being sick", "Try Again");
            yoshi.CurrentFoodState = FoodState.good;
            yoshi.CurrentBathState = BathState.good;
            yoshi.CurrentHealthState = HealthState.good;
            yoshi.CurrentBedState = BedState.good;
            ResetBedTimer();
            ResetFoodTimer();
            ResetHealthTimer();
            ResetTimer();
            updateBedUI();
            updateUI();
            updateHealthUI();
            updateFoodUI();

            var deadSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            deadSound.Load("yoshi-dead.mp3");
            deadSound.Play();
        }


        //Timer used for bath need
        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += UpdateTimedData;
            timer.Start();
        }

        //Timer used for the hunger need
        private void StartFoodTimer()
        {
            foodTimer = new Timer();
            foodTimer.Interval = 1000;
            foodTimer.Enabled = true;
            foodTimer.Elapsed += UpdateFoodData;
            foodTimer.Start();
        }

        //Timer used for aging
        private void StartAgeTimer()
        {
            ageTimer = new Timer();
            ageTimer.Interval = 1000;
            ageTimer.Enabled = true;
            ageTimer.Elapsed += UpdateAgeData;
            ageTimer.Start();
        }

        //Timer used for sleep need
        private void StartBedTimer()
        {
            bedTimer = new Timer();
            bedTimer.Interval = 1000;
            bedTimer.Enabled = true;
            bedTimer.Elapsed += UpdateBedData;
            bedTimer.Start();
        }

        //Timer used for health need
        private void StartHealthTimer()
        {
            healthTimer = new Timer();
            healthTimer.Interval = 1000;
            healthTimer.Enabled = true;
            healthTimer.Elapsed += UpdateHealthData;
            healthTimer.Start();
        }

        //Reset for bath need timer
        private void ResetTimer()
        {
            timeKeeper.StartTime = DateTime.Now;
            StartTimer();
        }

        //Reset for food need timer
        private void ResetFoodTimer()
        {
            foodTimeKeeper.FoodStartTime = DateTime.Now;
            StartFoodTimer();
        }

        //Reset for aging timer
        private void ResetAgeTimer()
        {
            ageTimeKeeper.AgeStartTime = DateTime.Now;
            StartAgeTimer();
        }

        //Reset for sleep need timer
        private void ResetBedTimer()
        {
            bedTimeKeeper.BedStartTime = DateTime.Now;
            StartBedTimer();
        }

        //Reset for health need timer
        private void ResetHealthTimer()
        {
            healthTimeKeeper.HealthStartTime = DateTime.Now;
            StartHealthTimer();
        }


        //Using the timer to change the state of the bath need and calling to update the bath ui
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

        //Using the timer to change the age state of the Yoshi need and calling to update the age ui
        private void UpdateAgeData(object sender, ElapsedEventArgs e)
        {

            TimeSpan ageTimeElapsed = e.SignalTime - ageTimeKeeper.AgeStartTime;

            AgeState newAgeState = yoshi.CurrentAgeState;

            if (ageTimeElapsed.TotalSeconds < 10)
            {
                newAgeState = AgeState.egg;

            }
            else if (ageTimeElapsed.TotalSeconds < 20)
            {
                newAgeState = AgeState.teen;
            }
            else if (ageTimeElapsed.TotalSeconds < 30)
            {
                newAgeState = AgeState.adult;

            }

            if (newAgeState != yoshi.CurrentAgeState)
            {
                yoshi.CurrentAgeState = newAgeState;

                updateAgeUI();
            }

        }

        //Using the timer to change the state of the hunger need and calling to update the food ui
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

        //Using the timer to change the state of the sleep need and calling to update the bed ui
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

        //Using the timer to change the state of the health need and calling to update the health ui
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

        //Navigating to the popup for chnaging Yoshi's name
        async void SwipeLeft(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new GamePage());
        }

    }
}
