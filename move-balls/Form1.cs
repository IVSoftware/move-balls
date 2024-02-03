
namespace move_balls
{
    public partial class Form1 : Form
    {
        public Form1()
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
                pictureBox.Invalidate();
            };
        }
        List<Ball> balls = new List<Ball>
        {
            new Ball{Color = Color.Blue, X = 100, Y = 50, Height = 50, Width = 50 },
            new Ball{Color = Color.Green, X = 200, Y = 150, Height = 100, Width = 100 },
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
        }
    }
}
