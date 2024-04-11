using TimeTamer.DataLayer.Models;

namespace TimeTamer.ViewModels;

public partial class TimeTamerMainViewModel
{
    private void UpdateCurrentTime(object? state)
    {
        _syncContext.Invoke()?.Post(_ =>
        {
            CurrentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture();
        }, null);
    }

    private static User GetOrCreateDefaultUser()
    {
        var context = new TimeTamerContext();

        // Let's check, if we have a user "klauslo" in the database:
        var user = context.Users.FirstOrDefault(u => u.Username == "klauslo");

        if (user is not null)
        {             
            return user;
        }

        user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "klauslo",
            FirstName = "Klaus",
            LastName = "Loeffelmann",
            Email = "klaus@loeffelmann.de"
        };

        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }
}
