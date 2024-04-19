using System;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels
{
    public class AddAssignmentDialogViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Points { get; set; }
        public DateTime Date { get; set; }

        public AddAssignmentDialogViewModel(string courseCode)
        {
            CourseCode = courseCode;
            if (Name == null) Name = string.Empty;
            if (Description == null) Description = string.Empty;
        }

        public string CourseCode { get; set; }

        public void AddAssignment()
        {
            Assignment assignment = new Assignment();
            assignment.Name = Name;
            assignment.Description = Description;
            assignment.TotalAvailablePoints = Points;
            assignment.DueDate = Date;

            CourseService.Current.AddAssignment(CourseCode, assignment);
        }
    }
}