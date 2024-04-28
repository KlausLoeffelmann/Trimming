using System.Threading.Tasks;
using TaskTamer.DTOs;

namespace TaskTamer.DataLayer.Models;

public partial class TaskItem
{
    public static void EnsureSampleTasksData(TaskTamerContext context, User user)
    {
        (string Name, string Description)[] sampleTasksText = GenerateFunnyTasksTexts();

        var projects = context.Projects.ToArray();
        var categories = context.Categories.ToArray();

        var random = new Random();

        foreach (var taskText in sampleTasksText)
        {
            // Check if sample tasks have been created
            if (context.TaskItems.FirstOrDefault(
                task => task.Name == taskText.Name) is TaskItem task)
            {
                // Implement the logic to update the due dates of the tasks in the database
                task.DueDate = CalculateNewDueDate(task.DueDate ?? DateTimeOffset.Now);
            }
            else
            {
                var now = DateTimeOffset.Now;
                var dueDate = now.AddDays(random.Next(15, 30)).AddHours(random.Next(24));
                var created = now.AddDays(-random.Next(30, 90)).AddHours(random.Next(24));
                var modified = created.AddDays(random.Next(5, 25)).AddHours(random.Next(24));

                // Create new sample tasks
                task = new()
                {
                    Name = taskText.Name,
                    DueDate  = dueDate,
                    DateCreated = created,
                    DateLastModified = modified,
                    Status= (TaskItemStatus) random.Next(1, 6),
                    Description = taskText.Description,
                    Owner = user,
                    Category = categories[random.Next(categories.Length)],
                    Project = projects[random.Next(projects.Length)]
                };

                context.TaskItems.Add(task);
            }
        }

        context.SaveChanges();
    }

    private static (string Name, string Description)[] GenerateFunnyTasksTexts()
    {
        (string Name, string Description)[] tasks = new (string, string)[]
        {
            ("Fix the flux capacitor", "The flux capacitor in the time machine is malfunctioning. It needs to be fixed to ensure smooth time travel."),
            ("Teach penguins to fly", "Penguins have expressed a strong desire to fly. Develop a training program to teach them how to take flight."),
            ("Find the lost city of Atlantis", "Embark on an underwater expedition to discover the mythical lost city of Atlantis and unravel its secrets."),
            ("Create a time machine", "Build a functional time machine that can transport individuals to different points in time."),
            ("Invent a teleportation device", "Design and construct a teleportation device that can instantly transport objects and people across vast distances."),
            ("Train a squirrel army", "Train a group of squirrels to become a highly skilled army capable of executing complex missions."),
            ("Build a robot butler", "Construct an advanced robot with the ability to perform household tasks and assist with daily activities."),
            ("Discover the meaning of life", "Embark on a philosophical journey to uncover the true meaning and purpose of life."),
            ("Become a superhero", "Develop superhuman abilities and use them to protect the innocent and fight against evil."),
            ("Conquer the world with rubber ducks", "Devise a plan to take over the world using an army of rubber ducks as your secret weapon."),
            ("Solve the mystery of the Bermuda Triangle", "Investigate the Bermuda Triangle phenomenon and solve the mystery behind the disappearances of ships and planes."),
            ("Create a language only you can understand", "Invent a unique language that only you can comprehend, allowing for secure communication and secret knowledge."),
            ("Find Bigfoot", "Embark on an expedition to locate and document the existence of the legendary creature known as Bigfoot."),
            ("Become a professional unicorn rider", "Train to become a skilled unicorn rider and participate in magical races and competitions."),
            ("Design a hat for cats", "Create fashionable and comfortable hats specifically designed for cats, taking into account their unique anatomy."),
            ("Create a recipe for invisible cookies", "Develop a recipe for cookies that become invisible upon consumption, adding an element of surprise to the dining experience."),
            ("Build a treehouse on Mars", "Construct a habitable treehouse on the surface of Mars, providing a unique living space for future explorers."),
            ("Write a novel using only emojis", "Challenge yourself to write an entire novel using only emojis, pushing the boundaries of communication."),
            ("Become a professional bubble wrap popper", "Master the art of popping bubble wrap and achieve the status of a professional bubble wrap popper."),
            ("Invent a self-cleaning house", "Design and build a house equipped with advanced self-cleaning mechanisms, eliminating the need for manual cleaning."),
            ("Create a flying car", "Engineer a revolutionary flying car that combines the convenience of road transportation with the freedom of flight."),
            ("Build a time-traveling toaster", "Construct a toaster that has the ability to transport toast to different points in time, ensuring perfectly timed breakfasts."),
            ("Train a dragon", "Tame and train a mythical dragon, forming a bond of trust and using its abilities for various purposes."),
            ("Discover a new planet", "Explore the depths of space and discover a previously unknown planet, expanding our knowledge of the universe."),
            ("Invent a device to read minds", "Create a groundbreaking device that can accurately read and interpret the thoughts and emotions of individuals."),
            ("Become a master of disguise", "Master the art of disguise, acquiring the skills to transform your appearance and blend seamlessly into any environment."),
            ("Solve a murder mystery", "Put your detective skills to the test and solve a complex murder mystery, uncovering the truth behind the crime."),
            ("Create a cure for the common cold", "Devise a cure for the common cold, alleviating the symptoms and providing relief to millions of people."),
            ("Build a floating city", "Design and construct a fully functional floating city, revolutionizing the concept of urban living."),
            ("Design a robot pet", "Create a lifelike robot pet that can provide companionship and emotional support, mimicking the behavior of real animals.")
        };

        string[] categoryNames = new string[]
        {
            "Funny Category 1",
            "Funny Category 2",
            "Funny Category 3",
            "Funny Category 4",
            "Funny Category 5"
        };

        string[] projectNames = new string[]
        {
            "Funny Project 1",
            "Funny Project 2",
            "Funny Project 3",
            "Funny Project 4",
            "Funny Project 5",
            "Funny Project 6",
            "Funny Project 7",
            "Funny Project 8",
            "Funny Project 9",
            "Funny Project 10"
        };

        return tasks;
    }

    private static DateTimeOffset CalculateNewDueDate(DateTimeOffset dueDate)
    {
        // Calculate the minimum and maximum offset from the current date
        TimeSpan minOffset = TimeSpan.FromDays(1); // Minimum offset of 1 day
        TimeSpan maxOffset = TimeSpan.FromDays(7); // Maximum offset of 7 days

        // Generate a random offset within the specified range
        Random random = new();
        TimeSpan randomOffset = TimeSpan
            .FromTicks((long)random.NextDouble() * (maxOffset.Ticks - minOffset.Ticks) + minOffset.Ticks);

        // Calculate the new due date by adding the random offset to the original due date
        DateTimeOffset newDueDate = dueDate + randomOffset;

        return newDueDate;
    }

    public static void CreateNew(
        string newTaskName,
        DateTimeOffset? newTaskDueDate,
        Guid projectId,
        Guid userId)
    {
        var context = new TaskTamerContext();

        // Create new sample tasks
        TaskItem task = new()
        {
            Name = newTaskName,
            DueDate = newTaskDueDate,
            DateCreated = DateTimeOffset.Now,
            DateLastModified = DateTimeOffset.Now,
            Status = TaskItemStatus.NotStarted,
            Owner = context.Users.Find(userId)!,
            Project = context.Projects.Find(projectId)
        };

        context.TaskItems.Add(task);
        context.SaveChanges();
    }
}
