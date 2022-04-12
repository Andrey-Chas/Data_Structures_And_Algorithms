using CustomDataList.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataList
{
    public class CustomDataList
    {
        private Student[] students;
        private int placesInUse;
        private int numberOfTheStudentNumbers;
        public string[] studentNumber = { "A01", "A02", "A03", "A04", "A05", "A06", "A07", "A08", "A09", "A10" };
        public int Length
        {
            get
            {
                int count = 0;
                foreach (var item in students)
                {
                    count++;
                }
                return count;
            }
        }
        public Student First
        {
            get
            {
                return students[0];
            }
        }
        public Student Last
        {
            get
            {
                return students[students.Length - 1];
            }
        }

        public CustomDataList(int limit)
        {
            students = new Student[limit];
            placesInUse = 0;
            numberOfTheStudentNumbers = studentNumber.Length;
        }

        public void DisplayList()
        {
            Console.WriteLine("--------------------------------------------------------------");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {students[i]}");
                }
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void PopulateWithSampleData()
        {
            Random rnd = new Random();

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student
                {
                    FirstName = Convert.ToString((FirstName)rnd.Next(0, 10)),
                    LastName = Convert.ToString((LastName)rnd.Next(0, 10)),
                    StudentNumber = studentNumber[i],
                    AverageScore = (float)rnd.NextDouble() * (6 - 3) + 3
                };
                placesInUse++;
            }
        }

        public Student GetElement(int index)
        {
            if (index <= 0 || index > students.Length)
            {
                throw new ArgumentOutOfRangeException($"Student with index {index} does not exist");
            }

            return students[index - 1];
        }

        public void Add(Student student, string studentNum)
        {
            IncreaseArraySize();
            IncreaseArraySizeOfTheStudentNumber();

            students[placesInUse] = student;
            studentNumber[numberOfTheStudentNumbers] = studentNum;
            placesInUse++;
            numberOfTheStudentNumbers++;
        }

        public void RemoveByIndex(int index)
        {
            if (index <= 0 || index > students.Length)
            {
                throw new ArgumentOutOfRangeException($"Student with index {index} does not exist");
            }

            for (int i = index - 1; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void RemoveFirst()
        {
            for (int i = 0; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void RemoveLast()
        {
            for (int i = placesInUse - 1; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void IncreaseArraySize()
        {
            if (placesInUse >= students.Length)
            {
                Student[] resizedArray = new Student[students.Length + 1];

                Array.Copy(students, 0, resizedArray, 0, students.Length);

                students = resizedArray;
            }
        }

        public void DecreaseArraySize()
        {
            Student[] resizedArray = new Student[students.Length - 1];

            Array.Copy(students, 0, resizedArray, 0, students.Length - 1);

            students = resizedArray;
        }

        public void IncreaseArraySizeOfTheStudentNumber()
        {
            if (numberOfTheStudentNumbers >= studentNumber.Length)
            {
                string[] resizedArray = new string[studentNumber.Length + 1];

                Array.Copy(studentNumber, 0, resizedArray, 0, studentNumber.Length);

                studentNumber = resizedArray;
            }
        }
    }
}
