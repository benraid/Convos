using Library.Convos.Models;

namespace Library.Convos.Services
{
    public class CourseService
    {
        private List<Course> systemCourses;
        private static CourseService? _instance;

        private CourseService() //singleton pattern
        {
            systemCourses = new List<Course>();
        }

        public static CourseService Current // singleton pattern: get the current instance
        {
            get
            {
                if (_instance == null) // If instance is null we simply set it up (this is how instances will be created)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        public void AddCourse(Course course)
        {
            systemCourses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            systemCourses.Remove(course);
        }

        public void AddEnrollment(Person student, Course course)
        {
            course.Roster.Add(student);
        }

        public void RemoveEnrollment(Person student, Course course)
        {
            course.Roster.Remove(student);
        }

        public void AddAssignment(string code, Assignment assignment)
        {
            foreach (Course course in Courses)
            {
                if (code == course.Code)
                {
                    course.Assignments.Add(assignment);
                }

            }
        }

        public void SubmitAssignment(Assignment selectedAssignment, AssignmentSubmission assignmentSubmission)
        {
            selectedAssignment.SubmittedAssignments.Add(assignmentSubmission);
        }

        public void AddModule(string code, Module module)
        {
            foreach (Course course in Courses)
            {
                if (code == course.Code)
                {
                    course.Modules.Add(module);
                }

            }
        }

        public List<Course> FindCourses(int studentId)
        {
            List<Course> studentCourses = new List<Course>();
            foreach (Course i in CourseService.Current.Courses)
            {
                foreach (Person j in i.Roster)
                {
                    if (studentId == j.Id)
                    {
                        studentCourses.Add(i);
                    }
                }
            }
            return studentCourses;
        }

        //public List<Module> FindModules()
        //{

        //}

        public List<Course> Courses
        {
            get { return systemCourses; } // no set so we don't allow modifications to SystemCourses
        }

        public IEnumerable<Course> SearchCoursesName(string query) // IEnumerable to prevent a deep copy (you can choose in application of what copy you want)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public IEnumerable<Course> SearchCoursesDescription(string query) // IEnumerable to prevent a deep copy (you can choose in application of what copy you want)
        {
            return Courses.Where(s => s.Description.ToUpper().Contains(query.ToUpper()));
        }
    }
}