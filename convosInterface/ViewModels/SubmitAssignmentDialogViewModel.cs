using System;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels
{
    public class SubmitAssignmentDialogViewModel
    {
        public String Title { get; set; }
        public String Answer { get; set; }
        public Assignment SelectedAssignment { get; set; }
        public int StudentId { get; set; }

        public SubmitAssignmentDialogViewModel(Assignment selectedAssignment, int studentId)
        {
            SelectedAssignment = selectedAssignment;
            StudentId = studentId;
            if (Title == null) Title = string.Empty;
            if (Answer == null) Answer = string.Empty;
        }

        public void SubmitAssignment()
        {
            AssignmentSubmission assignmentSubmission = new AssignmentSubmission();
            assignmentSubmission.StudentID = StudentId;
            assignmentSubmission.Title = Title;
            assignmentSubmission.Answer = Answer;
            assignmentSubmission.StudentName = (StudentService.Current.FindPerson(StudentId)).Name;

            CourseService.Current.SubmitAssignment(SelectedAssignment, assignmentSubmission);
        }
    }
}