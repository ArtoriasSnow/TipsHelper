using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TipsHelper
{
	public partial class MainMenu : ContentPage
	{
		private double StepValue;

		public MainMenu()
		{
			InitializeComponent();
			SetSliderBehaviour();
			entryAmount.TextChanged += EntryAmount_TextChanged;
		}

		public void SetSliderBehaviour()
		{
			StepValue = 0.05;
			sliderQualityService.ValueChanged += OnSliderValueChanged;
		}

		private void EntryAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!entryAmount.Text.Equals(""))
			{

				if (Convert.ToDouble(entryAmount.Text) > 100)
				{
					sliderQualityService.Value = 0.20;

				}
				else
				{

					sliderQualityService.Value = 0.15;
				}
			}
		}

		void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{

			var newStep = Math.Round(e.NewValue / StepValue);
			sliderQualityService.Value = newStep * StepValue;
			double amount = Convert.ToDouble(entryAmount.Text);
			entryTotalAmount.Text = (amount + (amount * sliderQualityService.Value)).ToString("N2");
			entryTip.Text = (sliderQualityService.Value * amount).ToString("N2");
			ChangeQualityServiceDescription(sliderQualityService.Value);

		}

		void ChangeQualityServiceDescription(double step) {

		
			labelQualityServiceDesc.Text =  step * 100 + "%";

			if (step*100 < 15)
			{

				labelQualityServiceDesc.TextColor = Color.Red;
			}
			else if (step*100 >= 15 && step*100 < 20)
			{
				labelQualityServiceDesc.TextColor = Color.Black;
			}
			else {
				labelQualityServiceDesc.TextColor = Color.Green;
			}

		}

	}
}
