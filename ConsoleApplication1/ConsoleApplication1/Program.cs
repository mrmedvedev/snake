using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace ConsoleApplication1
{
    class Program
    {
        static void L()
        {
            Turtle.Angle = 180;
            Turtle.Move(100);
            Turtle.Angle = 90;
            Turtle.Move(50);

        }
        static void O()
        {
            Turtle.Angle = 180;
            Turtle.Move(100);
            Turtle.TurnLeft();
            Turtle.Move(50);
            Turtle.TurnLeft();
            Turtle.Move(100);
            Turtle.TurnLeft();
            Turtle.Move(50);

        }

        static void V()
        {
            Turtle.Angle = 160;
            Turtle.Move(100);
            Turtle.Angle = 30;
            Turtle.Move(110);

        }

        static void E()
        {
            Turtle.Angle = 0;
            Turtle.TurnLeft();
            Turtle.Move(50);
            Turtle.Angle = 180;
            Turtle.Move(50);
            Turtle.TurnLeft();
            Turtle.Move(50);
            Turtle.Angle = 270;
            Turtle.Move(50);
            Turtle.TurnLeft();
            Turtle.Move(50);
            Turtle.TurnLeft();
            Turtle.Move(50);

        }

        static void Y()
        {
            Turtle.Angle = 150;
            Turtle.Move(50);
            Turtle.Angle = 30; 
            Turtle.Move(50);
            Turtle.Angle = 210;
            Turtle.Move(50);
            Turtle.Angle = 180;
            Turtle.Move(50);


        }

        static void U()
        {
            Turtle.Angle = 180;
            Turtle.Move(100);
            Turtle.TurnLeft();
            Turtle.Move(50);
            Turtle.TurnLeft();
            Turtle.Move(100);
        }
        static void Main(string[] args)
            
        {
            Turtle.Speed = 6;
            Turtle.X = 100;
            Turtle.Y = 100;
                        
            L();

            Turtle.X = 200;
            Turtle.Y = 100;

            O();

            Turtle.X = 300;
            Turtle.Y = 100;

            V();

            Turtle.X = 480;
            Turtle.Y = 100;

            E();

            Turtle.X = 150;
            Turtle.Y = 250;

            Y();

            Turtle.X = 250;
            Turtle.Y = 250;

            O();

            Turtle.X = 350;
            Turtle.Y = 250;

            U();






        }
    }
}
