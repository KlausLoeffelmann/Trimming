namespace TaskTamer.DataLayer.Models;

public partial class User
{
    public static void EnsureSampleUsersData()
    {
        using var context = new TaskTamerContext();

        // Consolidate user checking and creation into one method
        EnsureUserExists(context, "klaus@tasktamer.demo", "Klaus", "Loeffelmann");
        EnsureUserExists(context, "merrie@tasktamer.demo", "Merrie", "McGaw");
    }

    private static void EnsureUserExists(TaskTamerContext context, string email, string firstName, string lastName)
    {
        var user = context.Users?.FirstOrDefault(u => u.Email == email);

        if (user is null)
        {
            user = new User
            {
                Username = $"{firstName}".ToLowerInvariant(),
                PasswordHash = " ",
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateCreated = DateTimeOffset.Now,
                DateLastModified = DateTimeOffset.Now,
                SyncId = Guid.NewGuid(),
                // Set other fields as needed
            };

            context.Users!.Add(user);
            context.SaveChanges();
        }
    }
}
