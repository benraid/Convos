// StudentGradesDetailView.xaml.cs
using Library.Convos.Models;
using convosInterface.ViewModels;
using Microsoft.Maui.Controls;

namespace MAUI.Convos.Views
{
    public partial class StudentGradesDetailView : ContentPage
    {
        public StudentGradesDetailView(Person selectedStudent)
        {
            InitializeComponent();
            BindingContext = new StudentGradesDetailViewModel(selectedStudent);
        }

        public void RemoveGradeClick(object sender, EventArgs e)
        {
            (BindingContext as StudentGradesDetailViewModel)?.RemoveGrade();
        }
    }
}