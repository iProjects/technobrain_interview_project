/*
* Created by SharpDevelop.
* User: USER
* Date: 04/28/2019
* Time: 08:59 AM
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers.
*/
using System;
using System.IO;
using technobrain_interview_project;

namespace mainproj
{
    class Program
    {
        public static void Main(string[] args)
        {

            try
            { 
                /* process the file here */                  
                string file = File.ReadAllText("employees.csv");

                Console.WriteLine(file);

                Employees _emp = new Employees(file);
                _emp.salary_budget_given_manager("Employee1");

            }
            catch (Exception ex)
            {
                /* handle the exception */
                Console.WriteLine(ex.ToString());
                Console.ReadKey(true);
            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey(true);
            Console.WriteLine("exiting...");

            // TODO: Implement Functionality Here
             

        }
    }
}