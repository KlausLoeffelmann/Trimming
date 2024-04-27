namespace CommunityToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class SpinnerControl : Panel
{
    private readonly Bitmap[] _frames = new Bitmap[32];
    private int _currentFrame;
    private readonly System.Threading.Timer _timer;

    public SpinnerControl()
    {
        DoubleBuffered = true;
        InitializeFrames();

        _timer = new(
            callback: new TimerCallback(
                (_ /* state, dont need */) =>
                    {
                        _currentFrame = (_currentFrame + 1) % _frames.Length;
                        Invalidate();
                    }),
            state: null,
            dueTime: 0,
            period: 100);
    }

    private void InitializeFrames()
    {
        for (int i = 0; i < _frames.Length; i++)
        {
            _frames[i] = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(_frames[i]))
            {
                g.TranslateTransform(Width / 2.0f, Height / 2.0f);
                g.RotateTransform(i * (360.0f / _frames.Length));
                g.DrawString("🔄", Font, Brushes.Black, -Width / 4, -Height / 4);
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (_frames[_currentFrame] != null)
        {
            e.Graphics.DrawImage(_frames[_currentFrame], 0, 0);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _timer?.Dispose();
            foreach (var frame in _frames)
                frame?.Dispose();
        }
        base.Dispose(disposing);
    }
}
