using HW_4._3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HW_4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            using (var context = new DatabaseContext()) 
            {
                var employee = new Employee()
                {
                    FirstName = "Evgen",
                    LastName = "Popov",
                    HiredDate = DateTime.Parse("10.09.2018"),
                    TitleId = 3,
                    OfficeId = 1
                };
                context.Add(employee);
                var title = new Title() { Name = "Manager" };
                context.Add(title);
                var office = new Office() { Ttitle = " ", Location = "New York" };
                context.Add(office);
                context.SaveChanges();
                var query =
                from t1 in context.Offices
                join t2 in context.Projects on t1.OfficeId equals t2.ProjectId into t2Join
                from t2Result in t2Join.DefaultIfEmpty()
                join t3 in context.Employees on t1.OfficeId equals t3.EmployeeId into t3Join
                from t3Result in t3Join.DefaultIfEmpty()
                select new { t1, t2Result, t3Result };

                var query2 =
                from employees in context.Employees
                where (DateTime.Now - employee.HiredDate).Days > 30
                select employees;

                var query3 = context.Database.BeginTransaction();
                try
                {
                    var Employee = context.Employees.Single(i => i.EmployeeId == 7);
                    Employee.FirstName = "Andrij";
                    Employee.LastName = "Luzan";
                    var Employee1 = context.Employees.Single(i => i.EmployeeId == 8);
                    Employee1.FirstName = "Mykola";
                    Employee1.LastName = "Zoryanov";
                }
                catch (Exception)
                {
                    query3.Rollback();
                }

                var query4 = new Employee
                {
                    FirstName = "Viktor",
                    LastName = "Chehov",
                    HiredDate = DateTime.Parse("10.09.2020"),
                    TitleId = 3,
                    OfficeId = 1
                };

                context.Employees.Add(query4);
                context.SaveChanges();

                var query5 = context.Employees.FirstOrDefault(e => e.EmployeeId == 1);

                if (query5 != null)
                {
                    context.Employees.Remove(query5);
                    context.SaveChanges();
                }

                var query6 =
                from employees in context.Employees
                group employees by employee.Title.Name into g
                where !g.Key.Contains("a")
                select new { Role = g.Key };
            }
        }
    }
}