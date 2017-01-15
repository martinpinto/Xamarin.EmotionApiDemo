using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class EmotionPage : ContentPage
	{
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

			Emotion emotion = new Emotion
			{

			};

			BindingContext = emotion;

			InitializeComponent();
		}	
	}
}
