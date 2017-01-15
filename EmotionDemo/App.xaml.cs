using Xamarin.Forms;

namespace EmotionDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			BindingContext = Application.Current;

			MainPage = new NavigationPage(new EmotionDemoPage())
			{
				BarBackgroundColor = Color.Gray,
				BarTextColor = Color.White
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
