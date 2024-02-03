
namespace move_balls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (var ball in balls)
                {
                    using (var brush = new SolidBrush(ball.Color))
                    {
                        e.Graphics.FillEllipse(brush, ball.X, ball.Y, ball.Width, ball.Height);
                    }
                }
            };
            buttonMove.Click += (sender, e) =>
            {
                balls[0].Move(10, 5);
                balls[1].Move(-5, -5);
                pictureBox.Refresh();
            };
        }
        List<Ball> balls = new List<Ball>
        {
            new Ball{Color = Color.Blue, X = 50, Y = 50, Height = 50, Width = 50 },
            new Ball{Color = Color.Green, X = 175, Y = 175, Height = 100, Width = 100 },
        };
    }
    class Ball
    {
        public Color Color { get; set; }
        public string? Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Move(int x, int y) 
        {
            X += x;
            Y += y;
        }
    }
}
