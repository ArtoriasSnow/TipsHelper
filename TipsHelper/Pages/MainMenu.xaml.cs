using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TipsHelper
{
	public partial class MainMenu : ContentPage
	{
		private double StepValue;
		private int percent;

		public MainMenu()
		{
			InitializeComponent();
			SetSliderBehaviour();
			entryAmount.TextChanged += EntryAmount_TextChanged;
		}

		public void SetSliderBehaviour()
		{
			//El porcentaje de propinas es desde 0 al 30%, por lo que se establecen tramos de 5 en 5
			//El slider comprende valores 1.0 a 1.30 (para facilitar el cálculo directo) por lo que stepValue vale 0.05
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
			percent = (int) step * 100;

			if (percent < 15)
			{

				labelQualityServiceDesc.TextColor = Color.Red;
			}
			else if (percent >= 15 && percent < 20)
			{
				labelQualityServiceDesc.TextColor = Color.Black;
			}
			else {
				labelQualityServiceDesc.TextColor = Color.Green;
			}

		}

	}
}
