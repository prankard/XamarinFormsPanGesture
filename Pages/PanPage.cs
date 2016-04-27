using System;
using Xamarin.Forms;

namespace TestPanGesture
{
	public class PanPage : ContentPage
	{
		BoxView boxView;

		public PanPage ()
		{
			boxView = new BoxView ();
			boxView.Color = Color.Blue;

			var panGesture = new PanGestureRecognizer ();
			panGesture.PanUpdated += OnPanUpdated;
			boxView.GestureRecognizers.Add (panGesture);

			Content = new AbsoluteLayout {
				Children =  { boxView }
			};
		}

		private double xValue;

		void OnPanUpdated (object sender, PanUpdatedEventArgs e)
		{
			switch (e.StatusType) 
			{
			case GestureStatus.Running:
				boxView.TranslationX = xValue + e.TotalX;
				break;
			case GestureStatus.Completed:
				xValue = boxView.TranslationX;
				break;
			}
		}
	}
}


