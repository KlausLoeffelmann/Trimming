namespace TimeTamer.DataLayer.Models;

public static class TaskItemExtensions
{
    public static List<(string, string?)> SampleDemoTasks(this User user, List<Project> projects)
    {
        List<(string, string?)> sampleTasks;

        // Check if sample tasks have been created
        bool tasksExist = CheckIfTasksExist(user);

        if (tasksExist)
        {
            // Update the due dates of existing sample tasks
            UpdateSampleTaskDueDates(user);

            // Retrieve the existing sample tasks
            sampleTasks = GetExistingSampleTasks(user);
        }
        else
        {
            // Create new sample tasks
            sampleTasks = CreateSampleTasks(user, projects);
        }

        return sampleTasks;
    }

    private static bool CheckIfTasksExist(User user)
    {
        using var context = new TimeTamerContext();

        // Check if sample tasks exist for the user
        bool tasksExist = context.TaskItems.Any(t => t.AssignedToUserId == user.UserId);

        return tasksExist;
    }

    private static void UpdateSampleTaskDueDates(User user)
    {
        using var context = new TimeTamerContext();

        // Retrieve the existing sample tasks for the user
        List<TaskItem> sampleTasks = [.. context
            .TaskItems
            .Where(t => t.AssignedToUserId == user.UserId)];

        // Update the due dates of existing sample tasks
        foreach (var task in sampleTasks)
        {
            // Implement the logic to update the due dates of the tasks in the database
            task.DueDate = CalculateNewDueDate(task.DueDate ?? DateTime.Now);

            context.SaveChanges();
        }
    }

    private static List<(string, string?)> GetExistingSampleTasks(User user)
    {
        using var context = new TimeTamerContext();

        // Retrieve the existing sample tasks for the user
        List<TaskItem> sampleTasks = [.. context
                .TaskItems
                .Where(t => t.AssignedToUserId == user.UserId)];

        // Convert the sample tasks to the desired format
        List<(string, string?)> existingSampleTasks = sampleTasks
            .Select(t => (t.Name, t.Description))
            .ToList();

        return existingSampleTasks;
    }

    private static List<(string, string?)> CreateSampleTasks(User user, List<Project> projects)
    {
        List<(string, string?)> sampleTasks = new();

        using (var context = new TimeTamerContext())
        {
            // Create new sample tasks with matching names and descriptions
            for (int i = 0; i < 100; i++)
            {
                string taskName = GenerateFunnyTaskName();
                string taskDescription = GenerateFunnyTaskDescription(taskName);

                TaskItem task = new()
                {
                    Name = taskName,
                    Description = taskDescription,
                    AssignedToUserId = user.UserId,
                    ProjectId = projects[new Random().Next(projects.Count)].ProjectId
                };

                context.TaskItems.Add(task);
                context.SaveChanges();

                sampleTasks.Add((task.Name, task.Description));
            }
        }

        return sampleTasks;
    }

    private static string GenerateFunnyTaskName()
    {
        string[] funnyTaskNames = [
            "Fix the flux capacitor",
            "Teach penguins to fly",
            "Find the lost city of Atlantis",
            "Create a time machine",
            "Invent a teleportation device",
            "Train a squirrel army",
            "Build a robot butler",
            "Discover the meaning of life",
            "Become a superhero",
            "Conquer the world with rubber ducks",
            "Solve the mystery of the Bermuda Triangle",
            "Create a language only you can understand",
            "Find Bigfoot",
            "Become a professional unicorn rider",
            "Design a hat for cats",
            "Create a recipe for invisible cookies",
            "Build a treehouse on Mars",
            "Write a novel using only emojis",
            "Become a professional bubble wrap popper",
            "Invent a self-cleaning house",
            "Create a flying car",
            "Build a time-traveling toaster",
            "Train a dragon",
            "Discover a new planet",
            "Invent a device to read minds",
            "Become a master of disguise",
            "Solve a murder mystery",
            "Create a cure for the common cold",
            "Build a floating city",
            "Design a robot pet"
        ];

        Random random = new();
        int index = random.Next(funnyTaskNames.Length);
        return funnyTaskNames[index];
    }

    private static string GenerateFunnyTaskDescription(string taskName)
    {
        string taskDescription = "";

        if (taskName == "Fix the flux capacitor")
        {
            taskDescription = "The flux capacitor in the time machine is malfunctioning. It needs to be fixed to ensure smooth time travel.";
        }
        else if (taskName == "Teach penguins to fly")
        {
            taskDescription = "Penguins have expressed a strong desire to fly. Develop a training program to teach them how to take flight.";
        }
        else if (taskName == "Find the lost city of Atlantis")
        {
            taskDescription = "Embark on an underwater expedition to discover the mythical lost city of Atlantis and unravel its secrets.";
        }
        else if (taskName == "Create a time machine")
        {
            taskDescription = "Build a functional time machine that can transport individuals to different points in time.";
        }
        else if (taskName == "Invent a teleportation device")
        {
            taskDescription = "Design and construct a teleportation device that can instantly transport objects and people across vast distances.";
        }
        else if (taskName == "Train a squirrel army")
        {
            taskDescription = "Train a group of squirrels to become a highly skilled army capable of executing complex missions.";
        }
        else if (taskName == "Build a robot butler")
        {
            taskDescription = "Construct an advanced robot with the ability to perform household tasks and assist with daily activities.";
        }
        else if (taskName == "Discover the meaning of life")
        {
            taskDescription = "Embark on a philosophical journey to uncover the true meaning and purpose of life.";
        }
        else if (taskName == "Become a superhero")
        {
            taskDescription = "Develop superhuman abilities and use them to protect the innocent and fight against evil.";
        }
        else if (taskName == "Conquer the world with rubber ducks")
        {
            taskDescription = "Devise a plan to take over the world using an army of rubber ducks as your secret weapon.";
        }
        else if (taskName == "Solve the mystery of the Bermuda Triangle")
        {
            taskDescription = "Investigate the Bermuda Triangle phenomenon and solve the mystery behind the disappearances of ships and planes.";
        }
        else if (taskName == "Create a language only you can understand")
        {
            taskDescription = "Invent a unique language that only you can comprehend, allowing for secure communication and secret knowledge.";
        }
        else if (taskName == "Find Bigfoot")
        {
            taskDescription = "Embark on an expedition to locate and document the existence of the legendary creature known as Bigfoot.";
        }
        else if (taskName == "Become a professional unicorn rider")
        {
            taskDescription = "Train to become a skilled unicorn rider and participate in magical races and competitions.";
        }
        else if (taskName == "Design a hat for cats")
        {
            taskDescription = "Create fashionable and comfortable hats specifically designed for cats, taking into account their unique anatomy.";
        }
        else if (taskName == "Create a recipe for invisible cookies")
        {
            taskDescription = "Develop a recipe for cookies that become invisible upon consumption, adding an element of surprise to the dining experience.";
        }
        else if (taskName == "Build a treehouse on Mars")
        {
            taskDescription = "Construct a habitable treehouse on the surface of Mars, providing a unique living space for future explorers.";
        }
        else if (taskName == "Write a novel using only emojis")
        {
            taskDescription = "Challenge yourself to write an entire novel using only emojis, pushing the boundaries of communication.";
        }
        else if (taskName == "Become a professional bubble wrap popper")
        {
            taskDescription = "Master the art of popping bubble wrap and achieve the status of a professional bubble wrap popper.";
        }
        else if (taskName == "Invent a self-cleaning house")
        {
            taskDescription = "Design and build a house equipped with advanced self-cleaning mechanisms, eliminating the need for manual cleaning.";
        }
        else if (taskName == "Create a flying car")
        {
            taskDescription = "Engineer a revolutionary flying car that combines the convenience of road transportation with the freedom of flight.";
        }
        else if (taskName == "Build a time-traveling toaster")
        {
            taskDescription = "Construct a toaster that has the ability to transport toast to different points in time, ensuring perfectly timed breakfasts.";
        }
        else if (taskName == "Train a dragon")
        {
            taskDescription = "Tame and train a mythical dragon, forming a bond of trust and using its abilities for various purposes.";
        }
        else if (taskName == "Discover a new planet")
        {
            taskDescription = "Explore the depths of space and discover a previously unknown planet, expanding our knowledge of the universe.";
        }
        else if (taskName == "Invent a device to read minds")
        {
            taskDescription = "Create a groundbreaking device that can accurately read and interpret the thoughts and emotions of individuals.";
        }
        else if (taskName == "Become a master of disguise")
        {
            taskDescription = "Master the art of disguise, acquiring the skills to transform your appearance and blend seamlessly into any environment.";
        }
        else if (taskName == "Solve a murder mystery")
        {
            taskDescription = "Put your detective skills to the test and solve a complex murder mystery, uncovering the truth behind the crime.";
        }
        else if (taskName == "Create a cure for the common cold")
        {
            taskDescription = "Devise a cure for the common cold, alleviating the symptoms and providing relief to millions of people.";
        }
        else if (taskName == "Build a floating city")
        {
            taskDescription = "Design and construct a fully functional floating city, revolutionizing the concept of urban living.";
        }
        else if (taskName == "Design a robot pet")
        {
            taskDescription = "Create a lifelike robot pet that can provide companionship and emotional support, mimicking the behavior of real animals.";
        }

        return taskDescription;
    }

    private static DateTime CalculateNewDueDate(DateTime dueDate)
    {
        // Calculate the minimum and maximum offset from the current date
        TimeSpan minOffset = TimeSpan.FromDays(1); // Minimum offset of 1 day
        TimeSpan maxOffset = TimeSpan.FromDays(7); // Maximum offset of 7 days

        // Generate a random offset within the specified range
        Random random = new();
        TimeSpan randomOffset = TimeSpan.FromTicks((long)random.NextDouble() * (maxOffset.Ticks - minOffset.Ticks) + minOffset.Ticks);

        // Calculate the new due date by adding the random offset to the original due date
        DateTime newDueDate = dueDate + randomOffset;

        return newDueDate;
    }
}
