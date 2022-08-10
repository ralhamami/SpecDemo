using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Spectrum.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Spectrum")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace Spectrum.Droid
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			//Set the shadow effect specifics on the control.
			try
			{
				var control = Control as Android.Widget.TextView;
				var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
				if (effect != null)
				{
					float radius = effect.Radius;
					float distanceX = effect.DistanceX;
					float distanceY = effect.DistanceY;
					Android.Graphics.Color color = effect.Color.ToAndroid();
					control.SetShadowLayer(radius, distanceX, distanceY, color);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error encountered while setting control shadow.", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}
	}
}