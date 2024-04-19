using System;
using Library.Convos.Models;
using Library.Convos.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace convosInterface.ViewModels
{
    public class AssignmentSubmissionDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Course SelectedCourse { get; set; }
        public Assignment SelectedAssignment { get; set; }

        public AssignmentSubmissionDetailViewModel(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
            if (SelectedAssignment == null) SelectedAssignment = new Assignment();
        }

        private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

