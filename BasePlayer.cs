using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace JobApplicationProj3
{
    abstract class BasePlayer
    {
        protected Canvas canvas;
        public Image image;
        public Point point;
        protected ImageSource[] arrUp;
        protected ImageSource[] arrDown;
        public ImageSource[] arrLeft;
        protected ImageSource[] arrRight;
        public DispatcherTimer animationTimer;
        public DispatcherTimer moveTimer;
        protected int dx;
        protected int dy;
        public int animationCount = 0;
        public Direction direction { get; set; }

        public BasePlayer(Canvas myCanvas)
        {
            this.canvas = myCanvas;
            this.image = new Image();
            this.image.Height = 40;
            this.image.Width = 40;
            this.point = new Point(490,435);
            Canvas.SetLeft(this.image, this.point.X);
            Canvas.SetTop(this.image, this.point.Y);
            this.canvas.Children.Add(this.image);
            this.arrUp = new ImageSource[3];
            this.arrDown = new ImageSource[3];
            this.arrLeft = new ImageSource[3];
            this.arrRight = new ImageSource[3];
            this.animationTimer = new DispatcherTimer();
            this.animationTimer.Interval = TimeSpan.FromTicks(1);
            this.animationTimer.Tick += AnimationTimer_Tick;
            this.moveTimer = new DispatcherTimer();
            this.moveTimer.Interval = TimeSpan.FromTicks(1);
            this.moveTimer.Tick += MoveTimer_Tick;
            this.dx = 3;
            this.dy = 3;
        }

        public virtual void MoveTimer_Tick(object sender, object e)
        {
            
        }

        public virtual void AnimationTimer_Tick(object sender, object e)
        {
            
        }
    }
}
