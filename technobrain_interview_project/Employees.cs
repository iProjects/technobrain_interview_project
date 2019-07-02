/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 04/28/2019
 * Time: 06:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace technobrain_interview_project
{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public class Employees
    {
        string _company_employees;

        public Employees(string company_employees)
        {

            _company_employees = company_employees;

            bool _is_salary_valid = validate_salaries();
            Console.WriteLine("salary is an integer [ " + _is_salary_valid + " ].");
            bool _is_employee_reporting_to_more_than_one_manager_valid = validate_an_employee_doesnot_report_to_more_than_one_manager();
            Console.WriteLine("Employee reports to one Manager? [ " + _is_employee_reporting_to_more_than_one_manager_valid + " ].");
            bool _is_one_ceo_valid = validate_one_ceo();
            Console.WriteLine("There is one ceo? [ " + _is_one_ceo_valid + " ].");
            bool _is_circular_reference_valid = validate_circular_reference();
            Console.WriteLine("There is no circular reference [ " + _is_circular_reference_valid + " ].");

            bool _is_manager_an_employee_valid = validate_manager_is_an_employee();
            Console.WriteLine("Every manager is an employee? [ " + _is_manager_an_employee_valid + " ].");

        }

        public bool validate_salaries()
        {
            bool is_salary_valid = true;
            string[] _arr = _company_employees.Split('\n');
            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                for (int i = 0; i < employee_array.Length; i++)
                {
                    //first index contains employee
                    var _employee = employee_array[0];
                    //second index contains manager
                    var _emp_manager = employee_array[1];
                    //third index contains salary
                    var _salary = employee_array[2];

                    int _valid_salary = 0;
                    bool _is_valid = int.TryParse(_salary, out _valid_salary);
                    if (!_is_valid)
                    {
                        //var msg = "employee [ " + _employee + " ] does not have a valid salary.";
                        //MessageBox.Show(msg, "invalid salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        is_salary_valid = false;
                        return is_salary_valid;
                    }

                }
            }
            return is_salary_valid;
        }

        public bool validate_one_ceo()
        {
            bool is_one_ceo_valid = true;
            int _ceo_manager = 0;
            string[] _arr = _company_employees.Split('\n');

            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                for (int i = 0; i < employee_array.Length; i++)
                {
                    //first index contains employee
                    var _employee = employee_array[0];
                    //second index contains manager
                    var _emp_manager = employee_array[1];
                    //third index contains salary
                    var _salary = employee_array[2];

                    if (String.IsNullOrEmpty(_emp_manager))
                    {
                        //var msg = "employee [ " + _employee + " ] does not have a valid salary.";
                        //MessageBox.Show(msg, "invalid salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _ceo_manager++;
                    }

                }
            }
            is_one_ceo_valid = _ceo_manager == 1 ? true : false;
            return is_one_ceo_valid;
        }

        public bool validate_an_employee_doesnot_report_to_more_than_one_manager()
        {
            bool is_one_manager_valid = true;

            string[] _arr = _company_employees.Split('\n');

            var _employees = new Dictionary<string, string>();
            var _managers = new Dictionary<string, string>();

            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                for (int i = 0; i < employee_array.Length; i++)
                {
                    //first index contains employee
                    var _employee = employee_array[0];
                    //second index contains manager
                    var _emp_manager = employee_array[1];
                    //third index contains salary
                    var _salary = employee_array[2];

                    if (_employees.ContainsKey(_employee) && _employees[_employee] != _emp_manager)
                    {
                        is_one_manager_valid = false;
                        return is_one_manager_valid;
                    }
                    else if (!_employees.ContainsKey(_employee))
                    {

                        _employees.Add(_employee, _emp_manager);
                    }

                }
            }
            return is_one_manager_valid;

        }

        public bool validate_manager_is_an_employee()
        {
            bool is_manager_an_employee_valid = true;


            return is_manager_an_employee_valid;
        }

        public bool validate_circular_reference()
        {

            string[] _arr = _company_employees.Split('\n');

            bool _is_circular_reference = false;

            var _employees = new Dictionary<string, string>();
            var _managers = new Dictionary<string, string>();

            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                for (int i = 0; i < employee_array.Length; i++)
                {
                    //first index contains employee
                    var _employee = employee_array[0];
                    //second index contains manager
                    var _emp_manager = employee_array[1];
                    //third index contains salary
                    var _salary = employee_array[2];

                    if (!_employees.ContainsKey(_employee))
                    {
                        _employees.Add(_employee, _emp_manager);
                    }

                    if (!_managers.ContainsKey(_emp_manager))
                    {
                        _managers.Add(_emp_manager, _employee);
                    }

                }
            }

            foreach (var employee in _employees)
            {
                foreach (var manager in _managers)
                {
                    if (employee.Value == manager.Key && employee.Key == manager.Value)
                    {
                        _is_circular_reference = true;
                    }

                }

            }

            return _is_circular_reference;
        }

        public long salary_budget_given_manager(string _manager)
        {
            long _salary_budget = 0L;

            string[] _arr = _company_employees.Split('\n');

            var _employees = new Dictionary<string, string>();
            var _managers = new Dictionary<string, string>();

            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                for (int i = 0; i < employee_array.Length; i++)
                {

                    var _employee = employee_array[0];

                    var _emp_manager = employee_array[1];

                    var _salary = employee_array[2];

                    if (!_employees.ContainsKey(_employee))
                    {
                        _employees.Add(_employee, _emp_manager);
                    }

                    if (!_managers.ContainsKey(_emp_manager))
                    {
                        _managers.Add(_emp_manager, _employee);
                    }

                }
            }

            //dic to hold manager with employees reporting to them
            var _manager_employees = new Dictionary<string, List<string>>();

            //list of employees reporting to a certain manager
            foreach (var manager in _managers)
            {
                List<string> _my_emps = new List<string>();

                foreach (var employee in _employees)
                {
                    //if this employees manager is equal to the current manager then this employee reports to him/her.
                    if (employee.Value == manager.Key)
                    {
                        //if manager is not in dictionary add
                        if (!_manager_employees.ContainsKey(manager.Key))
                        {
                            //the dictionary value will be a list of employees reporting to him/her.
                            _my_emps.Add(employee.Key);
                            _manager_employees.Add(manager.Key, _my_emps);
                            //if manager exists in dictionary get the value which is the list of employees reporting to him/her and add the current employee.
                        }
                        else if (_manager_employees.ContainsKey(manager.Key))
                        {
                            List<string> _i_my_emps = _manager_employees[manager.Key];
                            _my_emps.Add(employee.Key);

                            _manager_employees[manager.Key] = _i_my_emps;

                        }

                    }
                }

            }

            foreach (var _man in _manager_employees)
            {
                //get the supplied manager from the dictionary.
                if (_man.Key == _manager)
                {
                    //get the employees reporting to this manager
                    var _emps_under_man = _manager_employees[_man.Key];

                    foreach (var _emp_under_man in _emps_under_man)
                    {

                        for (int a = 0; a < _arr.Length; a++)
                        {
                            var _emp = _arr[a];
                            //split to get each row
                            var employee_array = _emp.Split(',');
                            var _salary = 0L;
                            var _emp_manager = "";
                            var _employee = "";
                            for (int i = 0; i < employee_array.Length; i++)
                            {
                                //first index contains employee
                                _employee = employee_array[0];
                                //second index contains manager
                                _emp_manager = employee_array[1];
                                //third index contains salary
                                _salary = long.Parse(employee_array[2]);
                            }
                            if (_emp_under_man == _employee)
                            {
                                _salary_budget += _salary;
                            }
                        }
                    }
                    var manager_salary = GetEmployeeSalary(_manager);
                    _salary_budget += long.Parse(manager_salary);
                }
            }

            Console.WriteLine("salary budget for manager [ " + _manager + " ] is [ " + _salary_budget + " ].");
            return _salary_budget;
        }

        public string GetEmployeeSalary(string employee)
        {
            string[] _arr = _company_employees.Split('\n');
            string salary = "";
            for (int a = 0; a < _arr.Length; a++)
            {
                var _emp = _arr[a];
                //split to get each row
                var employee_array = _emp.Split(',');

                var _employee = "";
                for (int i = 0; i < employee_array.Length; i++)
                {
                    //first index contains employee
                    _employee = employee_array[0];
                    //second index contains manager
                    var _emp_manager = employee_array[1];
                    //third index contains salary
                    if (_employee == employee)
                    {
                        salary = employee_array[2];
                        return salary;
                    }
                }
            }
            return salary;
        }

    }


}