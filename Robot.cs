using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    abstract class Robot 
    {
        public string RobotName { get; set; }
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
            return $"{RobotName} - ";
        }
    }

    public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }

    public enum DeliveryMode
    { Walking, Driving, Flying }

    class HouseholdRobot : Robot
    {
        private List<HouseholdSkill> Skills { get; set; }
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

        public override string DescribeRobot()
        {

            return $"I am a {RobotName}.\n" +
                $"I specialise in delivery by Flying.\n\n" +
                $"The maximum load I can carry is {MaxLoadKg:F2} kg.\n\n" +
                $"{DisplayBatteryInformation()}";
        }
    }

}
