using System;
using Library.Convos.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Library.Convos.Services;

namespace convosInterface.ViewModels
{
    public class AssignmentSubmissionDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Course SelectedCourse { get; set; }
        public Assignment SelectedAssignment { get; set; }
        public string GradeInput { get; set; }
        public AssignmentSubmission SelectedSubmission { get; set; }
        private StudentService studentService;

        public AssignmentSubmissionDetailViewModel(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
            if (SelectedAssignment == null) SelectedAssignment = new Assignment();
            if (SelectedSubmission == null) SelectedSubmission = new AssignmentSubmission();
            if (GradeInput == null) GradeInput = string.Empty;
            studentService = StudentService.Current;
        }

        private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void SubmitGrade()
        {
            if (int.TryParse(GradeInput, out int grade))
            {
                SelectedSubmission.Grade = grade;
                NotifyPropertyChanged(nameof(SelectedSubmission));

                var student = SelectedCourse.Roster.Find(s => s.Id == SelectedSubmission.StudentId);
                if (student != null)
                {
                    studentService.submitGrade(SelectedAssignment.Name, grade, student.Id);
                    NotifyPropertyChanged(nameof(student));
                }
            }
        }
    }
}

