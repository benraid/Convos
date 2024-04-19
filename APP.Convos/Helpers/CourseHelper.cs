using Library.Convos.Models;
using Library.Convos.Services;

namespace APP.Convos.Helpers
{
    internal class CourseHelper
    {
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            studentService = StudentService.Current; // call singleton to setup dependency
            courseService = CourseService.Current;
        }

        /* course management system: manage courses and things they contain
        In CourseManagement and StudentManagement I mainly just display info and take input. I use helper functions to perform
        most of the heavy lifting. I did this to make it more readable and so I could be able to make edits more easily
        in the future. */
        public void CourseManagement()
        {
            
            int courseOption = 0;
            while (courseOption != 10)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("             <Course Management System>");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Options:\n");
                Console.WriteLine("1. Create a Course");
                Console.WriteLine("2. List Courses");
                Console.WriteLine("3. Search for a Course"); 
                Console.WriteLine("4. Update a Course's Information");
                Console.WriteLine("5. Create an Assignment for a Course"); 
                Console.WriteLine("6. Display Assignments for a Course");
                Console.WriteLine("7. Display All Info for a Course");
                Console.WriteLine("8. Add Student to Course");
                Console.WriteLine("9. Remove Student from Course");
                Console.WriteLine("10. Exit");

                Console.Write("\nEnter option: ");
                courseOption = int.Parse(Console.ReadLine() ?? "0");

                if (courseOption == 1) 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                   <Create New Course>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    CreateCourse();
                }
                else if (courseOption == 2)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                   <Course List>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    ListCourses();
                }
                else if (courseOption == 3)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                  <Course Search>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    CourseSearch();
                }
                else if (courseOption == 4)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                   <Update Course>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    UpdateCourse();
                }
                else if (courseOption == 5)
                {   
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                  <Create Assignment>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    CreateAssignment();
                }
                else if (courseOption == 6)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("            <Display Course Assignments>");
                    Console.WriteLine("-----------------------------------------------------");

                    Console.Write("Enter course code: ");
                    var code = Console.ReadLine() ?? string.Empty;

                    DisplayCourseAssignments(code);
                }
                else if (courseOption == 7)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("            <Display All Course Info>");
                    Console.WriteLine("-----------------------------------------------------");

                    DisplayCourseAll();
                }
                else if (courseOption == 8)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("               <Add Student to Course>");
                    Console.WriteLine("-----------------------------------------------------");

                    AddStudentToCourse();
                }
                else if (courseOption == 9)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("              <Remove Student from Course>");
                    Console.WriteLine("-----------------------------------------------------");

                    RemoveStudentFromCourse();
                }
                
                else if (courseOption == 10) {}
                else { Console.WriteLine("Invalid Input Please Try Again!"); }
            }
        }

        /* <Helper Functions> */

        public void CourseSearch() // search for a course 
        {
            var searchOption = 0;
            while (searchOption != 3)
            {
                Console.WriteLine("\nSearching Options: ");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Description");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter option: ");

                searchOption = int.Parse(Console.ReadLine() ?? "0");

                if (searchOption == 1) 
                {
                    Console.Write("Enter name of course you are searching for: ");
                    var query = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("\nCourse Search Results:");
                    Console.WriteLine("[Course Code] Name\n");
                    courseService.SearchCoursesName(query).ToList().ForEach(Console.WriteLine);
                    
                    Console.Write("Enter displayed course code to select a course and display more information.\n");
                    DisplayCourseAll();
                }
                else if (searchOption == 2)
                {
                    Console.Write("Enter description of course you are searching for: ");
                    var query = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("\nCourse Search Results:");
                    Console.WriteLine("[Course Code] Name\n");
                    courseService.SearchCoursesDescription(query).ToList().ForEach(Console.WriteLine);
                    
                    Console.Write("Enter displayed course code to select a course and display more information: ");
                    DisplayCourseAll();
                }
                else 
                {
                    Console.WriteLine("Invalid option. Try again!");
                }
            }
        }

        public void DisplayCourseAll() // Used to display all information about a course
        {
            Console.Write("Enter course code: ");
            var code = Console.ReadLine() ?? string.Empty;
            
            bool check = false;
            foreach (var course in courseService.Courses)
            {
                if (code == course.Code) // passed in code matches a course code so we display its info
                {
                    check = true;
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                [" + course.Code + "] " + course.Name);
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Description: " + course.Description);
                    Console.WriteLine("\nCourse Roster:");
                    DisplayCoursePersons(code);
                    Console.WriteLine();
                    DisplayCourseAssignments(code);
                }
            }
            if (check == false)
                Console.WriteLine("\nCourse Not Found! Please make sure you are using the correct course code. \nInputted code: " + code);
        }

        public void DisplayCoursePersons(string code) // Display a course's persons
        {
            foreach(var course in courseService.Courses)
            {
                if (code == course.Code)
                {
                    foreach(var person in course.Roster)
                    {
                        Console.WriteLine("[" + person.Id + "] " + person.Name + " - " + person.Classification);
                    }
                }
            }
        }

        public void DisplayCourseAssignments(string code) // Display a course's assignments
        {
            bool check = false;
            foreach(Course course in courseService.Courses)
            {
                if (code == course.Code)
                {
                    Console.WriteLine("\nCourse Assignments:\n");
                    foreach(Assignment assignment in course.Assignments)
                    {
                        Console.WriteLine("Name: " + assignment.Name);
                        Console.WriteLine("Description: " + assignment.Description);
                        Console.WriteLine("Total Available Points: " + assignment.TotalAvailablePoints);
                        Console.WriteLine("Due Date: " + assignment.DueDate);
                    }
                    check = true;
                }
            }
            if (check == false)
                Console.WriteLine("\nCourse Not Found! Please make sure you are using the correct course code. \nInputted code: " + code);
        }

        public void ListCourses() // list all courses
        {
            Console.WriteLine("Code - Name\n");
            courseService.Courses.ForEach(Console.WriteLine);
        }

        public void UpdateCourse() // update a course
        {
            ListCourses();
            Console.Write("Enter code of course to update: ");
            var code = Console.ReadLine() ?? string.Empty;
            
            bool checker = false;
            foreach(Course course in courseService.Courses)
            {
                if (code == course.Code)
                {
                    Console.WriteLine("\nIs this your course?:");
                    Console.WriteLine("Course Code: " + course.Code);
                    Console.WriteLine("Course Name: " + course.Name);
                    Console.WriteLine("Course Description: " + course.Description);
                    int tempChoice = 0;
                    while (tempChoice != 1 && tempChoice != 2)
                    {
                        Console.Write("\n1. Yes\n2. No\nEnter Option: ");
                        tempChoice = int.Parse(Console.ReadLine() ?? "0");
                        if (tempChoice == 1)
                        {
                            Console.Write("Enter new course code (Enter 0 for no changes): ");
                            var newCode = Console.ReadLine() ?? string.Empty;
                            bool check = true;
                            
                            if (newCode != "0")
                            {
                                foreach (Course checkCourse in courseService.Courses)
                                {
                                    if (newCode == checkCourse.Code)
                                    {
                                        Console.WriteLine("\nCourse code already used!");
                                        check = false;
                                    }
                                }
                            }

                            if (check)
                            {
                                if (newCode != "0")
                                    course.Code = newCode;
                                Console.Write("Enter new course name: ");
                                course.Name = Console.ReadLine() ?? string.Empty;
                                Console.Write("Enter new course description: ");
                                course.Description = Console.ReadLine() ?? string.Empty;  
                                checker = true;  
                            }
                            else
                                Console.WriteLine("Course Update Failed.");
                        }
                        else if (tempChoice == 2) {}
                        else {Console.WriteLine("Invalid Input. Please Try Again!");}
                    }
                }
            }
            if (checker == false)
                Console.WriteLine("\nCourse Not Found! Please make sure you are using the correct course code. \nInputted code: " + code);
        }

        public void CreateAssignment() // create an assignment and assign to course
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter description: ");
            var description = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter total available points for the assignment: ");
            var points = int.Parse(Console.ReadLine() ?? "0");  
            Console.Write("Enter due date: ");
            var date = DateTime.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter the code for the course you would like to add the assignment to: ");
            var code = Console.ReadLine() ?? string.Empty;
            
            Assignment newAssignment = new Assignment();
            newAssignment.Name = name;
            newAssignment.Description = description;
            newAssignment.TotalAvailablePoints = points;
            newAssignment.DueDate = date;

            bool check = false;
            foreach(Course course in courseService.Courses)
            {
                if (code == course.Code)
                {
                    course.Assignments.Add(newAssignment);
                    Console.WriteLine("\nAssignment successfully added!");
                    check = true;
                }
            }
            if (check == false)
                Console.WriteLine("\nCourse Not Found! Please make sure you are using the correct course code. \nInputted code: " + code);
        }

        public void CreateCourse() // create a course
        {
            Console.Write("Enter course code: ");
            var code = Console.ReadLine() ?? string.Empty;
            
            bool check = true;
            foreach (Course course in courseService.Courses)
            {
                if (code == course.Code)
                {
                    Console.WriteLine("\nCode already used by existing course!");
                    check = false;
                }
            }            
            
            if (check)
            {
                Console.Write("Enter course name: ");
                var name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter course description: ");
                var description = Console.ReadLine() ?? string.Empty;  
                Course newCourse = new Course();
                newCourse.Code = code;
                newCourse.Name = name;
                newCourse.Description = description;

                if (courseService.Courses != null)
                {
                    courseService.AddCourse(newCourse);
                } else {}
            }
            else 
                Console.WriteLine("Course creation failed."); 
        }

        public void AddStudentToCourse()
        {
            Console.Write("Enter ID of student to be managed: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();
            courseService.Courses.ForEach(Console.WriteLine);
            Console.Write("Enter course code to be added to: ");
            var code = Console.ReadLine() ?? string.Empty;

            bool studentChecker = false;
            foreach (Person person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    bool courseChecker = false;
                    foreach (Course course in courseService.Courses)
                    {
                        if (code == course.Code)
                        {
                            course.Roster.Add(person);
                            Console.WriteLine("\n" + person.Name + " successfully added to " + course.Name + "!");
                            courseChecker = true;
                        }
                    }

                    if (courseChecker == false)
                        Console.WriteLine("Course not found please try again! Check course code: " + code);

                    studentChecker = true;
                }
            }
            if (studentChecker == false)
                Console.WriteLine("Student not found please try again! Check student ID: " + Id);
        }

        public void RemoveStudentFromCourse() // remove student from a course
        {
            Console.Write("Enter ID of student to be managed: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter course code to be removed from: ");
            var code = Console.ReadLine() ?? string.Empty;

            bool studentChecker = false;
            foreach (Person person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    bool courseChecker = false;
                    foreach (Course course in courseService.Courses)
                    {
                        if (code == course.Code)
                        {
                            course.Roster.Remove(person);
                            Console.WriteLine("\n" + person.Name + " successfully removed from " + course.Name + "!");
                            courseChecker = true;
                        }
                    }

                    if (courseChecker == false)
                        Console.WriteLine("Course not found please try again! Check course code: " + code);

                    studentChecker = true;
                }
            }
            if (studentChecker == false)
                Console.WriteLine("Student not found please try again! Check student ID: " + Id);
        }
    }
}