using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    abstract class Robot 
    {
        public string RobotName { get; set; }
        public string RobotType { get; set; }
        public double PowerCapacityKWH { get; set; }
        public double CurrentPowerKWH { get; set; }
        //public Robot(string name, int batteryLevel)
        //{
        //    Name = name;
        //    BatteryLevel = batteryLevel;
        //}
        public virtual double GetBatteryPercentage()
        {
            return (CurrentPowerKWH / PowerCapacityKWH) * 100;
        }
        public abstract string DescribeRobot();
        public virtual string DisplayBatteryInformation()
        {
            return $"Battery Information\nCapacity: {PowerCapacityKWH}kWh\nCurrent Power: {CurrentPowerKWH}kWh\nBattery Level: {GetBatteryPercentage():F2}%";
        }

        public override string ToString()
        {
            return $"{RobotName} - [{RobotType}]";
        }
    }

    public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }

    public enum DeliveryMode
    { Walking, Driving, Flying }

    class HouseholdRobot : Robot
    {
        private List<HouseholdSkill> Skills { get; set; }
        public HouseholdRobot()
        {
            RobotType = "HouseholdRobot";
        }
        public HouseholdRobot(string robotName)
        {
            RobotName = robotName;
            RobotType = "HouseholdRobot";
        }
        public HouseholdRobot(string robotName, string robotType)
        {
            RobotName = robotName;
            RobotType = robotType;
        }
        public HouseholdRobot(string robotName, HouseholdSkill skills)
        {
            RobotName = robotName;
            RobotType = "HouseholdRobot";
            Skills = new List<HouseholdSkill>();
            
        }
        public HouseholdRobot(string robotName, string robotType, HouseholdSkill skills)
        {
            RobotName = robotName;
            RobotType = robotType;
            Skills = new List<HouseholdSkill>();
        }

        public override string DescribeRobot()
        {
            string skillsDescription = Skills != null && Skills.Count > 0
                ? string.Join(", ", Skills)
                : "No skills available";
            return $"I am a {RobotName}.\n" +
                $"I can help with chores around the house.\n\n" +
                $"{RobotName} Skills:\n" +
                $"{Skills}\n\n" +
                $"{DisplayBatteryInformation()}";
        }
    }

    class DeliveryRobot : Robot
    {
        private DeliveryMode ModeOfDelivery { get; set; }
        private double MaxLoadKg { get; set; }
        public DeliveryRobot()
        {
            RobotType = "DeliveryRobot";
        }
        public DeliveryRobot(string robotName)
        {
            RobotName = robotName;
            RobotType = "DeliveryRobot";
        }
        public DeliveryRobot(string robotName, string robotType)
        {
            RobotName = robotName;
            RobotType = robotType;
        }
        public DeliveryRobot(string robotName, DeliveryMode deliveryMode)
        {
            RobotName = robotName;
            RobotType = "DeliveryRobot";
            ModeOfDelivery = deliveryMode;
        }
        public DeliveryRobot(string robotName, string robotType, DeliveryMode deliveryMode)
        {
            RobotName = robotName;
            RobotType = robotType;
            ModeOfDelivery = deliveryMode;
        }
        public override string DescribeRobot()
        {

            return $"I am a {RobotName}.\n" +
                $"I specialise in delivery by Flying.\n\n" +
                $"The maximum load I can carry is {MaxLoadKg:F2} kg.\n\n" +
                $"{DisplayBatteryInformation()}";
        }
    }

}
