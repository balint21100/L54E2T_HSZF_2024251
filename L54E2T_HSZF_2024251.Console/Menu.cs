using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public class Menu
    {


        public static void MainMenu()
        {
            int choice = -1;
            string answer = string.Empty;
            while ((choice != 4))
            {
                do
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"[0] Pharaoh");
                    System.Console.WriteLine($"[1] Project");
                    System.Console.WriteLine($"[2] Worker");
                    System.Console.WriteLine($"[3] Reports");
                    System.Console.WriteLine($"[4] Exit");
                    System.Console.WriteLine();
                    System.Console.Write("Choice: ");
                    answer = System.Console.ReadLine();
                    if (InputCheckForMenus.IntChecker(answer))
                    {
                        if (answer == "exit")
                        {
                            choice = 3;
                        }
                        else
                        {
                            choice = Convert.ToInt32(answer);
                        }
                    }
                } while (choice < 0 || choice > 4);
                switch (choice)
                {
                    case 0:
                        SubMenu("Pharaoh");
                        break;
                    case 1:
                        SubMenu("Project");
                        break;
                    case 2:
                        SubMenuWorkers("Worker");
                        break;
                    case 3:
                        ReportMenu();
                        break;
                }
            }


        }
        public static void SubMenu(string Name)
        {
            int choice = -1;
            string answer = string.Empty;
            while (choice < 0 || choice > 4)
            {
                System.Console.Clear();
                System.Console.WriteLine($"{Name} Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine($"[0] | Add new {Name}");
                System.Console.WriteLine($"[1] | Update {Name}");
                System.Console.WriteLine($"[2] | Delete {Name}");
                System.Console.WriteLine($"[3] | Get all the {Name}s");
                System.Console.WriteLine($"[4] | Exit");
                System.Console.WriteLine();
                System.Console.Write("choice: ");
                answer = System.Console.ReadLine();
                if (InputCheckForMenus.IntChecker(answer))
                {
                    if (answer == "exit")
                    {
                        choice = 4;
                    }
                    else
                    {
                        choice = Convert.ToInt32(answer);
                    }
                }
            }
            if (Name == "Pharaoh")
            {
                switch (choice)
                {
                    case 0:
                        PharaohMenu.PharaohAddMenu();
                        break;
                    case 1:
                        PharaohMenu.PharaohUpdate();
                        break;
                    case 2:
                        PharaohMenu.PharaohRemoveMenu();
                        break;
                    case 3:
                        PharaohMenu.GetPharaohs();
                        break;
                }
            }
            else if (Name == "Project")
            {
                switch (choice)
                {
                    case 0:
                        ProjectMenu.ProjectAddMenu();
                        break;
                    case 1:
                        ProjectMenu.ProjectUpdate();
                        break;
                    case 2:
                        ProjectMenu.ProjectRemoveMenu();
                        break;
                    case 3:
                        ProjectMenu.GetProjects();
                        break;
                }
            }
        }
        public static void SubMenuWorkers(string Name)
        {
            int choice = -1;
            string answer = string.Empty;
            while (choice < 0 || choice > 5)
            {
                System.Console.Clear();
                System.Console.WriteLine($"{Name} Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine($"[0] | Add new {Name}");
                System.Console.WriteLine($"[1] | Update {Name}");
                System.Console.WriteLine($"[2] | Delete {Name}");
                System.Console.WriteLine($"[3] | Get all the {Name}s");
                System.Console.WriteLine($"[4] | Set {Name}'s Manager");
                System.Console.WriteLine($"[5] | Exit");
                System.Console.WriteLine();
                System.Console.Write("choice: ");
                answer = System.Console.ReadLine();
                if (InputCheckForMenus.IntChecker(answer))
                {
                    if (answer == "exit")
                    {
                        choice = 5;
                    }
                    else
                    {
                        choice = Convert.ToInt32(answer);
                    }
                }
            }

            switch (choice)
            {
                case 0:
                    WorkerMenu.WorkerAddMenu();
                    break;
                case 1:
                    WorkerMenu.WorkerUpdate();
                    break;
                case 2:
                    WorkerMenu.WorkerRemoveMenu();
                    break;
                case 3:
                    WorkerMenu.GetWorkers();
                    break;
                case 4:
                    WorkerMenu.SetWorkerManager();
                    break;
            }


        }
        public static void ReportMenu()
        {
            int choice = -1;
            string answer = string.Empty;
            while (choice < 0 || choice > 7)
            {
                System.Console.Clear();
                System.Console.WriteLine($"Report Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine($"[0] | Projects data in xml");
                System.Console.WriteLine($"[1] | Workers by age");
                System.Console.WriteLine($"[2] | Pharaohs between time periodes");
                System.Console.WriteLine($"[3] | Workers count by pharaohs");
                System.Console.WriteLine($"[4] | Workers count by types in projects");
                System.Console.WriteLine($"[5] | Pharaohs all projects count");
                System.Console.WriteLine($"[6] | Manager worker relationships");
                System.Console.WriteLine($"[7] | Exit");
                System.Console.WriteLine();
                System.Console.Write("choice: ");
                answer = System.Console.ReadLine();
                if (InputCheckForMenus.IntChecker(answer))
                {
                    if (answer == "exit")
                    {
                        choice = 7;
                    }
                    else
                    {
                        choice = Convert.ToInt32(answer);
                    }
                }
            }

            switch (choice)
            {
                case 0:
                    Console.ReportMenu.PharaohProjects();
                    break;
                case 1:
                    Console.ReportMenu.WorkersByAge();
                    break;
                case 2:
                    Console.ReportMenu.PharaohsByTime();
                    break;
                case 3:
                    Console.ReportMenu.WorkersByPharaohs();
                    break;
                case 4:
                    Console.ReportMenu.WorkerTypesInProjects();
                    break;
                case 5:
                    Console.ReportMenu.PharaohsProjects();
                    break;
                case 6:
                    Console.ReportMenu.WorkerManagerRelationInProjects();
                    break;
            }
        }


    }
}
