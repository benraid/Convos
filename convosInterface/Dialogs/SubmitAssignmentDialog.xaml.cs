using Library.Convos.Models;
using Library.Convos.Services;
using MAUI.Convos.ViewModels;
using MAUI.Convos.Views;

namespace MAUI.Convos.Dialogs;

public partial class SubmitAssignmentDialog : ContentPage
{
    public Assignment SelectedAssignment { get; set; }
    public int StudentId { get; set; }

    public SubmitAssignmentDialog(Assignment selectedAssignment, int studentId)
    {
        InitializeComponent();
        SelectedAssignment = selectedAssignment;
        StudentId = studentId;
    }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDetail");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SubmitAssignmentDialogViewModel(SelectedAssignment, StudentId);
    }

    private void SubmitAssignmentClick(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentDialogViewModel)?.SubmitAssignment();

        var studentDetailView = new StudentDetailView(StudentId);
        Shell.Current.Navigation.PushAsync(studentDetailView);
    }
}