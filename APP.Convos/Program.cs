/* 
** Convos
** Written by Benjamin Raidman
** Program to create and manage a Learning Mangement System.
*/

using APP.Convos.Helpers;

namespace LearningApp
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            int option = 0;
            while (option != 3) 
            {
                HomeMenu(); // Display home menu
                option = int.Parse(Console.ReadLine() ?? "0"); // Input option

                // Manage Courses
                if (option == 1)
                {
                    courseHelper.CourseManagement();
                }
                // Manage Students
                else if (option == 2)
                {
                    studentHelper.StudentManagement();
                }
                // Exit
                else if (option == 3) { Console.WriteLine("Exiting..."); }

                // Invalid input
                else { Console.WriteLine("Invalid Input Please Try Again! [1, 2, or 3]"); }
            }
        }

        private static void HomeMenu() // displays home menu
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("            <Learning Management System>");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Options:\n");
            Console.WriteLine("1. Manage Courses");
            Console.WriteLine("2. Manage Students");
            Console.WriteLine("3. Exit");

            Console.Write("\nEnter option: ");
        }
    }
}