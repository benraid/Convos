using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Dialogs;

public partial class AddCourseDialog : ContentPage
{
	public AddCourseDialog()
	{
		InitializeComponent();
	}

    private void SubmitClick(object sender, EventArgs e)
    {
        (BindingContext as AddCourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e) // reset view model
    {
        BindingContext = new AddCourseDialogViewModel();
    }
}