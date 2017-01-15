using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class PersonListPage : ContentPage
	{
		private List<Person> _persons;

		public PersonListPage()
		{
			InitializeComponent();

			listView.ItemsSource = EmotionApiService.GetPersons();
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			listView.ItemsSource = EmotionApiService.GetPersons(e.NewTextValue);
		}

		void Handle_Refreshing(object sender, System.EventArgs e)
		{
			listView.ItemsSource = EmotionApiService.GetPersons();
			listView.EndRefresh();
		}

		void Delete_Clicked(object sender, System.EventArgs e)
		{
			var person = (sender as MenuItem).CommandParameter as Person;
			_persons.Remove(person);
		}

		void Follow_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Clicked", "Thank you for following me!", "OK");
		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			//var person = e.SelectedItem as Person;
			//DisplayAlert("Selected", person.Name, "OK");
			listView.SelectedItem = null;
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e.Item == null)
			{
				return;
			}
			var person = e.Item as Person;
			//DisplayAlert("Tapped", person.Status, "OK");
			//string response = await EmotionApiService.GetEmotion(person);
			JContainer response = await EmotionApiService.GetEmotion(person);
			await Navigation.PushAsync(new EmotionPage(response));
		}
	}
}
