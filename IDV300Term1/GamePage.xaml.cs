using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IDV300Term1
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();


        }

        async void SwipeRight(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
