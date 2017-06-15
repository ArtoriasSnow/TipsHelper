using System;
using TipsHelper;
using TipsHelper.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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
				
				Control.BackgroundColor = UIColor.FromRGB(255, 207, 207);

			}
		}
	}
}

