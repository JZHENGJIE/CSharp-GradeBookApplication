using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work") ;
            }

            char letterGrade = ' ';
            int levalNum = (int)Math.Ceiling((Students.Count / 5.0));
            List<double> sortStudentGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            if(sortStudentGrades[levalNum - 1] <= averageGrade)
            {
                letterGrade = 'A';
            }else if(sortStudentGrades[levalNum * 2 - 1] <= averageGrade)
            {
                letterGrade = 'B';
            }else if(sortStudentGrades[levalNum * 3 - 1] <= averageGrade)
            {
                letterGrade = 'C';
            }else if(sortStudentGrades[levalNum * 4 - 1] <= averageGrade)
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }

            return letterGrade;
        }

    }
}
