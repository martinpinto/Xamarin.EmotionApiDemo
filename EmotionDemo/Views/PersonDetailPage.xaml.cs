using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class PersonDetailPage : ContentPage
	{
		public PersonDetailPage(Person person)
		{
			person.ImageUrl = "http://lorempixel.com/1000/1000/people/" + person.ImageUrl.Substring(person.ImageUrl.Length - 1);

			BindingContext = person;

			InitializeComponent();
		}
	}
}
