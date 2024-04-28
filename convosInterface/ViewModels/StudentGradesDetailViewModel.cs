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
        public KeyValuePair<string, double> SelectedGrade { get; set; }

        public StudentGradesDetailViewModel(Person selectedStudent)
        {
            SelectedStudent = selectedStudent;
        }

        private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void RemoveGrade()
        {
            if (SelectedStudent.Grades.ContainsKey(SelectedGrade.Key))
            {
                // did this to refresh the view because dictionaries do not notify when they change
                var newGrades = new Dictionary<string, double>(SelectedStudent.Grades);
                newGrades.Remove(SelectedGrade.Key);
                SelectedStudent.Grades = newGrades;

                NotifyPropertyChanged(nameof(SelectedStudent));
            }
        }
    }
}