using TaskTamer9.WinForms.Properties;

namespace TaskTamer.WinForms;

// Handling Storing and Restoring the Form's Location and Size,
// and taking the Forms Minimized state and reasonable Screen coordinates
// into account, since the Screen setting can - through Laptop docking -
// change between sessions.

partial class FrmTaskTamerMain
{
    protected override void CreateHandle()
    {
        base.CreateHandle();

        //_lblSortOrder.Text = "Semantic Parsing active!";
        //_lblSortOrder.ForeColor = Color.Red;

        // Hook-up the event handlers for the Form's Load event, and do the check there:
        Load += FrmTaskTamerMain_Load;

        void FrmTaskTamerMain_Load(object? sender, EventArgs e)
        {
            Load -= FrmTaskTamerMain_Load;
            var mainWindowLocation = Settings.Default.MainWindowLocation;
            var mainWindowSize = Settings.Default.MainWindowSize;

            SuspendLayout();

            if (AreCoordinatesMeaningful(mainWindowLocation, mainWindowSize))
            {
                Location = mainWindowLocation;
                Size = mainWindowSize;
            }
            else
            {
                CenterFormOnMainScreen();
            }

            ResumeLayout();
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // TODO: Why is this true?
        e.Cancel = false;
        base.OnFormClosing(e);

        if (WindowState == FormWindowState.Normal)
        {
            SaveFormPosition(Location, Size);
        }
        else
        {
            SaveFormPosition(RestoreBounds.Location, RestoreBounds.Size);
        }

        TaskTamer9.WinForms.Properties.Settings.Default.Save();
    }

    private static bool AreCoordinatesMeaningful(Point location, Size size)
    {
        // Logic to determine if the retrieved coordinates are meaningful in the current screen configuration
        // Return true if the coordinates are meaningful, false otherwise.

        if (size.Width <= 20 || size.Height <= 20)
        {
            return false;
        }

        // Let's check one available Screen after the other and see, if we can fit the Bounds meaningfully:
        foreach (var screen in Screen.AllScreens)
        {
            if (location.X >= screen.Bounds.Left && location.X + size.Width <= screen.Bounds.Right &&
                location.Y >= screen.Bounds.Top && location.Y + size.Height <= screen.Bounds.Bottom)
            {
                return true;
            }
        }

        return false;
    }

    private static void SaveFormPosition(Point location, Size size)
    {
        Settings.Default.MainWindowLocation = location;
        Settings.Default.MainWindowSize = size;
    }

    private void CenterFormOnMainScreen()
    {
        // Calculate the position and size of the app window to center it on the main screen

        int screenWidth;
        int screenHeight;

        // Should the Screen be null, we assume 1280 x 720 as a reasonable default:
        if (Screen.PrimaryScreen is null)
        {
            screenWidth = 1280;
            screenHeight = 720;
        }
        else
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
        }

        int appWidth = Math.Min(screenWidth * 2 / 3, 1920); // Limit the app width to HD resolution on bigger screens
        int appHeight = Math.Min(screenHeight * 2 / 3, 1080); // Limit the app height to HD resolution on bigger screens
        int appX = (screenWidth - appWidth) / 2;
        int appY = (screenHeight - appHeight) / 2;

        // Set the app window position and size
        this.Location = new Point(appX, appY);
        this.Size = new Size(appWidth, appHeight);
    }
}
