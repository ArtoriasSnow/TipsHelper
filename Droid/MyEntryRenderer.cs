using System;
using TipsHelper;
using TipsHelper.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace TipsHelper.iOS
{

	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{

				Control.SetTextColor(Android.Graphics.Color.DarkRed);


			}
		}
	}
}

