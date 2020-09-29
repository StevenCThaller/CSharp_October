using System;

namespace Inheritence
{
    public class Car : Vehicle
    {
        //================= Attributes ===================//

        public int Doors; // how many doors does our car have
        public bool Convertible; // is it a convertible?
        //================ Constructors ==================//
        public Car()
        {
            Doors = 4;
            Convertible = false;
        }

        public Car(string motor) : base(motor)
        {
            Motor = motor;
        }

        public Car(int doors, bool convert, string motor, int wheels, string color, string manufacturer, string vin) : base(motor, wheels, color, manufacturer, vin)
        {
            Doors = doors;
            Convertible = convert;
        }
        //=================== Methods ====================//
        public void RollDownWindows()
        {
            System.Console.WriteLine($"You rolled down all {Doors} windows, because you're the coolest cat ever.");
        }

        public override void Drive(double distance)
        {
            if(Convertible)
            {
                System.Console.WriteLine($"You put down the roof.");
            }
            base.Drive(distance);
        }

        public void YellVIN()
        {
            System.Console.WriteLine(VIN);
        }
        //================================================//
    }
}