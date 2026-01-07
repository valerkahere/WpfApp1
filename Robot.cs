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

}
