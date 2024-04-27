using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels;

internal class InstructorViewModel : INotifyPropertyChanged
{
    private StudentService studentService;
    private CourseService courseService;
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public ObservableCollection<Person> Students //display students of current student service
    {
        get { return new ObservableCollection<Person>(studentService.Students); }
    }

    public ObservableCollection<Course> Courses //display courses of current course service
    {
        get { return new ObservableCollection<Course>(courseService.Courses); }
    }

    public ObservableCollection<Assignment> SelectedCourseAssignments
    {
        get
        {
            if (SelectedCourse != null)
                return new ObservableCollection<Assignment>(SelectedCourse.Assignments);
            else
                return new ObservableCollection<Assignment>();
        }
    }

    public InstructorViewModel()
    {
        if (SelectedStudent == null)
            SelectedStudent = new Person();
        if (SelectedCourse == null)
            SelectedCourse = new Course();
        studentService = StudentService.Current;
        courseService = CourseService.Current;
    }

    public void Refresh() { NotifyPropertyChanged(nameof(Students)); NotifyPropertyChanged(nameof(Courses)); NotifyPropertyChanged(nameof(SelectedCourseAssignments)); } // refresh the Instructor View

    public Person SelectedStudent { get; set; }
    public Course SelectedCourse { get; set; }

    public void RemoveStudent()
    {
        studentService.RemoveStudent(SelectedStudent);
        Refresh();
    }

    public void UpdateStudent()
    {
        var selectedId = SelectedStudent.Id;
        if (selectedId > 0)
            Shell.Current.GoToAsync($"//UpdateStudent?selectedStudent={selectedId}");
        Refresh();
    }

    public void AddEnrollment()
    {
        if (SelectedStudent != null && SelectedCourse != null)
        {
            courseService.AddEnrollment(SelectedStudent, SelectedCourse);
            Refresh();
        }
    }

    public void RemoveEnrollment()
    {
        if (SelectedStudent != null && SelectedCourse != null)
        {
            courseService.RemoveEnrollment(SelectedStudent, SelectedCourse);
            Refresh();
        }
    }

    public void RemoveCourse()
    {
        courseService.RemoveCourse(SelectedCourse);
        Refresh();
    }
}