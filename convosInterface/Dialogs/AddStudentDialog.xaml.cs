using Library.Convos.Services;
using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Dialogs;

public partial class AddStudentDialog : ContentPage
{
	public AddStudentDialog()
	{
        InitializeComponent();
        BindingContext = new AddStudentDialogViewModel();
	}

    private void SubmitClick(object sender, EventArgs e)
    {
        (BindingContext as AddStudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e) // reset view model
    {
        BindingContext = new AddStudentDialogViewModel();
    }

    private void OnClassificationChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            if (BindingContext is AddStudentDialogViewModel viewModel)
            {
                if (radioButton == FreshmanRadioButton)
                    viewModel.Classification = "Freshman";
                else if (radioButton == SophomoreRadioButton)
                    viewModel.Classification = "Sophomore";
                else if (radioButton == JuniorRadioButton)
                    viewModel.Classification = "Junior";
                else if (radioButton == SeniorRadioButton)
                    viewModel.Classification = "Senior";
            }
        }
    }

}