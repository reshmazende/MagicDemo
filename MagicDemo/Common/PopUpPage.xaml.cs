using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MagicDemo.Common
{
    public partial class PopUpPage : PopupPage
    {
        public PopUpPage(bool isValid)
        {
            InitializeComponent();

            if (isValid)
            {
                isValidLabel.Text = "Allowed";
                isValidIcon.Source = "validIcon";
            }
            else
            {
                isValidLabel.Text = "Not Allowed";
                isValidIcon.Source = "invalidIcon";
            }
        }
    }
}
