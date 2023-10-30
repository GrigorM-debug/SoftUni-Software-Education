using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
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
            Console.WriteLine(GetEmployeesInPeriod(context));
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

        //07.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            string dateFormat = "M/d/yyyy h:mm:ss tt";

            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManegerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            StartDate = p.Project.StartDate.ToString(dateFormat, CultureInfo.InvariantCulture),
                            EndDate = p.Project.EndDate != null ? p.Project.EndDate.Value.ToString(dateFormat, CultureInfo.InvariantCulture) : "not finished"
                        })
                }).ToArray();

            StringBuilder sb = new();

            foreach(var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManegerName}");

                if (e.Projects.Any())
                {
                    foreach(var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
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

        //10.Departments with more then 5 Employees
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

        //11.Find latest 10 projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                }).ToArray()
                .OrderBy(p=> p.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.ProjectStartDate}");
            }
            return sb.ToString().TrimEnd();
        }

        //12.Increase salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesToUpdateTheirSalary = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToArray();

            foreach(var e in employeesToUpdateTheirSalary)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesInfo = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                }).ToArray()
                .ToArray();

            return string.Join(Environment.NewLine, employeesInfo.Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:F2})"));
        }

        //13.Find Employees by FirstName starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e=>e.FirstName.StartsWith("Sa"))
                .Select(e => new 
                { 
                    e.FirstName,
                    e.LastName, 
                    e.JobTitle,
                    e.Salary
                }).ToArray()
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
        }

        //14.Delete project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProject = context.EmployeesProjects.Where(ep=> ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeeProject);

            var project = context.Projects.Where(ep => ep.ProjectId == 2);
            context.Projects.RemoveRange(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p=> p.Name)
                .ToArray();

            return string.Join(Environment.NewLine, projects);
        }

        //15.Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            string town = "Seattle";
            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name == town).ToArray();

            var employees = context.Employees
                 .Where(e => addressesToRemove
                 .Contains(e.Address))
                .ToArray();

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            int addressesToBeRemoved = addressesToRemove.Count();

            context.Addresses.RemoveRange(addressesToRemove);

            var townsToRemove = context.Towns.Where(t => t.Name == town).FirstOrDefault();
            context.Towns.Remove(townsToRemove);

            context.SaveChanges();

            return $"{addressesToBeRemoved} addresses in {town} were deleted";
        }
    }
}