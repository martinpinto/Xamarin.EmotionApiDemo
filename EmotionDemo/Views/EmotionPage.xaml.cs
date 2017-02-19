using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class EmotionPage : ContentPage
	{
		private Person _person;

		public EmotionPage(Person person)
		{
			_person = person;

			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			var emotions = await EmotionApiService.GetEmotion(_person);

			BindingContext = emotions;

			ComputeEmotions(emotions);
		}

		private void ComputeEmotions(List<Emotion> emotions)
		{
			foreach (var emotion in emotions)
			{
				boxView = new BoxView
				{
					Color = Color.Accent,
					WidthRequest = 150,
					HeightRequest = 150,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					Opacity = 0.3
				};

				emotionScore.Text = emotion.ActualScore.ToString();
				emotionType.Text = emotion.EmotionType.ToString();

				imageUrl.Source = _person.ImageUrl;
				imageUrl.Scale = 1.9;
			}

		}
	}
}
