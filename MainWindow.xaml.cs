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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// LINK TO REPO:
    /// https://github.com/valerkahere/WpfApp1
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Robot> allRobots = new List<Robot>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Robot> CreateRobots()
        {
            List<Robot> robots = new List<Robot>();
            robots.Add(new HouseholdRobot("HouseBot"));
            robots.Add(new HouseholdRobot("GardenMate"));
            robots.Add(new HouseholdRobot("Housemate 3000"));
            robots.Add(new DeliveryRobot("DeliverBot"));
            robots.Add(new DeliveryRobot("FlyBot"));
            robots.Add(new DeliveryRobot("Driver"));
            return robots;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            allRobots = CreateRobots();
            RobotsListBox.ItemsSource = null;
            RobotsListBox.ItemsSource = allRobots;
        }
    }
}