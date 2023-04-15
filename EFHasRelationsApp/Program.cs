using EFHasRelationsApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

//CreateData();

using(ApplicationContext context = new())
{
    var projects = context.Projects.Include(p => p.Employees).ToList();
    foreach(var project in projects)
    {
        Console.WriteLine($"Project title: {project.Title}");
        //foreach(Employee employee in project.Employees)
        //{
        //    Console.WriteLine($"\tName: {employee.Name}");
        //}
        foreach(var ep in project.EmployeeProjects)
            Console.WriteLine($"\tName: {ep.Employee.Name} Date: {ep.StartDate.ToLongDateString()}");
    }
}

//using (ApplicationContext context = new())
//{
//    // read data
//    foreach(Employee e in context.Employees.Include(e => e.Info).ToList())
//        Console.WriteLine($"{e.Name} {e.Age} {e?.Info?.Login} {e?.Info?.Password}");

//    // edit data
//    Employee? employee = context.Employees.Find(1);
//    if(employee != null)
//    {
//        employee.Info.Password = "password";
//        context.SaveChanges();
//    }

//    foreach (Employee e in context.Employees.Include(e => e.Info).ToList())
//        Console.WriteLine($"{e.Name} {e.Age} {e?.Info?.Login} {e?.Info?.Password}");
//}



void CreateData()
{
    using (ApplicationContext context = new())
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        List<Employee> employees = new List<Employee>()
        {
            new(){ Name = "Bob", Age = 23  },
            new(){ Name = "Joe", Age = 41  },
            new(){ Name = "Sam", Age = 37  },
        };

        List<Project> projects = new List<Project>()
        {
            new(){ Title = "Developers" },
            new(){ Title = "Testers" },
            new(){ Title = "Modeling" },
        };

        context.Employees.AddRange(employees);
        context.Projects.AddRange(projects);


        //employees[0].Projects.Add(projects[0]);
        //employees[0].Projects.Add(projects[2]);

        //employees[1].Projects.Add(projects[0]);
        //employees[1].Projects.Add(projects[1]);

        //employees[2].Projects.Add(projects[1]);
        //employees[2].Projects.Add(projects[2]);

        employees[0].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[0],
                        StartDate = DateTime.Now.AddMonths(-4)
                    });
        employees[0].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[2],
                        //StartDate = DateTime.Now.AddMonths(-4)
                    });

        employees[1].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[0],
                        StartDate = DateTime.Now.AddMonths(-6)
                    });
        employees[1].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[1],
                        StartDate = DateTime.Now.AddMonths(-1)
                    });

        employees[2].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[1],
                        StartDate = DateTime.Now.AddDays(-5)
                    });
        employees[2].EmployeeProjects
                    .Add(new EmployeeProject()
                    {
                        Project = projects[2],
                        StartDate = DateTime.Now.AddDays(-15)
                    });


        //context.Employees.AddRange(employees);
        //context.Projects.AddRange(projects);




        //List<EmployeeInfo> employeeInfos = new List<EmployeeInfo>()
        //{
        //    new(){ Employee =  employees[0], Login = "bobby", Password = "qwerty" },
        //    new(){ Employee =  employees[1], Login = "jotheph", Password = "12345" },
        //    new(){ Employee =  employees[2], Login = "sammy", Password = "55555" },
        //};

        //context.Employees.AddRange(employees);
        //context.EmployeeInfos.AddRange(employeeInfos);

        context.SaveChanges();
    }
}