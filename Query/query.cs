using GraphQl.Data;
using GraphQl.Models;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;

public class Query
{
    public Activity GetTask([Service] ApplicationDbContext context, int id)
    {
        return context.Tasks.Find(id);
    }

    [UseFiltering]
    public List<Activity> GetTasks([Service] ApplicationDbContext context)
    {
        return context.Tasks.ToList();
    }

    
    public User GetUser([Service] ApplicationDbContext context, int id)
    {
        return context.Users.Find(id);
    }

    [UseFiltering]
    public List<User> GetUsers([Service] ApplicationDbContext context)
    {
        return context.Users.ToList();
    }

    
    public Project GetProject([Service] ApplicationDbContext context, int id)
    {
        return context.Projects.Find(id);
    }

    [UseFiltering]
    public List<Project> GetProjects([Service] ApplicationDbContext context)
    {
        return context.Projects.ToList();
    }

    public IQueryable<User> GetUserss([Service] ApplicationDbContext context, int offset, int limit)
    {
        return context.Users.Skip(offset).Take(limit);
    }

}
