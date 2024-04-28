using Library.Convos.Models;

namespace Library.Convos.Services
{
    public class StudentService
    {
        // private List<Person> systemPersons = new List<Person>(); // We replace this with singleton pattern (replace default constructor)
        private List<Person> systemPersons;

        // Private backing field. Static so you can always access GetInstance through the class type
        private static StudentService? _instance;

        /* Set to always private to prevent other classes from manipulating the
         * StudentService (make it less mutable and restrict access). */
        private StudentService() //singleton pattern
        {
            //systemPersons = new List<Person>();

            systemPersons = new List<Person>();
        }

        public static StudentService Current // singleton pattern: get the current instance
        {
            get
            {
                if (_instance == null) // If instance is null we simply set it up (this is how instances will be created)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }

        public void AddStudent(Person student)
        {
            systemPersons.Add(student);
        }

        public void RemoveStudent(Person student)
        {
            systemPersons.Remove(student);
        }

        public Person FindPerson(int Id)
        {
            foreach (var i in systemPersons)
            {
                if (Id == i.Id)
                    return i;
            }
            return null;
        }

        public List<Person> FindPeople(int Id)
        {
            List<Person> findStudents = new List<Person>();
            foreach (var i in systemPersons)
            {
                if (Id == i.Id)
                    findStudents.Add(i);
            }
            return findStudents;
        }

        public List<Person> Students
        {
            get { return systemPersons; } // no set so we don't allow modifications to System Persons
        }

        public IEnumerable<Person> SearchStudents(string query) // IEnumerable to prevent a deep copy (you can choose in application of what copy you want)
        {
            return Students.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void submitGrade(string? name, int grade, int id)
        {
            var student = FindPerson(id);
            if (student != null)
            {
                if (name == null) name = string.Empty;
                student.Grades.Add(name, grade);
            }
        }
    }
}