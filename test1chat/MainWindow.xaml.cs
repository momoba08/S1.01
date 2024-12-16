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
        private BitmapImage marteau ;
        private static readonly int Pas_train = 2;
        private static readonly int Pas_vertical = 5;
        private int temps = 60, image = 1;
        private double energie = 100;
        private int nb_obstacle = 5;
        private Image[] lesobstacles;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
            //this.Loaded += Window_Loaded;
            InitObstacles();
            
            
        }

       // private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
       //     InitObstacles();
       // }

      

        private void InitObstacles()
        {
            //BitmapImage marteau;

            BitmapImage marteau = new BitmapImage(new Uri("pack://application:,,,/img/marteau.png"));

            lesobstacles = new Image[nb_obstacle];
            for (int i = 0; i < lesobstacles.Length; i++)

            {
                lesobstacles[i]= new Image
                {
                    Width = 50,
                    Height = 50,
                    Source = marteau
                };

                epoque.Children.Add(lesobstacles[i]);
                Canvas.SetLeft(lesobstacles[i], random.Next(0, (int)this.ActualWidth+50));
                Canvas.SetTop(lesobstacles[i], -random.Next(0, (int)this.ActualWidth+50));
            }
        }

        private void DeplacementObstacles()
        {
            for (int i = 0; i < lesobstacles.Length; ++i)
            {
                double currentLeft = Canvas.GetLeft(lesobstacles[i]);
                Canvas.SetLeft(lesobstacles[i], currentLeft - Pas_vertical);

                if (currentLeft < -lesobstacles[i].Width)
                {
                    Canvas.SetLeft(lesobstacles[i], this.ActualWidth + random.Next(100,300));
                    Canvas.SetTop(lesobstacles[i], random.Next(0, (int)(epoque.ActualHeight - lesobstacles[i].Height)));
                }
            }

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
            labTps.Content = temps + " s";
            
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
            {
               
                     
                Canvas.SetLeft(trainex, -trainex.Width);
            }      
            energie -= 0.025;
            enrg.Content = (int)energie + " %";

            DeplacementObstacles();
            if (temps <= 0 || energie <= 0)
            {
                minuterie.Stop();
                temps_sec.Stop();
                MessageBox.Show("game over !");
            }
               
                    

        }

  

    }
}