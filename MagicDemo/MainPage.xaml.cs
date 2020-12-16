using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using MagicDemo.Services;
using MagicDemo.Common;
using Rg.Plugins.Popup.Extensions;

namespace MagicDemo
{
    public partial class MainPage : ContentPage
    {
        Service service = new Service();

        public MainPage()
        {
            InitializeComponent();
        }

        public async void btn_clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        var geocodeAddress = $"{placemark.FeatureName}, " + $"{placemark.SubLocality}, " + $"{placemark.SubAdminArea}, " + $"{placemark.PostalCode}, " +
                            $"{placemark.AdminArea}, " + $"{placemark.CountryName}.";

                        currentLoc.Text = geocodeAddress;

                        var isValid = service.ValidateLocation(placemark.SubAdminArea);

                        if (isValid)
                        {
                            await Navigation.PushPopupAsync(new PopUpPage(isValid));
                        }
                        else
                        {
                            await Navigation.PushPopupAsync(new PopUpPage(isValid));
                        }

                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception  
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception  
            }
            catch (Exception ex)
            {
                // Unable to get location  
            }
        }
    }
}
