using System;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels;

public class UpdateStudentDialogViewModel  // public so things can bind to the viewmodels
{
    public Person? student;

    public UpdateStudentDialogViewModel(int selectedId) // FIX ME
    {
        if (selectedId > 0)
            GetStudent(selectedId);
    }

    public string Name
    {
        get { return student?.Name ?? string.Empty; }
        set
        {
            if (student == null)
                student = new Person();
            student.Name = value;
        }
    }

    public int Id
    {
        get
        {
            if (student == null)
                student = new Person();
            return student.Id;
        }
        set
        {
            if (student == null)
                student = new Person();
            if (value == 0 || value < 0)
                student.Id = 0;
            else
                student.Id = value;
        }
    }

    public string Classification
    {
        get { return student?.Classification ?? string.Empty; }
        set
        {
            if (student == null)
                student = new Person();
            student.Classification = value;
        }
    }

    private void GetStudent(int Id)
    {
        var findStudent = StudentService.Current.FindPerson(Id);
        if (findStudent != null)
            student = findStudent;
    }

}