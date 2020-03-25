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

        public GamePage()
        {
            InitializeComponent();

        }

        async void SaveYoshiName(object sender, EventArgs e)
        {
            yoshi.YoshiName = NameInput.Text;
            await PopupNavigation.Instance.PopAsync();
            
        }
    }
}
