namespace TimeTamer.DataLayer.Models;

public static class ProjectExtensions
{
    /// <summary>
    /// Generates sample Project data.
    /// </summary>
    /// <param name="context">The TimeTamerContext instance.</param>
    /// <remarks>
    /// This method generates sample Project data including the Projects "WinForms Classic Designer", "WinForms OOP-Designer", "WinForms Runtime", "WinForms Async", "WinForms DarkMode", "Copilot conceptional work", "Prototyping", "CommToolkit work".
    /// </remarks>
    public static void GenerateProjects(TimeTamerContext context, User user)
    {
        var projects = new List<Project>
        {
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "WinForms Classic Designer",
                Description = "Classic designer for WinForms applications",
                StartDate = DateTimeOffset.Now.AddDays(-7).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(7).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "In Progress",
                ExternalReference = "ABC123",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "WinForms OOP-Designer",
                Description = "Object-oriented programming designer for WinForms applications",
                StartDate = DateTimeOffset.Now.AddDays(-14).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(14).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "Not Started",
                ExternalReference = "DEF456",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "WinForms Runtime",
                Description = "Runtime for WinForms applications",
                StartDate = DateTimeOffset.Now.AddDays(-21).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(21).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "Completed",
                ExternalReference = "GHI789",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "WinForms Async",
                Description = "Asynchronous programming for WinForms applications",
                StartDate = DateTimeOffset.Now.AddDays(-30).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(30).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "In Progress",
                ExternalReference = "JKL012",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "WinForms DarkMode",
                Description = "Dark mode support for WinForms applications",
                StartDate = DateTimeOffset.Now.AddDays(-30).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(30).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "Not Started",
                ExternalReference = "MNO345",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "Copilot conceptional work",
                Description = "Conceptional work for Copilot project",
                StartDate = DateTimeOffset.Now.AddDays(-7).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(7).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "In Progress",
                ExternalReference = "PQR678",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "Prototyping",
                Description = "Prototyping for new features",
                StartDate = DateTimeOffset.Now.AddDays(-14).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(14).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "Not Started",
                ExternalReference = "STU901",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            },
            new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = "CommToolkit work",
                Description = "Work on the Communication Toolkit",
                StartDate = DateTimeOffset.Now.AddDays(-21).AddHours(new Random().Next(24)),
                EndDate = DateTimeOffset.Now.AddDays(21).AddHours(new Random().Next(24)),
                OwnerId = user.UserId,
                Status = "Completed",
                ExternalReference = "VWX234",
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid()
            }
        };

        foreach (var project in projects)
        {
            var existingProject = context.Projects.FirstOrDefault(p => p.Name == project.Name);
            if (existingProject != null)
            {
                existingProject.DateCreated = DateTimeOffset.Now.AddDays(-1).AddHours(new Random().Next(24));
                existingProject.DateLastModified = DateTimeOffset.Now.AddDays(-1).AddHours(new Random().Next(24));
            }
            else
            {
                context.Projects.Add(project);
            }
        }

        context.SaveChanges();
    }
}
