using MAUI.Convos.Dialogs;
using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Views;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewModel();
    }

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddStudentClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddStudent");
    }

    private void UpdateStudentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.UpdateStudent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel)?.Refresh();
    }

    private void RemoveStudentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RemoveStudent();
    }

    private void AddCourseClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddCourse");
    }

    private void AddModuleClick(object sender, EventArgs e)
    {
        var courseCode = (BindingContext as InstructorViewModel)?.SelectedCourse.Code;
        if (courseCode != null && courseCode != string.Empty)
        {
            var addModuleDialog = new AddModuleDialog(courseCode);
            Shell.Current.Navigation.PushAsync(addModuleDialog);
        }
    }

    private void AddEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.AddEnrollment();
    }

    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RemoveEnrollment();
    }

    private void AddAssignmentClick(object sender, EventArgs e)
    {
        var courseCode = (BindingContext as InstructorViewModel)?.SelectedCourse.Code;
        if (courseCode != null && courseCode != string.Empty)
        {
            var assignmentDialog = new AddAssignmentDialog(courseCode);
            Shell.Current.Navigation.PushAsync(assignmentDialog);
        }
    }

    private void ViewAssignmentsClick(object sender, EventArgs e)
    {
        var selectedCourse = (BindingContext as InstructorViewModel)?.SelectedCourse;
        if (selectedCourse != null && selectedCourse.Code != string.Empty)
        {
            var assignmentSubmissionDetailView = new AssignmentSubmissionDetailView(selectedCourse);
            Shell.Current.Navigation.PushAsync(assignmentSubmissionDetailView);
        }
    }
}