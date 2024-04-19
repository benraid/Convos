using Library.Convos.Models;
using Library.Convos.Services;

namespace APP.Convos.Helpers 
{
    internal class StudentHelper
    {
        private StudentService studentService;
        private CourseService courseService;

        public StudentHelper() 
        {
            studentService = StudentService.Current; // call singleton to setup dependency
            courseService = CourseService.Current;
        }

        /*Very similar to CourseManagement() but handles Person objects more than Course ones. Manages students.*/
        public void StudentManagement()
        {
            int studentOption = 0;
            while (studentOption != 9)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("            <Student Management System>");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Options:\n");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. List Students");
                Console.WriteLine("3. Search for a Student");
                Console.WriteLine("4. Update a Student's Information");
                Console.WriteLine("5. Display Student's Grades");
                Console.WriteLine("6. Add Grade for Student");
                Console.WriteLine("7. Remove Grade for Student");
                Console.WriteLine("8. List a Student's Courses");
                Console.WriteLine("9. Exit");

                Console.Write("\nEnter option: ");
                studentOption = int.Parse(Console.ReadLine() ?? "0");

                if (studentOption == 1) 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                   <Create Student>");
                    Console.WriteLine("-----------------------------------------------------");

                    CreateStudent();                    
                }
                else if (studentOption == 2)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                 <List Students>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    ListStudents();
                }
                else if (studentOption == 3)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                 <Student Search>");
                    Console.WriteLine("-----------------------------------------------------");

                    PersonSearch();
                }
                else if (studentOption == 4)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("                   <Update Student>");
                    Console.WriteLine("-----------------------------------------------------");
                    
                    UpdateStudent();
                }
                else if (studentOption == 5) 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("              <Display Student Grades>");
                    Console.WriteLine("-----------------------------------------------------");

                    DisplayStudentGrades();
                }
                else if (studentOption == 6) 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("              <Add Student Grade>");
                    Console.WriteLine("-----------------------------------------------------");

                    AddStudentGrade();
                }
                else if (studentOption == 7) 
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("              <Add Student Grade>");
                    Console.WriteLine("-----------------------------------------------------");

                    RemoveStudentGrade();
                }
                else if (studentOption == 8)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("              <List Student's Courses>");
                    Console.WriteLine("-----------------------------------------------------");

                    ListStudentCourses();
                }
                else if (studentOption == 9) {}
                else { Console.WriteLine("\nInvalid Input Please Try Again!"); }
            }
        }
        
        /* <Helper Functions> */

        public void ListStudents()
        {
            Console.WriteLine("[ID] Name - Year\n");   
            studentService.Students.ForEach(Console.WriteLine);
        }
        
        public void PersonSearch () // search for a person in a course
        {
            Console.Write("Enter name of student you would like to search for: ");
            var query = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("\nStudent Search Results:");
            Console.WriteLine("[ID] Name - Year\n");
            studentService.SearchStudents(query).ToList().ForEach(Console.WriteLine);
        }

        public void DisplayStudentGrades() // Display a student's grades
        {
            Console.Write("Enter ID of student: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            
            bool check = false;
            foreach(Person person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    Console.WriteLine("\nGrades:");
                    Console.WriteLine("Assignment - Grade\n");
                    foreach(var grade in person.Grades)
                    {
                        Console.WriteLine(grade.Key + " - " + grade.Value + " points");
                    }
                    check = true;
                }
            }
            if (check == false)
                Console.WriteLine("\nStudent Not Found! Please make sure you are using the correct student ID. \nInputted ID: " + Id);
        }

        public void AddStudentGrade() // add a student's grade
        {
            Console.Write("Enter ID of student: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter name of assignment: ");
            var assignmentName = Console.ReadLine() ?? string.Empty;
            
            bool check = false;
            foreach(Person person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    Console.Write("Enter assignment grade: ");
                    double grade = double.Parse(Console.ReadLine() ?? "0");
                    person.Grades.Add(assignmentName, grade);

                    Console.WriteLine("\nGrade successfully submitted!");

                    check = true;
                }
            }
            if (check == false)
                Console.WriteLine("\nStudent Not Found! Please make sure you are using the correct student ID. \nInputted ID: " + Id);
        }

        public void RemoveStudentGrade() // remove a student's grade
        {
            Console.Write("Enter ID of student: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter name of assignment: ");
            var assignmentName = Console.ReadLine() ?? string.Empty;
            
            bool check = false;
            foreach(var person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    bool gradeCheck = false;
                    foreach (var grade in person.Grades)
                    {
                        if (assignmentName == grade.Key)
                        {
                            person.Grades.Remove(grade.Key);
                            Console.WriteLine("\nGrade successfully removed!");
                            gradeCheck = true;
                        }
                    }
                    if (gradeCheck == false)
                        Console.WriteLine("\nAssignment not found, grade removal failed. Check assignment name: " + assignmentName);

                    check = true;
                }
            }
            if (check == false)
                Console.WriteLine("\nStudent Not Found! Please make sure you are using the correct student ID. \nInputted ID: " + Id);
        }

        public void UpdateStudent() // update a student
        {
            ListStudents();
            Console.Write("Enter ID of student to update: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");
            
            bool studentChecker = false;
            foreach (Person person in studentService.Students)
            {
                if (Id == person.Id)
                {
                    var tempChoice = 0;
                    while (tempChoice != 1 && tempChoice != 2)
                    {
                        Console.WriteLine("Is this the correct student?");
                        Console.WriteLine("Name: " + person.Name);
                        Console.WriteLine("Year: " + person.Classification);
                        Console.WriteLine("1. Yes\n2. No");
                        Console.Write("\nEnter Option: ");
                        tempChoice = int.Parse(Console.ReadLine() ?? "0");
                        if (tempChoice == 1)
                        {
                            studentChecker = true;
                            Console.Write("\nEnter new student ID (Enter 0 for no change): ");
                            var newId = int.Parse(Console.ReadLine() ?? "0");

                            bool check = true;
                            if (newId != 0)
                            {
                                foreach (Person checkPerson in studentService.Students)
                                {
                                    if (newId == checkPerson.Id)
                                    {
                                        check = false;
                                        Console.WriteLine("\nEntered ID is already used by an existing student! Try again.");
                                    }
                                }
                            }

                            if (check)
                            {
                                if (newId != 0)
                                    person.Id = newId;
                                
                                Console.Write("Enter new student name: ");
                                person.Name = Console.ReadLine() ?? string.Empty;

                                var classification = 0;
                                while (classification != 1 && classification != 2 && classification != 3 && classification != 4 )
                                {
                                    Console.WriteLine("Choose new year of student:\n1. Freshman\n2. Sophomore\n3. Junior\n4. Senior");
                                    Console.Write("\nEnter Option: ");
                                    classification = int.Parse(Console.ReadLine() ?? "0");
                                    if (classification == 1)
                                        person.Classification = "Freshman";
                                    else if (classification == 2)
                                        person.Classification = "Sophomore";
                                    else if (classification == 3)
                                        person.Classification = "Junior";
                                    else if (classification == 4) 
                                        person.Classification = "Senior";
                                    else
                                        Console.WriteLine("\nInvalid Input! Please Try Again. [1, 2, 3, or 4]\n");
                                }
                            }
                            else
                                Console.WriteLine("Student update failed.");
                        }
                        else if (tempChoice == 2) {}
                        else { Console.WriteLine("\nInvalid input! Please try again! [1 or 2]\n");}
                    }
                }
            }

            if (studentChecker == false)
                Console.WriteLine("Student not found please try again! Check student ID: " + Id);
        }

        public void CreateStudent() // Creates a student
        {
            Console.Write("Enter student ID: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");

            bool check = true;
            foreach(Person person in studentService.Students)
            {
                if(Id == person.Id)
                {
                    Console.WriteLine("\nStudent ID already being used by existing student! Try a new ID.");
                    check = false;
                }
            }

            if (check)
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine() ?? string.Empty;
                Person newStudent = new Person();
                newStudent.Id = Id;
                newStudent.Name = name;

                int tempChoice = 0;
                while (tempChoice != 1 && tempChoice != 2 && tempChoice != 3 && tempChoice != 4 )
                {
                    Console.WriteLine("Choose your year:\n1. Freshman\n2. Sophomore\n3. Junior\n4. Senior");
                    Console.Write("\nEnter Option: ");
                    tempChoice = int.Parse(Console.ReadLine() ?? "0");
                    if (tempChoice == 1)
                        newStudent.Classification = "Freshman";
                    else if (tempChoice == 2)
                        newStudent.Classification = "Sophomore";
                    else if (tempChoice == 3)
                        newStudent.Classification = "Junior";
                    else if (tempChoice == 4) 
                        newStudent.Classification = "Senior";
                    else
                        Console.WriteLine("Invalid Input! Please Try Again. [1, 2, 3, or 4]");
                }
                studentService.AddStudent(newStudent);
                Console.WriteLine("\nStudent " + newStudent.Name + " created!");
            }
            else
                Console.WriteLine("Create student failed.");
        }

        public void ListStudentCourses() // list a students courses
        {
            Console.Write("Enter ID of student you would like to display the courses of: ");
            var Id = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("\nStudent's Courses: ");
            foreach (Course i in courseService.Courses)
            {
                foreach (Person j in i.Roster)
                {
                    if (Id == j.Id)
                    {
                        Console.WriteLine("[" + i.Code + "] " + i.Name);
                    }
                }
            }
        }
    }
}