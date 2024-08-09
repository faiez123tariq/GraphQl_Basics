using GraphQl.Data;
using GraphQl.Models;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Mutation
{
    // Create a new task
    public async Task<Activity> CreateTask([Service] ApplicationDbContext context, TaskInput input)
    {
        try
        {
            var task = new Activity
            {
                Title = input.Title,
                Description = input.Description,
                Status = input.Status,
                ProjectId = input.ProjectId
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();
            return task;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while creating the task: " + ex.Message);
        }
    }

    // Update an existing user
    public async Task<User> UpdateUser([Service] ApplicationDbContext context, UserInput input)
    {
        try
        {
            var user = await context.Users.FindAsync(input.Id);

            if (user == null)
            {
                throw new GraphQLException("User not found");
            }

            user.Name = input.Name;
            user.Email = input.Email;

            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while updating the user: " + ex.Message);
        }
    }

    // Create a new user
    public async Task<User> CreateUser([Service] ApplicationDbContext context, UserInput input)
    {
        try
        {
            var user = new User
            {
                Name = input.Name,
                Email = input.Email
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while creating the user: " + ex.Message);
        }
    }

    // Delete an existing user
    public async Task<User> DeleteUser([Service] ApplicationDbContext context, int id)
    {
        try
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                throw new GraphQLException("User not found");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while deleting the user: " + ex.Message);
        }
    }

    // Create a new project
    public async Task<Project> CreateProject([Service] ApplicationDbContext context, ProjectInput input)
    {
        try
        {
            var project = new Project
            {
                Name = input.Name
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();
            return project;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while creating the project: " + ex.Message);
        }
    }

    // Update an existing project
    public async Task<Project> UpdateProject([Service] ApplicationDbContext context, ProjectInput input)
    {
        try
        {
            var project = await context.Projects.FindAsync(input.Id);

            if (project == null)
            {
                throw new GraphQLException("Project not found");
            }

            project.Name = input.Name;

            context.Projects.Update(project);
            await context.SaveChangesAsync();
            return project;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while updating the project: " + ex.Message);
        }
    }

    // Delete an existing project
    public async Task<Project> DeleteProject([Service] ApplicationDbContext context, int id)
    {
        try
        {
            var project = await context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new GraphQLException("Project not found");
            }

            context.Projects.Remove(project);
            await context.SaveChangesAsync();
            return project;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new GraphQLException("An error occurred while deleting the project: " + ex.Message);
        }
    }
}

public class TaskInput
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int ProjectId { get; set; }
}

public class UserInput
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class ProjectInput
{
    public int Id { get; set; }
    public string Name { get; set; }
}
