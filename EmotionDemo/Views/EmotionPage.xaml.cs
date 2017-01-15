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
			JContainer emotionJson = await EmotionApiService.GetEmotion(_person);

			BindingContext = emotionJson.ToString();

		}

		public EmotionPage(String emotion)
		{
			if (emotion == null)
			{
				throw new ArgumentNullException();
			}

			BindingContext = emotion;

			InitializeComponent();
		}

		public EmotionPage(JContainer emotionJson)
		{
			if (emotionJson == null)
			{
				Navigation.PopAsync();
			}
			/*
			EmotionCollection emotions = new EmotionCollection();
			dynamic dynJson = JsonConvert.DeserializeObject(emotionJson.ToString());

			JArray arr = JArray.Parse(emotionJson.ToString());
			var obj = arr.Values();
			foreach (var it in obj)
			{
				var itobj = it.Values();
				foreach (var itobjit in itobj)
				{
				}
			}
			foreach (var item in dynJson)
			{
				Emotion emotion = new Emotion(
					item.faceRectangle,
					item.scores
				);
				emotions.Add(emotion);
			}

			// BindingContext = emotions;
			*/
			BindingContext = emotionJson.ToString();
			InitializeComponent();
		}

		private void ParseEmotions()
		{
			boxView = new BoxView
			{
				Color = Color.Accent,
				WidthRequest = 150,
				HeightRequest = 150,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
		}
	}
}
