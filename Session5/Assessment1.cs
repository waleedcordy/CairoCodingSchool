using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1.Session5
{
    public class Assessment1
    {
        //Assessment1
        //Create a class that stores 5 student grades and allows access by index
        //using indexers
        public Assessment1()
        {
            Grades grades = new Grades();
            grades[0] = 95;
            grades[1] = 88;
            grades[10] = 20;
            grades[30] = 100;
            grades[40] = 200;

            Console.WriteLine(grades[0]);
            Console.WriteLine(grades[1]);
            Console.WriteLine(grades[10]);
            Console.WriteLine(grades[30]);
            Console.WriteLine(grades[40]);
        }
    }

    public class Grades()
    {
        int[] array = new int[0];

        public int this[int index]
        {
            get
            {
                if (array.Length<= index)
                {
                    return 0;
                }
                else
                {
                    return array[index];
                }
            }
            set
            {
                if (array.Length <= index)
                {
                    Array.Resize(ref array, index + 1);
                    array[index] = value;
                }
                else
                {
                    array[index] = value;
                }
            }
        }
    }
}