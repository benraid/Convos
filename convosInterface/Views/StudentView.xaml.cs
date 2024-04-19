using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Convos.Models;
using Library.Convos.Services;
using MAUI.Convos.ViewModels;

namespace MAUI.Convos.Views;

public partial class StudentView : ContentPage
{
    public StudentView()
	{
        InitializeComponent();
	}

    private void BackClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.Refresh();
    }

    private void StudentInfoClick(object sender, EventArgs e)
    {
        int studentId = (BindingContext as StudentViewModel).SelectedStudent.Id;
        if (studentId > 0)
        {
            var studentDetailView = new StudentDetailView(studentId);
            Shell.Current.Navigation.PushAsync(studentDetailView);
        }
    }

    void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentViewModel();
    }
}