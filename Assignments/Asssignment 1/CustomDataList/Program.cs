using System;

namespace CustomDataList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDataList data = new CustomDataList(10);
            data.PopulateWithSampleData();

            while (true)
            {
                DisplayCoverPage();

                string userInput = Console.ReadLine();

                while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5" && userInput != "6" && userInput != "0")
                {
                    Console.Write("This option does not exist. Please type an existing one: ");
                    userInput = Console.ReadLine();
                }

                if (userInput == "1")
                {
                    Console.Clear();
                    AddStudent(data);
                }

                if (userInput == "2")
                {
                    if (data.Length != 0)
                    {
                        Console.Clear();
                        GetStudent(data);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The list is empty!");
                        PressKeyToContinue();
                    }
                }

                if (userInput == "3")
                {
                    if (data.Length != 0)
                    {
                        Console.Clear();
                        RemoveSpecificStudent(data);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The list is empty!");
                        PressKeyToContinue();
                    }
                }

                if (userInput == "4")
                {
                    if (data.Length != 0)
                    {
                        Console.Clear();
                        RemoveTheFirstStudent(data);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The list is empty!");
                        PressKeyToContinue();
                    }
                }

                if (userInput == "5")
                {
                    if (data.Length != 0)
                    {
                        Console.Clear();
                        RemoveTheLastStudent(data);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The list is empty!");
                        PressKeyToContinue();
                    }
                }

                if (userInput == "6")
                {
                    if (data.Length != 0)
                    {
                        Console.Clear();
                        DisplayListOfStudents(data);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The list is empty!");
                        PressKeyToContinue();
                    }
                }

                if (userInput == "0")
                {
                    break;
                }
            }
        }

        private static void DisplayCoverPage()
        {
            Console.Clear();
            Console.WriteLine("STUDENTS LIST");
            Console.WriteLine("\n\t1. Add student");
            Console.WriteLine("\n\t2. Get student");
            Console.WriteLine("\n\t3. Remove specific student");
            Console.WriteLine("\n\t4. Remove the first student from the list");
            Console.WriteLine("\n\t5. Remove the last student from the list");
            Console.WriteLine("\n\t6. Display list of students");
            Console.WriteLine("\n\t0. Exit");
            Console.Write("\nPlease enter your choice by typing one number (0 - 6): ");
        }

        private static void AddStudent(CustomDataList data)
        {
            float num;

            Console.WriteLine("ADD STUDENT");
            Console.WriteLine();
            Console.Write("Please type the first name of the student: ");
            var firstName = Console.ReadLine();

            Console.Write("Please type the last name of the student: ");
            var lastName = Console.ReadLine();

            Console.Write("Please type the student number: ");
            var studentNum = Console.ReadLine();
            for (int i = 0; i < data.studentNumber.Length; i++)
            {
                while (data.studentNumber[i] == studentNum)
                {
                    Console.Write("This student number already exsists. Please type a new one: ");
                    studentNum = Console.ReadLine();
                    i = 0;
                }
            }

            Console.Write("Please type the average score (decimal format with comma): ");
            var averageScore = Console.ReadLine();
            while (!float.TryParse(averageScore, out num) || Convert.ToDouble(averageScore) < 3 || Convert.ToDouble(averageScore) > 6)
            {
                Console.Write("This is not a number or it is outside the range.\nPlease type a number (3 - 6, decimal format with comma): ");
                averageScore = Console.ReadLine();
            }

            var averageScoreConverted = Convert.ToDouble(averageScore);

            Student student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                StudentNumber = studentNum,
                AverageScore = (float)averageScoreConverted
            };

            Console.WriteLine();
            Console.WriteLine("The student has been saved!");
            PressKeyToContinue();

            data.Add(student, studentNum);
        }

        private static void GetStudent(CustomDataList data)
        {
            while (true)
            {
                int num;

                Console.WriteLine("GET STUDENT");
                Console.WriteLine();
                Console.Write("Please type the index of the student you would like to get\n(index starts from number 1) or type 0 to exit: ");
                var userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    break;
                }

                while (!int.TryParse(userInput, out num) || Convert.ToInt32(userInput) < 0 || Convert.ToInt32(userInput) > data.Length)
                {
                    Console.Write("This is not a number or index does not exsist.\nPlease type a number and exsisting index (index starts from number 1) or type 0 to exit: ");
                    userInput = Console.ReadLine();
                    if (userInput == "0")
                    {
                        break;
                    }
                }

                if (userInput == "0")
                {
                    break;
                }

                int userInputConverted = Convert.ToInt32(userInput);

                Console.WriteLine();
                Console.WriteLine(data.GetElement(userInputConverted));

                while (true)
                {
                    Console.WriteLine();
                    Console.Write("If you would like to continue getting students, please type the index of the\nstudent (index starts from 1) or type 0 to exit: ");
                    userInput = Console.ReadLine();

                    if (userInput == "0")
                    {
                        break;
                    }

                    while (!int.TryParse(userInput, out num) || Convert.ToInt32(userInput) <= 0 || Convert.ToInt32(userInput) > data.Length)
                    {
                        Console.Write("This is not a number or index does not exsist.\nPlease type a number and exsisting index (index starts from number 1) or type 0 to exit: ");
                        userInput = Console.ReadLine();
                        if (userInput == "0")
                        {
                            break;
                        }
                    }

                    if (userInput == "0")
                    {
                        break;
                    }

                    userInputConverted = Convert.ToInt32(userInput);

                    Console.WriteLine();
                    Console.WriteLine(data.GetElement(userInputConverted));
                }
                break;
            }
        }

        private static void RemoveSpecificStudent(CustomDataList data)
        {
            while (true)
            {
                int num;

                Console.WriteLine("REMOVE STUDENT");
                Console.WriteLine();
                Console.Write("Please type the index of the student you would like to remove\n(index starts from number 1) or type 0 to exit: ");
                var userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    break;
                }

                while (!int.TryParse(userInput, out num) || Convert.ToInt32(userInput) <= 0 || Convert.ToInt32(userInput) > data.Length)
                {
                    Console.Write("This is not a number or index does not exsist.\nPlease type a number and exsisting index (index starts from number 1) or type 0 to exit: ");
                    userInput = Console.ReadLine();
                    if (userInput == "0")
                    {
                        break;
                    }
                }

                if (userInput == "0")
                {
                    break;
                }

                int userInputConverted = Convert.ToInt32(userInput);

                Console.WriteLine();
                var elementToRemove = data.GetElement(userInputConverted);
                data.RemoveByIndex(userInputConverted);
                Console.WriteLine($"Student with information\n{elementToRemove}\nwas successfully removed from the list!");

                while (true && data.Length != 0)
                {
                    Console.WriteLine();
                    Console.Write("If you would like to continue removing students, please type the index of the\nstudent (index starts from number 1) or type 0 to exit: ");
                    userInput = Console.ReadLine();

                    if (userInput == "0")
                    {
                        break;
                    }

                    while (!int.TryParse(userInput, out num) || Convert.ToInt32(userInput) <= 0 || Convert.ToInt32(userInput) > data.Length)
                    {
                        Console.Write("This is not a number or index does not exsist.\nPlease type a number and exsisting index (index starts from number 1) or type 0 to exit: ");
                        userInput = Console.ReadLine();
                        if (userInput == "0")
                        {
                            break;
                        }
                    }

                    if (userInput == "0")
                    {
                        break;
                    }

                    userInputConverted = Convert.ToInt32(userInput);

                    Console.WriteLine();
                    elementToRemove = data.GetElement(userInputConverted);
                    data.RemoveByIndex(userInputConverted);
                    Console.WriteLine($"Student with information\n{elementToRemove}\nwas successfully removed from the list!");
                }

                if (data.Length == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The list is empty!");
                    PressKeyToContinue();
                }
                break;
            }
        }

        private static void RemoveTheFirstStudent(CustomDataList data)
        {
            Console.WriteLine("REMOVING THE FIRST STUDENT FROM THE LIST");
            Console.WriteLine();

            var elementToRemove = data.GetElement(1);
            data.RemoveFirst();
            Console.WriteLine($"The first student from the list with information\n{elementToRemove}\nwas successfully removed from the list!");
            PressKeyToContinue();
        }

        private static void RemoveTheLastStudent(CustomDataList data)
        {
            Console.WriteLine("REMOVING THE LAST STUDENT FROM THE LIST");
            Console.WriteLine();

            var elementToRemove = data.GetElement(data.Length);
            data.RemoveLast();
            Console.WriteLine($"The last student from the list with information\n{elementToRemove}\nwas successfully removed from the list!");
            PressKeyToContinue();
        }

        private static void DisplayListOfStudents(CustomDataList data)
        {
            Console.WriteLine("THE LIST OF STUDENTS");
            Console.WriteLine();

            data.DisplayList();
            PressKeyToContinue();
        }

        private static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
