using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataList
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public float AverageScore { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Student number: {StudentNumber}, Average Score: {Math.Round(AverageScore, 2)}";
        }
    }
}
