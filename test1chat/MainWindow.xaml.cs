using System;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace test1chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DispatcherTimer minuterie;
        private DispatcherTimer temps_sec;
        private bool gauche, droite;
        private static BitmapImage train;
        private static readonly int Pas_train = 2;
        private static readonly int Pas_vertical = 5;
        private int temps = 60;
        private double energie = 100;
        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
            
            
        }

        private void InitTimer()
        {
            minuterie = new DispatcherTimer();
            temps_sec = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            temps_sec.Interval = TimeSpan.FromSeconds(1);
            minuterie.Tick += Jeutrain;
            temps_sec.Tick += ChangeTemps;
            minuterie.Start();
            temps_sec.Start();
        }

        private void ChangeTemps(object? sender, EventArgs e)
        {
            temps--;
            labTps.Content = temps + "s";
            
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                droite = true;                
                trainex.Source = train;
            }
            else if (e.Key == Key.Space)
            {
                if (minuterie.IsEnabled)
                    minuterie.Stop();
                else
                    minuterie.Start();
            }
            if (e.Key == Key.Up && Canvas.GetTop(trainex) > 0)
                Canvas.SetTop(trainex, Canvas.GetTop(trainex) - Pas_train);
            if (e.Key == Key.Down && Canvas.GetTop(trainex) < fenetre.Height - trainex.Height -40)
                Canvas.SetTop(trainex, Canvas.GetTop(trainex) + Pas_train);
        }

        private void Jeutrain(object? sender, EventArgs e)
        {
            Canvas.SetLeft(trainex, Canvas.GetLeft(trainex) + Pas_train);            
            if (Canvas.GetLeft(trainex) > this.ActualWidth)
                Canvas.SetLeft(trainex, -trainex.Width);

            energie -= 0.025;
            enrg.Content = (int)energie + "%";

        }
        private void runSprite(double i)
        {
            // this is the run sprite function, this function takes one argument inside its brackets
            // it takes a double variable called i
            // we will use this i to change the images for the player
            // below is the switch statement that will change the player sprite


            // when the i value changes between 1 and 8 it will assign appropriate sprite to the player sprite
            switch (i)
            {
                case 1:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_01.gif"));
                    break;
                case 2:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_02.gif"));
                    break;
                case 3:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_03.gif"));
                    break;
                case 4:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_04.gif"));
                    break;
                case 5:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 6:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_05.gif"));
                    break;
                case 7:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_07.gif"));
                    break;
                case 8:
                    playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/newRunner_08.gif"));
                    break;
            }
            // finally assign the player rectangle to the player sprite
            player.Fill = playerSprite;
        }



    }
}