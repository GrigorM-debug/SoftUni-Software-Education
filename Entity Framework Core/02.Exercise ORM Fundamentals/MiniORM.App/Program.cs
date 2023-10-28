using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

SoftUniDbContextClass context = new SoftUniDbContextClass(connectionString);

context.Employees.Add(new Employee
{
    FirstName = "Gosho",
    LastName = "Inserted",
    DepartmentId = context.Departments.First().Id,
    IsEmployed= true,
});

Employee employee = context.Employees.Last();
employee.FirstName = "Modified";

context.SaveChanges();