using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Spectrum
{
    public class SearchBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            //Add a TextChanged handler.
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Bindable_TextChanged;

        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If the zip code is less than 5 digits, set the TextColor to red. Once 5, set it to green.
            string zipRegex = "^[0-9]{5}$";
            var search = sender as SearchBar;
            if (!string.IsNullOrWhiteSpace(search.Text))
            {
                if (Regex.IsMatch(search.Text, zipRegex,
                     RegexOptions.IgnoreCase))
                {
                    search.TextColor = Color.Green;
                }
                else
                    search.TextColor = Color.Red;
            }
            else
                search.TextColor = Color.Red;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

    }
}
