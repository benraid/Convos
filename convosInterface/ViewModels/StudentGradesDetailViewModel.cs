// StudentGradesDetailViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Convos.Models;

namespace convosInterface.ViewModels
{
    public class StudentGradesDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Person SelectedStudent { get; set; }

        public StudentGradesDetailViewModel(Person selectedStudent)
        {
            SelectedStudent = selectedStudent;
        }

        private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}