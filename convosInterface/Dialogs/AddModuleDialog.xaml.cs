using MAUI.Convos.ViewModels;
using Microsoft.Maui.Controls;

namespace MAUI.Convos.Dialogs;

public partial class AddModuleDialog : ContentPage
{
    public AddModuleDialog(string courseCode)
    {
        InitializeComponent();
        CourseCode = courseCode;
    }

    public string CourseCode { get; set; }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddModuleDialogViewModel(CourseCode);
    }

    private void SubmitModuleClick(object sender, EventArgs e)
    {
        (BindingContext as AddModuleDialogViewModel)?.AddModule(CourseCode);
        Shell.Current.GoToAsync("//Instructor");
    }
}