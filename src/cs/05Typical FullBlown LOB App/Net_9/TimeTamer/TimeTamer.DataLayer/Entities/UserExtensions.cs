namespace TimeTamer.DataLayer.Models;

public static class UserExtensions
{
    public static void EnsureSampleUsersExist()
    {
        // Check if Klaus Loeffelmann exists
        var klaus = GetUserByEmail("klaus@tasktamer.demo");

        if (klaus is null)
        {
            // Create Klaus Loeffelmann
            klaus = new User
            {
                FirstName = "Klaus",
                LastName = "Loeffelmann",
                Email = "klaus@tasktamer.demo",
                // Set other fields as needed
            };

            SaveUser(klaus);
        }

        // Check if Merrie McGaw exists
        var merrie = GetUserByEmail("merrie@tasktamer.demo");
        if (merrie is null)
        {
            // Create Merrie McGaw
            merrie = new User
            {
                FirstName = "Merrie",
                LastName = "McGaw",
                Email = "merrie@tasktamer.demo",
                // Set other fields as needed
            };

            SaveUser(merrie);
        }
    }

    private static User? GetUserByEmail(string email)
    {
        using var context = new TimeTamerContext();

        return context.Users?.FirstOrDefault(u => u.Email == email);
    }

    private static void SaveUser(User user)
    {
        using var context = new TimeTamerContext();

        context.Users.Add(user);
        context.SaveChanges();
    }
}
