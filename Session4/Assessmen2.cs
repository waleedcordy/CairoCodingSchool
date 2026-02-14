using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session4
{
    public class Assessment2
    {
        //Store student names in a list(with a defined maximum number of students).
        //Use a dictionary to map each student’s name to their list of grades.
        //Calculate the average grade for each student.
        //Assign a random grade level to each student using an enum:
        //Freshman, Sophomore, Junior, Senior.
        //Generate and display a formatted report of all students using StringBuilder.
        //Rule for Level Assignment
        //Average 0.0 – <20 → Freshman
        //Average 20 – <40 → Sophomore
        //Average 40 – <60 → Junior
        //Average 60 – 100 → Senior
        public Assessment2()
        {
            List<string> Students = new List<string>();
            Students.Add("Ali");
            Students.Add("Sara");
            Students.Add("Omar");
            Students.Add("Waleed");
            Students.Add("Rola");
            Students.Add("Mariam");
            Students.Add("Mina");
            Students.Add("Ayman");


            Dictionary<string, List<SubjectGrade>> StudentGrades = new Dictionary<string, List<SubjectGrade>>();

            foreach (string name in Students)
            {
                List<SubjectGrade> grades = new List<SubjectGrade>();
                foreach (var subject in new string[] { "Arabic", "English", "Social", "Social", "Math" })
                {
                    grades.Add(new SubjectGrade() { Subject = subject, Score = new Random().Next(0, 100) });
                }
                StudentGrades.Add(name, grades);
            }

            const int nameLength = 23;
            const int gradeLength = 22;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=================================================");
            sb.AppendLine("|            Name       ||    Grade Level       |");
            sb.AppendLine("=================================================");
            foreach(var student in StudentGrades)
            {
                sb.AppendLine($"|{student.Key,-nameLength}||{CalculateGradeLevel( student.Value),-gradeLength}|");
            }
            sb.AppendLine("=================================================");

            Console.Write(sb);

        }

        public GradeLevel CalculateGradeLevel(List<SubjectGrade> grades)
        {
            double Total = 0;
            foreach (var grade in grades)
            {
                Total = Total + grade.Score;
            }
            Total = Total / 5;
            //Rule for Level Assignment
            //Average 0.0 – <20 → Freshman
            //Average 20 – <40 → Sophomore
            //Average 40 – <60 → Junior
            //Average 60 – 100 → Senior

            if (Total > 0 && Total < 20)
                return GradeLevel.Freshman;
            else if (Total > 20 && Total < 40)
                return GradeLevel.Sophomore;
            else if (Total > 40 && Total < 60)
                return GradeLevel.Junior;
            else
                return GradeLevel.Senior;
        }

        public enum GradeLevel
        {
            Freshman, Sophomore, Junior, Senior
        }
        public struct SubjectGrade
        {
            public string Subject;
            public double Score;
        }
    }
}