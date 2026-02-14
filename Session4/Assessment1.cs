using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp1.Session4
{
    public class Assessment1
    {
        //Distance Between Two Points in a Grid - using Struct
        //Two points in a 2D grid: Point A: (x1, y1) and Point B: (x2, y2)
        //Task:
        //Calculate the Euclidean distance between these two points
        //using the formula:
        //var distance = Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        public Assessment1()
        {
            Point a = new Point();
            Point b = new Point();

            bool pointACorrect = false, pointBCorrect = false;

          

            while (pointACorrect == false)
            {
                Console.WriteLine("Enter Point a (ex. 4,7) :");

                string line = Console.ReadLine();
                if (line.Split(",").Count() == 2)
                {
                    var splits = line.Split(",");
                    if (double.TryParse(splits[0], out double aa) && double.TryParse(splits[0], out double bb))
                    {
                        a.x = aa;
                        a.y = bb;
                        pointACorrect = true;
                    }
                   
                }
            }

            while (pointBCorrect == false)
            {
                Console.WriteLine("Enter Point b (ex. 4,7) :");

                string line = Console.ReadLine();
                if (line.Split(",").Count() == 2)
                {
                    var splits = line.Split(",");
                    if (double.TryParse(splits[0], out double aa) && double.TryParse(splits[0], out double bb))
                    {
                        b.x = aa;
                        b.y = bb;
                        pointBCorrect = true;
                    }

                }
            }

            var distance = Math.Sqrt(Math.Pow(b.x - a.x,2)+ Math.Pow(b.y-a.y,2));

            Console.WriteLine($"Distance = {distance}");
        }

        struct Point
        {
            public double x;
            public double y;
        }
    }
}