using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class EmotionDemoPage : ContentPage
	{
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new PersonListPage());
		}

		public EmotionDemoPage()
		{
			InitializeComponent();
		}
	}
}
