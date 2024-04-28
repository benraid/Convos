using convosInterface.ViewModels;
using Library.Convos.Models;

namespace MAUI.Convos.Views;

public partial class AssignmentSubmissionDetailView : ContentPage
{
    public Course SelectedCourse { get; set; }

    public AssignmentSubmissionDetailView(Course selectedCourse)
    {
        InitializeComponent();
        SelectedCourse = selectedCourse;
    }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentSubmissionDetailViewModel(SelectedCourse);
    }

    private void ViewSubmissionsClick(object sender, EventArgs e)
    {
        BindingContext = new AssignmentSubmissionDetailViewModel(SelectedCourse);
    }

    private void SubmitGradeClick(object sender, EventArgs e)
    {
        (BindingContext as AssignmentSubmissionDetailViewModel)?.SubmitGrade();
    }
}
