using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext context= new SoftUniContext();
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        }

        //03.Employees full imformation
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //04.Employees with salary over 50000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} - {e.Salary:F2}"));
        }

        //05.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}"));
        }

        //06.Adding a new address and updating employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };

            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e=> new {e.AddressId, e.Address.AddressText})
                .OrderByDescending(e=> e.AddressId)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, employees.Select(e => e.AddressText));
        }

        //08.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, addresses.Select(e => $"{e.AddressText}, {e.TownName} - {e.EmployeeCount} employees"));
        }

        //09.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        { 

            var employeeInformation = context.Employees
                .Where(e=> e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                    }).OrderBy(p=> p.ProjectName).ToArray()
                }).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employeeInformation.FirstName} {employeeInformation.LastName} - {employeeInformation.JobTitle}");
            sb.Append(string.Join(Environment.NewLine, employeeInformation.Projects.Select(p => p.ProjectName)));

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var department = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                     ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    }).ToArray()
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var d in department)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFullName}");
                sb.Append(string.Join(Environment.NewLine, d.Employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}")));
            }

            return sb.ToString().TrimEnd();
        }
    }
}