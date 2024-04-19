using MAUI.Convos.ViewModels;

namespace MAUI.Convos
{

	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
		}

		private void StudentClick(object sender, EventArgs e)
		{
			Shell.Current.GoToAsync("//Student");
		}

		private void InstructorClick(object sender, EventArgs e)
		{
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}