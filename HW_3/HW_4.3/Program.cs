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
                var Clients = new List<Client>()
                {
                   new Client() { Name = "Viktor", Address = "Leipziger Str. 13", DateOfBirth = DateTime.Parse("12.08.1995"), Phone = "380999999999" },
                   new Client() { Name = "Yulia", Address = "Warschauen Str. 18", DateOfBirth = DateTime.Parse("09.06.1998"), Phone = "380343434344" },
                   new Client() { Name = "Alex", Address = "Berliner Str. 22", DateOfBirth = DateTime.Parse("05.11.1992"), Phone = "380345684344" },
                   new Client() { Name = "Vitalii", Address = "Munchener Str 12", Phone = "380343436394" },
                   new Client() { Name = "Anna", Address = "Milch Weg Str. 14", Phone= "380345554344" }
                };
                context.Clients.AddRange(Clients);
                context.SaveChanges();
                var Projects = new List<Project>()
                {
                    new Project() { Name = "Project 1", Budget = 2500, StertedDate = DateTime.Parse("06.02.2020"), ClientId = Clients[0].ClientId },
                    new Project() { Name = "Project 2", Budget = 3000, StertedDate = DateTime.Parse("05.10.2022"), ClientId = Clients[1].ClientId },
                    new Project() { Name = "Project 3", Budget = 4500, StertedDate = DateTime.Parse("08.10.2019"), ClientId = Clients[2].ClientId },
                    new Project() { Name = "Project 4", Budget = 2000, StertedDate = DateTime.Parse("10.05.2020"), ClientId = Clients[3].ClientId },
                    new Project() { Name = "Project 5", Budget = 3500, StertedDate = DateTime.Parse("09.09.2021"), ClientId = Clients[4].ClientId }
                };
                context.Projects.AddRange(Projects);
                context.SaveChanges();
            }
        }
    }
}