using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            robots.Add(new DeliveryRobot("DeliveryBot"));
            robots.Add(new DeliveryRobot("FlyBot"));
            robots.Add(new DeliveryRobot("Driver"));
            return robots;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            allRobots = CreateRobots();
            RobotsListBox.ItemsSource = null;
            RobotsListBox.ItemsSource = allRobots;

            foreach (var robot in allRobots)
            {
                if (robot.RobotName.Contains("GardenMate"))
                {
                    robot.DownloadSkill(HouseholdSkill.Gardening);
                }
            }
            foreach (var robot in allRobots)
            {
                if (robot.RobotName.Contains("Housemate 3000"))
                {
                    robot.DownloadSkill(HouseholdSkill.Cooking);
                    robot.DownloadSkill(HouseholdSkill.Laundry);
                }
            }
            
            
        }

        private void RobotsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RobotsTextBlock.Text = null;
            Robot selected = RobotsListBox.SelectedItem as Robot;
            if (selected != null)
            {
                RobotsTextBlock.Text = selected.DescribeRobot();
            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAll.IsChecked == true)
            {
                RobotsListBox.ItemsSource = null;
                RobotsListBox.ItemsSource = allRobots;
                return;
            } else if (RadioButtonHousehold.IsChecked == true)
            {
                RobotsListBox.ItemsSource = null;
                var householdRobots = allRobots.Where(r => r is HouseholdRobot).ToList();
                RobotsListBox.ItemsSource = householdRobots;
                return;
            }
            else if (RadioButtonDelivery.IsChecked == true)
            {
                var householdRobots = allRobots.Where(r => r is DeliveryRobot).ToList();
                RobotsListBox.ItemsSource = householdRobots;
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RobotsListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a robot to view battery information.");
                return;
            } else
            {
                Robot selectedRobot = RobotsListBox.SelectedItem as Robot;
                if (selectedRobot != null)
                {
                    if (selectedRobot.CurrentPowerKWH == 100)
                    {
                        MessageBox.Show($"{selectedRobot.RobotName} is already fully charged.");

                    }
                }
            }
        }
    }
}