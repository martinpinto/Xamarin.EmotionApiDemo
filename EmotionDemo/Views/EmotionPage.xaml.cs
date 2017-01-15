﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class EmotionPage : ContentPage
	{
		public EmotionPage(Person person)
		{
			if (person == null)
			{
				throw new ArgumentNullException();
			}

			BindingContext = person;

			InitializeComponent();
		}
	}
}
