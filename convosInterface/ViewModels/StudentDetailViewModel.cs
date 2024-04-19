using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels
{
	public class StudentDetailViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler? PropertyChanged;

        public Course SelectedCourse { get; set; }
        public Module SelectedModule { get; set; }
        public Assignment SelectedAssignment { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _classification;
        public string Classification
        {
            get { return _classification; }
            set
            {
                if (_classification != value)
                {
                    _classification = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public StudentDetailViewModel(int studentId)
		{
            if (SelectedCourse == null) SelectedCourse = new Course();
            if (SelectedModule == null) SelectedModule = new Module();
            if (SelectedAssignment == null) SelectedAssignment = new Assignment();
            _name = string.Empty;
            _classification = string.Empty;
            _courses = new ObservableCollection<Course>();

            if (studentId > 0) GetStudent(studentId);
        }

        private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

		private void GetStudent(int studentId)
		{
			var findStudent = StudentService.Current.FindPerson(studentId);
			if (findStudent != null)
			{
				Name = findStudent.Name;
				Id = findStudent.Id;
				Classification = findStudent.Classification ?? string.Empty;

				var studentCourses = CourseService.Current.FindCourses(findStudent.Id);
				Courses = new ObservableCollection<Course>(studentCourses);
			}
        }
    }
}