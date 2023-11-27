using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeesFileRepository : IEmployeesRepository
    {
        private string _path;
        public EmployeesFileRepository(string path) {
            _path = path;

            if (File.Exists(path) == false)
            {
                using (var myFile = File.CreateText(path))
                {
                    myFile.Close();
                }
            }
        
        }
        public void AddEmployee(Employee e)
        {
            List<Employee> list = GetEmployees().ToList();
            
            e.ID = list.Count;



            list.Add(e);

            string[] employees = new string[list.Count];

            int counter = 0;
            foreach (var item in list)
            {
                employees[counter] = item.ID.ToString() + "," + item.Name + ',' + item.DepartmentFK + "," + item.PassportNo + "," + item.Username + "," + item.Password;
                counter++;
            }

            File.WriteAllLines(_path, employees);

        }

        public IQueryable<Employee> GetEmployees()
        { //1,joe,ict,1234566,joeborg,123
            string [] contents = File.ReadAllLines(_path);
            List<Employee> employees = new List<Employee>();
            string contentOfOneEmployee = "";
            foreach(string line in contents)
            {
                string[] employeeDetails = line.Split(',');

                employees.Add(
                    new Employee()
                    {
                        ID = Convert.ToInt32(employeeDetails[0]),
                        Name = employeeDetails[1],
                        DepartmentFK = employeeDetails[2],
                        PassportNo = employeeDetails[3],
                        Username = employeeDetails[4],
                        Password = employeeDetails[5]
                    });
            }

            return employees.AsQueryable();
        }
    }
}
