using Library.Convos.Models;
using Library.Convos.Services;
using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Dialogs;

[QueryProperty(nameof(SelectedId), "selectedId")] // pass ID in to update

public partial class UpdateStudentDialog : ContentPage
{
    public int SelectedId { get; set; } // ID to update

    public UpdateStudentDialog()
    {
        InitializeComponent();
        BindingContext = new UpdateStudentDialogViewModel(SelectedId);
    }
    private void SubmitClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e) // reset view model
    {
        BindingContext = new UpdateStudentDialogViewModel(SelectedId);
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