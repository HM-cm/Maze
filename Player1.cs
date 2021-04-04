using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace JobApplicationProj3
{
    class Player1:BasePlayer
    {
        public Player1(Canvas myCanvas) : base(myCanvas)
        {
            for(int i=0; i<3;i++)
            {
                this.arrUp[i] = new BitmapImage(new Uri("ms-appx:///Assets/C1/CUp/CUp" + (i + 1) + ".png"));
                this.arrDown[i] = new BitmapImage(new Uri("ms-appx:///Assets/C1/CDown/CDown" + (i + 1) + ".png"));
                this.arrLeft[i] = new BitmapImage(new Uri("ms-appx:///Assets/C1/CLeft/CLeft" + (i + 1) + ".png"));
                this.arrRight[i] = new BitmapImage(new Uri("ms-appx:///Assets/C1/CRight/CRight" + (i + 1) + ".png"));
            }
            this.image.Source = arrLeft[0];
            this.animationCount++;
        }
        public override void AnimationTimer_Tick(object sender, object e)
        {
            if(this.animationCount>2)
            {
                this.animationCount = 0;
            }
            switch(this.direction)
            {
                case Direction.Left:
                    this.image.Source = this.arrLeft[animationCount];
                    break;
                case Direction.Right:
                    this.image.Source = this.arrRight[animationCount];
                    break;
                case Direction.Up:
                    this.image.Source = this.arrUp[animationCount];
                    break;
                case Direction.Down:
                    this.image.Source = this.arrDown[animationCount];
                    break;
            }
            this.animationCount++;
        }
        public override void MoveTimer_Tick(object sender, object e)
        {
            if(this.animationTimer.IsEnabled==false)
            {
                this.animationTimer.Start();
            }
            switch(this.direction)
            {
                case Direction.Left:
                    this.point.X -= this.dx;
                    break;
                case Direction.Right:
                    this.point.X += this.dx;
                    break;
                case Direction.Up:
                    this.point.Y -= this.dy;
                    break;
                case Direction.Down:
                    this.point.Y += this.dy;
                    break;
            }
            if((this.point.X<=0&&this.direction==Direction.Left)||(this.point.X>=480&&this.direction==Direction.Right))
            {
                this.dx = 0;
                this.animationTimer.Stop();
            }
            else
            {
                this.dx = 5;
            }
            if((this.point.Y<=-10&&this.direction==Direction.Up)||(this.point.Y>=500&&this.direction==Direction.Down))
            {
                this.dy = 0;
                this.animationTimer.Stop();
            }
            else
            {
                this.dy = 5;
            }
            Canvas.SetLeft(this.image, this.point.X);
            Canvas.SetTop(this.image, this.point.Y);
        }
    }
}
