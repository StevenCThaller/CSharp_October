using System;

namespace Inheritence
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle MyVehicle = new Vehicle();
            Car MyCar = new Car(2,true,"Diesel",4,"red","Ferrari", "h8g4kjhhggaklh43t");

            MyVehicle.Drive(27);
            SportsCar vroom = new SportsCar("rocket fuel");
            MyCar.RollDownWindows();
            MyCar.Drive(14);
            // MyVehicle.RollDownWindows();

            MyCar.YellVIN();

            vroom.YellVIN();
            // System.Console.WriteLine(MyCar.VIN);
        }
    }
}
