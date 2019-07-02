using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using technobrain_interview_project;

namespace technobrain_interview_project_UnitTestProject
{
    [TestClass]
    public class Unit_Test_Employees
    {
        string _data = "Employee4,Employee2,500\n" +
                        "Employee3,Employee1,800\n" +
                        "Employee1,,1000\n" +
                        "Employee5,Employee1,500\n" +
                        "Employee2,Employee1,500";

        //validate_salaries
        [TestMethod]
        public void Testvalidate_salaries()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(false, _emp.validate_salaries());
        }

        //validate_one_ceo
        [TestMethod]
        public void Testvalidate_one_ceo()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(false, _emp.validate_one_ceo());
        }

        //validate_an_employee_doesnot_report_to_more_than_one_manager
        [TestMethod]
        public void Testvalidate_an_employee_doesnot_report_to_more_than_one_manager()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(true, _emp.validate_an_employee_doesnot_report_to_more_than_one_manager());
        }

        //validate_manager_is_an_employee
        [TestMethod]
        public void Testvalidate_manager_is_an_employee()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(true, _emp.validate_manager_is_an_employee());
        }

        //validate_circular_reference
        [TestMethod]
        public void Testvalidate_circular_reference()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(true, _emp.validate_circular_reference());
        }

        //salary_budget_given_manager
        [TestMethod]
        public void Testsalary_budget_given_manager()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual(1000, _emp.salary_budget_given_manager("Employee2"));
        }

        //GetEmployeeSalary
        [TestMethod]
        public void Testsalary_GetEmployeeSalary()
        {
            Employees _emp = new Employees(_data);
            Assert.AreEqual("500", _emp.GetEmployeeSalary("Employee2"));
        }
		













    }
}
