using MAUI.Convos.ViewModels;
using Microsoft.Maui.Controls;

namespace MAUI.Convos.Dialogs;

public partial class AddAssignmentDialog : ContentPage
{
    public string CourseCode { get; set; }

    public AddAssignmentDialog(string courseCode)
    {
        InitializeComponent();
        CourseCode = courseCode;
    }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddAssignmentDialogViewModel(CourseCode);
    }

    private void SubmitAssignmentClick(object sender, EventArgs e)
    {
        (BindingContext as AddAssignmentDialogViewModel)?.AddAssignment();
        Shell.Current.GoToAsync("//Instructor");
    }
}