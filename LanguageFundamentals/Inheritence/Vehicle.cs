using System;
using System.Collections.Generic;

namespace Inheritence
{
    public class Vehicle
    {
        //================= Attributes ===================//
        public string Motor; // diesel, gas, electric
        public int Wheels; // how many wheels does the vehicle have
        public string Color; // what color is the vehicle
        public string Manufacturer; // what company made the vehicle
        public double Odometer; // how far has the vehicle driven
        protected string VIN;

        //================ Constructors ==================//
        public Vehicle()
        {
            Motor = "Gasoline";
            Wheels = 4;
            Color = "Silver";
            Manufacturer = "Toyota";
            Odometer = 0;
            VIN = "982374lkajsdfgty923htr";
        }

        public Vehicle(string motor)
        {
            Motor = "jelly fish jelly";
            VIN = "lkashjfldjalksdf";
        }

        public Vehicle(string motor, int wheels, string color, string manufacturer, string vin)
        {
            Motor = motor;
            Wheels = wheels;
            Color = color;
            Manufacturer = manufacturer;
            Odometer = 0;
            VIN = vin;
        }
        //=================== Methods ====================//
        public virtual void Drive(double distance)
        {
            System.Console.WriteLine($"You took your {Manufacturer} for a drive, adding {distance} to the odometer");
            Odometer += distance;
        }

        public virtual void TurnSignal(string direction)
        {
            System.Console.WriteLine($"You flip your {direction} turn signal");
        }

        public void Brake()
        {
            System.Console.WriteLine($"You slammed on the brakes, coming to a stop!");
        }
        //================================================//
    }
}