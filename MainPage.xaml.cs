using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JobApplicationProj3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public enum Direction
    {
        Up,Down,Left,Right
    }
    public sealed partial class MainPage : Page
    {
        private int gameStartedCount = 0;
        private int deathCounter = 3;
        private List<BasePlayer> players;
        private List<Rectangle> blocks;
        private DispatcherTimer crushTimer;
        private DispatcherTimer timeTimer;
        private int timeCounter=0;
        private int record;
        private bool isFirstRecord=true;
        private DispatcherTimer dialogTimer;
        public MainPage()
        {
            this.InitializeComponent();
            this.players = new List<BasePlayer>();
            this.blocks = new List<Rectangle>();
            this.blocks.Add(block1);
            this.blocks.Add(block2);
            this.blocks.Add(block3);
            this.blocks.Add(block4);
            this.blocks.Add(block5);
            this.blocks.Add(block6);
            this.blocks.Add(block7);
            this.blocks.Add(block8);
            this.blocks.Add(block9);
            this.blocks.Add(block10);
            this.blocks.Add(block11);
            this.blocks.Add(block12);
            this.blocks.Add(block13);
            this.blocks.Add(block14);
            this.blocks.Add(block15);
            this.blocks.Add(block16);
            this.blocks.Add(block17);
            this.blocks.Add(block18);
            this.blocks.Add(block19);
            this.blocks.Add(block20);
            this.blocks.Add(block21);
            this.blocks.Add(block22);
            this.blocks.Add(block23);
            this.blocks.Add(block24);
            this.blocks.Add(block25);
            this.blocks.Add(block26);
            this.blocks.Add(block27);
            this.blocks.Add(block28);
            this.blocks.Add(block29);
            this.blocks.Add(block30);
            this.blocks.Add(block31);
            this.blocks.Add(block32);
            this.blocks.Add(block33);
            this.blocks.Add(block34);
            this.blocks.Add(block35);
            this.crushTimer = new DispatcherTimer();
            this.crushTimer.Interval = TimeSpan.FromTicks(1);
            this.crushTimer.Tick += CrushTimer_Tick;
            this.crushTimer.Start();
            this.timeTimer = new DispatcherTimer();
            this.timeTimer.Interval = TimeSpan.FromTicks(1);
            this.timeTimer.Tick += TimeTimer_Tick;
            this.timeTimer.Start();
            this.dialogTimer = new DispatcherTimer();
            this.dialogTimer.Interval = TimeSpan.FromTicks(1);
            this.dialogTimer.Tick += DialogTimer_Tick;
            this.dialogTimer.Start();
        }

        private void DialogTimer_Tick(object sender, object e)
        {
            if(this.sP==null&&this.crushTimer.IsEnabled==false)
            {
                this.PlayAgainDialog();
                this.dialogTimer.Stop();
            }
        }

        private void TimeTimer_Tick(object sender, object e)
        {
            if (this.sP != null)
            {
                this.timeCounter++;
                if(this.timeCounter<10)
                {
                    this.timeTxt.Text = "Time: 0:0" + this.timeCounter.ToString();
                }
                if(this.timeCounter>10&&this.timeCounter<60)
                {
                    this.timeTxt.Text = "Time: 0:" + this.timeCounter.ToString();
                }
                if(this.timeCounter/60>0&&this.timeCounter%60<10)
                {
                    this.timeTxt.Text = "Time: " + (this.timeCounter / 60).ToString() + ":0" + (this.timeCounter % 60).ToString();
                }
                if(this.timeCounter/60>0&&this.timeCounter%60>10)
                {
                    this.timeTxt.Text = "Time: " + (this.timeCounter / 60).ToString() + ":" + (this.timeCounter % 60).ToString();
                }
                if (Canvas.GetLeft(this.players[0].image) > 0 && Canvas.GetLeft(this.players[0].image) < 90 && Canvas.GetTop(this.players[0].image) <= 0)
                {
                    if (this.isFirstRecord == true)
                    {
                        this.record = this.timeCounter;
                        this.isFirstRecord = false;
                        Frame.Navigate(typeof(RecordPage), this.record);
                        this.timeCounter = 0;
                        this.gameStartedCount = 0;
                        this.crushTimer.Stop();
                        this.timeTimer.Stop();
                    }
                    else
                    {
                        if (this.timeCounter < this.record)
                        {
                            this.record = this.timeCounter;
                            Frame.Navigate(typeof(RecordPage), this.record);
                            this.timeCounter = 0;
                            this.gameStartedCount = 0;
                            this.crushTimer.Stop();
                            this.timeTimer.Stop();
                        }
                        else
                        {
                            Frame.Navigate(typeof(WinPage), this.timeCounter);
                            this.timeCounter = 0;
                            this.crushTimer.Stop();
                            this.timeTimer.Stop();
                        }
                    }
                }
            }
        }

        private void CrushTimer_Tick(object sender, object e)
        {
            if (this.players != null)
            {
                Rect blockRect;
                Rect playerRect = new Rect(this.players[0].point.X, this.players[0].point.Y, 40, 40);
                for (int i = 0; i < 35; i++)
                {
                    Point blockPoint = new Point(Canvas.GetLeft(this.blocks[i]), Canvas.GetTop(this.blocks[i]));
                    blockRect = new Rect(blockPoint, new Size(this.blocks[i].Width, this.blocks[i].Height));
                    Rect r = RectHelper.Intersect(blockRect, playerRect);
                    if (r.Width > 0 || r.Height > 0)
                    {
                        if (this.deathCounter > 0)
                        {
                            switch (this.deathCounter)
                            {
                                case 3:
                                    this.sP.Children.Remove(life3);
                                    this.players[0].animationTimer.Stop();
                                    this.players[0].moveTimer.Stop();
                                    this.players[0].point.X = 490;
                                    this.players[0].point.Y = 435;
                                    this.players[0].image.Source = this.players[0].arrLeft[0];
                                    this.players[0].animationCount = 1;
                                    Canvas.SetLeft(this.players[0].image, this.players[0].point.X);
                                    Canvas.SetTop(this.players[0].image, this.players[0].point.Y);
                                    this.gameStartedCount = 0;
                                    this.deathCounter--;
                                    this.crushTimer.Start();
                                    break;
                                case 2:
                                    this.sP.Children.Remove(life2);
                                    this.players[0].animationTimer.Stop();
                                    this.players[0].moveTimer.Stop();
                                    this.players[0].point.X = 490;
                                    this.players[0].point.Y = 435;
                                    this.players[0].image.Source = this.players[0].arrLeft[0];
                                    this.players[0].animationCount = 1;
                                    Canvas.SetLeft(this.players[0].image, this.players[0].point.X);
                                    Canvas.SetTop(this.players[0].image, this.players[0].point.Y);
                                    this.gameStartedCount = 0;
                                    this.deathCounter--;
                                    this.crushTimer.Stop();
                                    break;
                                case 1:
                                    this.sP.Children.Remove(life1);
                                    this.players[0].animationTimer.Stop();
                                    this.players[0].moveTimer.Stop();
                                    this.players[0].point.X = 490;
                                    this.players[0].point.Y = 435;
                                    this.players[0].image.Source = this.players[0].arrLeft[0];
                                    this.players[0].animationCount = 1;
                                    Canvas.SetLeft(this.players[0].image, this.players[0].point.X);
                                    Canvas.SetTop(this.players[0].image, this.players[0].point.Y);
                                    this.gameStartedCount = 0;
                                    this.deathCounter--;
                                    this.sP = null;
                                    break;
                            }
                            if (this.sP == null)
                            {
                                this.myCanvas.Children.Remove(this.players[0].image);
                                this.players.RemoveAt(0);
                                this.timeTimer.Stop();
                                this.crushTimer.Stop();
                            }
                        }
                    }
                    else
                    {
                        this.crushTimer.Stop();
                    }
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.sP != null)
            {
                Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
                Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
            }
        }
    

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (this.sP != null)
            {
                switch (args.VirtualKey)
                {
                    case Windows.System.VirtualKey.Left:
                        this.players[0].moveTimer.Stop();
                        this.players[0].animationTimer.Stop();
                        break;
                    case Windows.System.VirtualKey.Right:
                        this.players[0].moveTimer.Stop();
                        this.players[0].animationTimer.Stop();
                        break;
                    case Windows.System.VirtualKey.Up:
                        this.players[0].moveTimer.Stop();
                        this.players[0].animationTimer.Stop();
                        break;
                    case Windows.System.VirtualKey.Down:
                        this.players[0].moveTimer.Stop();
                        this.players[0].animationTimer.Stop();
                        break;
                }
            }
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (this.sP != null)
            {
                if (this.gameStartedCount == 0)
                {
                    switch (args.VirtualKey)
                    {
                        case Windows.System.VirtualKey.Left:
                            this.players[0].direction = Direction.Left;
                            this.players[0].moveTimer.Start();
                            this.crushTimer.Start();
                            break;
                        case Windows.System.VirtualKey.Right:
                            break;
                        case Windows.System.VirtualKey.Up:
                            break;
                        case Windows.System.VirtualKey.Down:
                            break;
                    }
                    if (this.players[0].direction == Direction.Left)
                    {
                        this.gameStartedCount++;
                    }
                }
                else
                {
                    switch (args.VirtualKey)
                    {
                        case Windows.System.VirtualKey.Left:
                            this.players[0].direction = Direction.Left;
                            this.players[0].moveTimer.Start();
                            this.crushTimer.Start();
                            break;
                        case Windows.System.VirtualKey.Right:
                            this.players[0].direction = Direction.Right;
                            this.players[0].moveTimer.Start();
                            this.crushTimer.Start();
                            break;
                        case Windows.System.VirtualKey.Up:
                            this.players[0].direction = Direction.Up;
                            this.players[0].moveTimer.Start();
                            this.crushTimer.Start();
                            break;
                        case Windows.System.VirtualKey.Down:
                            this.players[0].direction = Direction.Down;
                            this.players[0].moveTimer.Start();
                            this.crushTimer.Start();
                            break;
                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var countGetter = (int)e.Parameter;
            switch (countGetter)
            {
                case 1:
                    Player1 player1 = new Player1(this.myCanvas);
                    this.players.Add(player1);
                    break;
                case 2:
                    Player2 player2 = new Player2(this.myCanvas);
                    this.players.Add(player2);
                    break;
                case 3:
                    Player3 player3 = new Player3(this.myCanvas);
                    this.players.Add(player3);
                    break;
            }
        }
        private async void PlayAgainDialog()
        {
            ContentDialog playOptionsDialog = new ContentDialog
            {
                Title = "Tough luck!",
                Content = "You can still play again tho..",
                CloseButtonText = "Exit game",
                PrimaryButtonText = "Play again",
            };
            ContentDialogResult result = await playOptionsDialog.ShowAsync();
            if(result==ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(OpenningPage));
            }
            else
            {
                Application.Current.Exit();
            }
        }
    }
}
