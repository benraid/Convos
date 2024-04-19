using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels;

public class AddCourseDialogViewModel : ContentPage
{
    public Course? newCourse;

    public AddCourseDialogViewModel() { newCourse = new Course { Code = "CourseCode1", Name = "My Course", Description = "Course Description"}; }

    public string Name
    {
        get { return newCourse?.Name ?? string.Empty; }
        set
        {
            if (newCourse == null)
                newCourse = new Course();
            newCourse.Name = value;
        }
    }

    public string Code
    {
        get { return newCourse?.Code ?? string.Empty; }
        set
        {
            if (newCourse == null)
                newCourse = new Course();
            newCourse.Code = value;
        }
    }

    public string Description
    {
        get { return newCourse?.Description ?? string.Empty; }
        set
        {
            if (newCourse == null)
                newCourse = new Course();
            newCourse.Description = value;
        }
    }

    public void AddCourse()
    {
        if (newCourse != null)
            CourseService.Current.AddCourse(newCourse);
    }
}