namespace TaskTamer.DataLayer.Models;

public partial class Project
{
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private static readonly Random s_random = new();
    private static readonly string[] s_statuses =
    [
        "Not Started",
        "In Progress",
        "On Hold",
        "Completed"
    ];

    /// <summary>
    /// Generates sample Project data.
    /// </summary>
    /// <param name="context">The TimeTamerContext instance.</param>
    /// <remarks>
    /// This method generates sample Project data including the Projects "WinForms Classic Designer", "WinForms OOP-Designer", "WinForms Runtime", "WinForms Async", "WinForms DarkMode", "Copilot conceptional work", "Prototyping", "CommToolkit work".
    /// </remarks>
    public static void EnsureSampleProjectsData(TaskTamerContext context, User user)
    {
        // Do we have Project sample data?
        if (context.Projects.Any())
        {
            return;
        }

        // Get the first Category as the default:
        var categories = context.Categories.ToArray();

        var projects = new List<Project>
        {
            CreateProject("Operation Time Twist", "Time flies when you're having fun, but can you make it do loop-de-loops?", user, RandomCategory(categories)),
            CreateProject("Flight School for Flightless", "Because even penguins deserve a chance at the skies!", user, RandomCategory(categories)),
            CreateProject("Deep Sea Discovery", "Where the only pressure is the literal kind, under thousands of pounds of water.", user, RandomCategory(categories)),
            CreateProject("Inventor's Imaginarium", "If you can imagine it, we'll pretend to build it.", user, RandomCategory(categories)),
            CreateProject("Squirrel Squad Strategies", "Strategizing the best ways to steal your next picnic lunch!", user, RandomCategory(categories)),
            CreateProject("Robotic Rendezvous", "Helping robots find true love, one circuit at a time.", user, RandomCategory(categories)),
            CreateProject("Philosophical Phantoms", "For ghosts who question their own existence.", user, RandomCategory(categories)),
            CreateProject("Superhero Academy", "Building better heroes, because not everyone can be born with superpowers.", user, RandomCategory(categories)),
            CreateProject("Duck Domination Derby", "Quacking the competition, one race at a time.", user, RandomCategory(categories)),
            CreateProject("Triangular Mystique", "Discover the secrets hidden within three sides.", user, RandomCategory(categories)),
            CreateProject("Linguistic Labyrinths", "Get lost in translation in our world of words.", user, RandomCategory(categories)),
            CreateProject("Bigfoot Brigade", "Tracking mythical creatures or just having a massive footprint contest.", user, RandomCategory(categories)),
            CreateProject("Unicorn Equestrian", "Ride into the fantasy sunset on the back of a legend.", user, RandomCategory(categories)),
            CreateProject("Catty Couture", "For felines who won't settle for less than fabulous.", user, RandomCategory(categories)),
            CreateProject("Invisibility Bake-off", "May the best invisible chef win.", user, RandomCategory(categories)),
            CreateProject("Martian Abode Architects", "Designing red planet real estate for Earth's next frontier.", user, RandomCategory(categories)),
            CreateProject("Emoji Epic", "Crafting sagas in smileys and symbols.", user, RandomCategory(categories)),
            CreateProject("Bubble Wrap Bonanza", "Popping our way into your heart with every burst.", user, RandomCategory(categories)),
            CreateProject("Home Cleaning Revolution", "Overthrow the regime of dirt and grime in your living spaces.", user, RandomCategory(categories)),
            CreateProject("Aeronautic Autos", "Because why drive when you can fly?", user, RandomCategory(categories)),
            CreateProject("Temporal Toast Tech", "Making sure your bread is toasted in the past, present, and future.", user, RandomCategory(categories)),
            CreateProject("Dragon Taming Tactics", "Because sometimes 'here, kitty kitty' just doesn't work on a dragon.", user, RandomCategory(categories)),
            CreateProject("Stellar Space Scouts", "Exploring the cosmos and earning badges along the way.", user, RandomCategory(categories))
        };

        context.Projects.AddRange(projects);

        context.SaveChanges();

        static Category RandomCategory(Category[] categories)
            => categories[s_random.Next(categories.Length)];
    }

    private static Project CreateProject(string name, string description, User owner, Category category)
    {
        var now = DateTimeOffset.Now;
        var startDate = now.AddDays(-s_random.Next(1, 15)).AddHours(s_random.Next(24));
        var endDate = now.AddDays(s_random.Next(15, 30)).AddHours(s_random.Next(24));

        return new Project
        {
            ProjectId = Guid.NewGuid(),
            Name = name,
            Description = description,
            Category = category,
            StartDate = startDate,
            EndDate = endDate,
            Owner = owner,
            Status = GenerateRandomProjectStatus(),
            ExternalReference = GenerateExternalReference(),
            DateCreated = now,
            DateLastModified = now,
            SyncId = Guid.NewGuid()
        };
    }

    private static string GenerateRandomProjectStatus() 
        => s_statuses[s_random.Next(s_statuses.Length)];

    private static string GenerateExternalReference() 
        => new(Enumerable
            .Repeat(Chars, 6)
            .Select(s => s[s_random.Next(s.Length)])
            .ToArray());
}
