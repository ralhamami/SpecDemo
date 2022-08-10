using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreDetails : ContentPage
    {
        public StoreDetails()
        {
            InitializeComponent();

            //Add gesture recognizer for phone number label, and launch dialer.
            var phoneTapRecognizer = new TapGestureRecognizer();
            phoneTapRecognizer.Tapped += (s, e) => {
                var number = (s as Label).Text;
                PhoneDialer.Open(number);
            };

            phoneLabel.GestureRecognizers.Add(phoneTapRecognizer);

            //Add gesture recognizer for address label, and launch directions.
            var addressTapRecognizer = new TapGestureRecognizer();
            addressTapRecognizer.Tapped += async (s, e) => {
                var address = (s as Label).Text;
                await Launcher.OpenAsync("http://maps.google.com/?daddr=" + address);
            };

            address.GestureRecognizers.Add(addressTapRecognizer);
        }

        public void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}