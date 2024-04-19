using Library.Convos.Models;
using MAUI.Convos.Dialogs;
using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Views;

public partial class StudentDetailView : ContentPage
{
    public int StudentId { get; set; }

    public StudentDetailView(int studentId)
	{
        InitializeComponent();
        StudentId = studentId;
    }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDetailViewModel(StudentId);
    }

    private void CourseInfoClick(object sender, EventArgs e)
    {
        BindingContext = new StudentDetailViewModel(StudentId);
    }

    private void SubmitAssignmentClick(object sender, EventArgs e)
    {
        var selectedAssignment = (BindingContext as StudentDetailViewModel)?.SelectedAssignment ?? new Assignment();
        var studentId = StudentId;
        if (selectedAssignment != null && selectedAssignment.Name != string.Empty)
        {
            var submitAssignmentDialog = new SubmitAssignmentDialog(selectedAssignment, studentId);
            Shell.Current.Navigation.PushAsync(submitAssignmentDialog);
        }
    }
}