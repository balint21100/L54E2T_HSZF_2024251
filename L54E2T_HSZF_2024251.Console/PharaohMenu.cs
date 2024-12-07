﻿using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Console;
using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console2
{
    public class PharaohMenu
    {
        //kinda finished
        public static void PharaohAddMenu()
        {
            string[] pharaohdata = new string[3];
            ///// new tech
            string pleaseEnter = "Please Enter";
            string Pharaoh = "Pharaoh ";
            string name = "name: ";
            string reignStart = "Reign start date (correct format: YYYY.MM.DD): ";
            string reignEnd = "Reign end date (correct format: YYYY.MM.DD): ";

            pharaohdata[0] = GetInput(pleaseEnter, Pharaoh+name, InputCheckForMenus.StringEmptyCheck); // test approved
            if (!pharaohdata.Contains("exit"))
            pharaohdata[1] = GetInput(pleaseEnter, Pharaoh + reignStart, InputCheckForMenus.DateTimeCheck);// test approved
            if(!pharaohdata.Contains("exit"))
            pharaohdata[2] = GetInput(pleaseEnter, Pharaoh + reignEnd, InputCheckForMenus.DateTimeCheck);// test approved

            if (!pharaohdata.Contains("exit"))
            {
                Pharaohs p = new Pharaohs();
                p.Name = pharaohdata[0];
                p.Reign_Start = Convert.ToDateTime(pharaohdata[1]);
                p.Reign_End = Convert.ToDateTime(pharaohdata[2]);
            }
            
        }

        public static string GetInput(string HeadLine, string text, Func<string,bool> requeriment)
        {
            string answer = string.Empty;
            bool correct = false;
            while (!correct)
            {
                System.Console.Clear();
                System.Console.WriteLine(HeadLine);
                System.Console.WriteLine();
                System.Console.Write(text);
                answer = System.Console.ReadLine();
                if (requeriment(answer)) 
                    correct = true;
            }
            

            return answer;
        }
        public static List<Action> ExportAction()
        {
            List<Action> list = new List<Action>();
            list.Add(PharaohAddMenu);
            list.Add(PharaohRemoveMenu);
            list.Add(GetPharaohs);
            return list;
        }
        public static List<string> Titles() // show the options
        {

        }
        //public static void PharaohUpdateOptionsMenu()
        //{
        //    int choice = -1;
        //    int pharaohId = -1;
        //    string answer = string.Empty;
        //    Pharaohs updatebalepharaoh = null;
        //    while (choice < 0 || choice > 2) 
        //    {
        //        System.Console.Clear();
        //        System.Console.WriteLine(); // some string
        //        System.Console.WriteLine("[0] | id");
        //        System.Console.WriteLine("[1]|ChooseFrom pharaohs");
        //        System.Console.WriteLine("[2]|Exit");
        //        System.Console.WriteLine();
        //        System.Console.Write("choice: ");
        //        answer = System.Console.ReadLine();
        //        if (InputCheckForMenus.IntChecker(answer))
        //            choice = int.Parse(answer);
        //    }
        //    switch (choice)
        //    {
        //        case 0:
        //            pharaohId = Convert.ToInt32(GetInput("Please Enter", "Pharao Id: ", InputCheckForMenus.IntChecker));
        //            break;
        //        case 1:
        //            GetPharaohs();
        //            pharaohId = Convert.ToInt32(GetInput("Please Enter", "Pharao Id: ", InputCheckForMenus.IntChecker));
        //            break;

        //    }
        //    if (pharaohId > -1)
        //    {
        //        updatebalepharaoh = GetPharaohById(pharaohId);
        //    }
        //    else
        //    {
        //        System.Console.Clear();
        //        System.Console.WriteLine("Pharaoh does not exits");
        //        Task.Delay(1000).Wait();
        //    }
        //    if (updatebalepharaoh != null)
        //    {
        //        PharaohUpdateMenu(updatebalepharaoh);
        //    }


        //}
        public static void PharaohUpdateOptionsMenu2()
        {
            string pharaohId = string.Empty;
            Pharaohs oldpharaoh = null;
            pharaohId = GetInput("Please Enter", "Pharao Id: ", InputCheckForMenus.IntChecker);
            if (pharaohId != "exit")
            {
                oldpharaoh = GetPharaohById(Convert.ToInt32(pharaohId));
            }
            if (oldpharaoh != null)
            {
                PharaohUpdateMenu(oldpharaoh);
            }
            
            


        }
        public static void  PharaohUpdateMenu(Pharaohs oldpharaoh) // 1. what should  and its correct or not
        {
            int choiceToUpdate = -1;
            string input = string.Empty;
            bool success = false;
            while ((choiceToUpdate < 0 || choiceToUpdate > 3) && input != "exit")
            {
                System.Console.Clear();
                System.Console.WriteLine("Please choose which you want to update");
                System.Console.WriteLine($"[0] Pharaoh Name");
                System.Console.WriteLine($"[1] Pharaoh reign start date");
                System.Console.WriteLine($"[2] Pharaoh reign end date");
                System.Console.WriteLine($"[3] Exit");
                System.Console.WriteLine();
                System.Console.Write("Choice: ");
                input = GetInput("Please Enter", "choice: ", InputCheckForMenus.IntChecker); // need to check for int
                if (input != "exit")
                    choiceToUpdate = Convert.ToInt32(input);
            }
            if (choiceToUpdate < 3 && choiceToUpdate > -1)
                success = InsertPharaohNewDataForUpdate(choiceToUpdate, oldpharaoh);

            if (success) 
            System.Console.WriteLine("Pharaoh successfully updated");


        }

        public static bool InsertPharaohNewDataForUpdate(int choiceToUpdate, Pharaohs oldpharaoh)
        {
            string answer = string.Empty;
            Pharaohs newpharaoh = oldpharaoh;
            switch (choiceToUpdate)
            {
                case 0:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the pharaoh new name", "Pharaoh new name: ", InputCheckForMenus.StringEmptyCheck);
                        newpharaoh.Name = answer;
                    }
                    break;
                case 1:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the pharaoh new reign start date (correct format: YYYY.MM.DD)", "Pharaoh new reign start date: ", InputCheckForMenus.DateTimeCheck);
                        newpharaoh.Reign_Start = Convert.ToDateTime(answer);
                    }
                    break;
                case 2:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the pharaoh new reign end date (correct format: YYYY.MM.DD)", "Pharaoh new reign end date: ", InputCheckForMenus.DateTimeCheck);
                        
                        if (oldpharaoh.Reign_Start > Convert.ToDateTime(answer))
                        {
                            answer = string.Empty;
                        }
                        else
                        {
                            newpharaoh.Reign_End = Convert.ToDateTime(answer);
                        }
                    }
                    break;
            }
            try
            {

                return true;
            }
            catch (ArgumentException)
            {

                System.Console.WriteLine("The reign end date is erlier then the start date. Please try again");
                Task.Delay(3000).Wait();
                return false;
            }
            
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
        public static Pharaohs GetPharaohById(int id)
        {
            PharaohService p = new PharaohService();
            Pharaohs pharaoh = p.GetPharaohsByFilter(x => x.Id == id).FirstOrDefault();
            return pharaoh;
        }
        public static void GetPharaohs()
        {
            Pharaohs[] pharaohs = new Pharaohs[0];
            System.Console.WriteLine($"asd  Pharao Id  Pharao Name Pharao Reign Start Date Pharao Reign End Date");
            for (int i = 0; i < pharaohs.Length; i++)
            {
                System.Console.WriteLine($"[{i}] | {pharaohs[i].Id} {pharaohs[i].Name} {pharaohs[i].Reign_Start} {pharaohs[i].Reign_End}");
            }
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
