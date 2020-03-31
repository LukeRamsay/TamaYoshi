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
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;
using IDV300Term1;


namespace IDV300Term1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : PopupPage
    {
        private Yoshi yoshi = new Yoshi();
        private MainPage mainPage = new MainPage();


        public GamePage()
        {
            InitializeComponent();

        }

        //Chnaging yoshi's name and navigating back to the main page
        async void SaveYoshiName(object sender, EventArgs e)
        {
            

            yoshi.YoshiName = NameInput.Text;
            
            await PopupNavigation.Instance.PopAsync();

            //mainPage.updateNameUI();
            //Trying to call update ui for the changin of the name when navigating back to the original page
            // MessagingCenter.Send<GamePage>(this, "Hi");

        }

    }
}
