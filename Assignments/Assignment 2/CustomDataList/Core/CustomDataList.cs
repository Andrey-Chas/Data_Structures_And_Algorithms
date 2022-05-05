using CustomDataList.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataList
{
    public class CustomDataList : IComparer<Student>
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

        public int Compare(Student x, Student y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }

        public int CompareByStudentNumber(Student x, Student y)
        {
            return x.StudentNumber.CompareTo(y.StudentNumber);
        }

        public int CompareByAverageScore(Student x, Student y)
        {
            return x.AverageScore.CompareTo(y.AverageScore);
        }

        public void Sort()
        {
            Student temp;

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (Compare(students[i], students[j]) > 0)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public void SortByStudentNumber()
        {
            Student temp;

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (CompareByStudentNumber(students[i], students[j]) > 0)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public void GetMaxElement()
        {
            Student temp;

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (CompareByAverageScore(students[i], students[j]) > 0)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            for (int i = students.Length - 1; i > 0; i--)
            {
                if (Math.Round(students[students.Length - 1].AverageScore, 2) == Math.Round(students[i].AverageScore, 2))
                {
                    Console.WriteLine(students[i]);
                }
                else
                {
                    break;
                }
            }
        }

        public void GetMinElement()
        {
            Student temp;

            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (CompareByAverageScore(students[i], students[j]) > 0)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            for (int i = 0; i < students.Length; i++)
            {
                if (Math.Round(students[0].AverageScore, 2) == Math.Round(students[i].AverageScore, 2))
                {
                    Console.WriteLine(students[i]);
                }
                else
                {
                    break;
                }
            }
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
