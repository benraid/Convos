using System;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels;

// Add New Student View Model
public class AddStudentDialogViewModel // public so things can bind to the viewmodels
{
	public Person? newStudent;

    public AddStudentDialogViewModel() { newStudent = new Person(); }

    public string Name
	{
		get	{ return newStudent?.Name ?? string.Empty; }
		set
		{
			if (newStudent == null)
				newStudent = new Person();
            newStudent.Name = value;
        }
	}

	public int Id
	{
		get
		{
			if (newStudent == null)
				newStudent = new Person();
			return newStudent.Id;
		}
		set
		{
            if (newStudent == null)
                newStudent = new Person();
            if (value == 0 || value < 0)
                newStudent.Id = 0;
            else
                newStudent.Id = value;
        }
	}

    public string Classification
    {
        get { return newStudent?.Classification ?? string.Empty; }
        set
        {
            if (newStudent == null)
                newStudent = new Person();
            newStudent.Classification = value;
        }
    }

    public void AddStudent()
	{
		if (newStudent != null)
			StudentService.Current.AddStudent(newStudent);
	}
}