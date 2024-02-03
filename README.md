## Move Balls

It seems likely that when you call `e.Graphics.Clear(myPictureBox.BackColor)` that you're deleting everything except for the current ball. Think of it as when you call `pictureBox.Refresh` it's giving you a blank canvas to draw on every time and do everything you need to do in the handler for the `Paint` event.

This shows the starting positions and the position after 5 clicks.

[![on load][1]][1]

```csharp
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
```
  
#### Ball

In OOP, the paradigm is often to give the `Ball` the intelligence to move itself:

```csharp
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
```


  [1]: https://i.stack.imgur.com/B6pf0.png