using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console2
{
    public class PharaohMenu
    {
        public static void PharaohAddMenu()
        {
            string[] pharaohdata = new string[3];
            string pleaseEnter = "Please Enter Pharaoh"; // reusable in other classes i guess
            Console.Write($"{pleaseEnter} name: ");
            pharaohdata[0] = Console.ReadLine(); // need check for string.empty
            Console.Write($"{pleaseEnter} Regin start date (correct format: YYYY.MM.DD): ");
            pharaohdata[1] = Console.ReadLine(); // need check for date
            Console.Write($"{pleaseEnter} Regin end date (correct format: YYYY.MM.DD): ");
            pharaohdata[2] = Console.ReadLine(); // need check for date // How to make a pharaoh
                                                 // call for the pharaoh add method
        }
        public static void PharaohUpdateMenu() // 1. what should  and its correct or not
        {
            int choiceToUpdate = -1;
            while(choiceToUpdate < 0 || choiceToUpdate > 3)
            {
                Console.Clear();
                Console.WriteLine("Please choose which you want to update");
                Console.WriteLine($"[0] Pharaoh Name");
                Console.WriteLine($"[1] Pharaoh regin start date");
                Console.WriteLine($"[2] Pharaoh regin end date");
                Console.WriteLine($"[3] Exit");
                Console.WriteLine();
                Console.Write("Choice: ");
                choiceToUpdate = int.Parse(Console.ReadLine()); // need to check for int
            }
            if (choiceToUpdate < 3)
                InsertPharaohNewDataForUpdate(choiceToUpdate);
        }

        public static string InsertPharaohNewDataForUpdate(int choiceToUpdate)
        {
            string answer = string.Empty;
            switch (choiceToUpdate)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Please Enter the pharaoh new name");
                    Console.WriteLine();
                    Console.Write($"Pharaoh new name: ");
                    answer = Console.ReadLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please Enter the pharaoh new regin start date (correct format: YYYY.MM.DD)");
                    Console.WriteLine();
                    Console.Write($"Pharaoh new regin start date:"); // need check for date
                    answer = Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Please Enter the pharaoh new regin end date (correct format: YYYY.MM.DD)");
                    Console.WriteLine();
                    Console.Write($"Pharaoh new regin end date: "); // need check for date
                    answer = Console.ReadLine();
                    break;
            }
            return answer;
        }
        public static void PharaohRemoveMenu()
        {
            int id = -1;
            Console.Clear();
            Console.WriteLine($"Please Enter the pharaoh id you wanna delete");
            Console.WriteLine();
            Console.Write($"Pharaoh id: ");
            id = int.Parse(Console.ReadLine());
        }
    }
    public class ProjectMenu
    {
        public static void ProjectAddMenu()
        {
            Console.Clear();
            string[] pharaohdata = new string[3];
            string pleaseEnter = "Please Enter Project"; // reusable in other classes i guess
            Console.Write($"{pleaseEnter} name: ");
            pharaohdata[0] = Console.ReadLine(); // need check for string.empty

            Console.WriteLine();
            Console.Write($"{pleaseEnter} start date (correct format: YYYY.MM.DD): ");

            pharaohdata[1] = Console.ReadLine(); // need check for date
            Console.WriteLine();
            Console.Write($"{pleaseEnter} end date (correct format: YYYY.MM.DD): ");

            pharaohdata[2] = Console.ReadLine(); // need check for date // How to make a project
            Console.WriteLine();
            Console.Write($"{pleaseEnter} Pharaoh id (correct format: YYYY.MM.DD): ");   // call for the project add method
        }
        public static void ProjectUpdateMenu() // 1. what should  and its correct or not
        {
            int choiceToUpdate = -1;
            while (choiceToUpdate < 0 || choiceToUpdate > 4)
            {
                Console.Clear();
                Console.WriteLine("Please choose which you want to update");
                Console.WriteLine($"[0] Project Name");
                Console.WriteLine($"[1] Project start date");
                Console.WriteLine($"[2] Project end date");
                Console.WriteLine($"[3] Project pharaoh id");
                Console.WriteLine($"[4] Exit");
                Console.WriteLine();
                Console.Write("Choice: ");
                choiceToUpdate = int.Parse(Console.ReadLine()); // need to check for int
            }
            if (choiceToUpdate < 4)
                InsertProjectNewDataForUpdate(choiceToUpdate);
        }

        public static string InsertProjectNewDataForUpdate(int choiceToUpdate)
        {
            string answer = string.Empty;
            switch (choiceToUpdate)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Please Enter the project new name");
                    Console.WriteLine();
                    Console.Write($"Project new name: ");
                    answer = Console.ReadLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please Enter the project new start date (correct format: YYYY.MM.DD)");
                    Console.WriteLine();
                    Console.Write($"Project new regin start date:"); // need check for date
                    answer = Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Please Enter the project new end date (correct format: YYYY.MM.DD)");
                    Console.WriteLine();
                    Console.Write($"Project new regin end date: "); // need check for date
                    answer = Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Please Enter the project new pharaoh id (correct format: YYYY.MM.DD)");
                    Console.WriteLine();
                    Console.Write($"Project new regin end date: "); // need check for date
                    answer = Console.ReadLine();
                    break;
            }
            return answer;
        }
        public static void ProjectRemoveMenu()
        {
            int id = -1;
            Console.Clear();
            Console.WriteLine($"Please Enter the project id you wanna delete");
            Console.WriteLine();
            Console.Write($"Project id: ");
            id = int.Parse(Console.ReadLine());
        }
    }
}
