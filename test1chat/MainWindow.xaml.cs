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
        private double trainSpeed = 5;
        private double obsSpeed = 5;
        private int score = 0;
        private DispatcherTimer gameTimer;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }
        
        private void StartGame()
        {
            score = 0;
            trainSpeed = 5;
            obsSpeed = 5;
        }
    }
}