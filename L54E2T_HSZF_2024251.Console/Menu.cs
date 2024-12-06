using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console2
{
    public class Menu
    {


        public static void MainMenu()
        {
            int choice = -1;
            do
            {
                Console.WriteLine($"[0] Pharaoh");
                Console.WriteLine($"[1] Project");
                Console.WriteLine($"[2] Worker");
                choice = int.Parse(Console.ReadLine());
            } while (choice < 0 || choice > 3);
            
            MainMenu2();
            
        }
        public static void MainMenu2()
        {
            
            List<string> titles = new List<string>() {"Add","Update","Delete","Search" };
            List<Action> actions = new List<Action>();
            ShowMenu(titles, actions);
        }
        public static void ShowMenu(List<string> options, List<Action> requirements)
        {
            int choice = -1;
            do
            {
                Console.Clear();
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"[{i}] | options[i]");
                }
                string temp = Console.ReadLine();
                int.TryParse(temp, out choice);


            } while (choice <0 || choice > options.Count);
        }



        //static IProjectService projectService;
        

        //public Menu()
        //{
        //}

        //static string[] AddMenuitems = new string[] { "Add project", "add" };
        //static string[] Main = new string[] { "Add", "Remove", "" };

        //public void MainMenu(IDataService dataService)
        //{
        //    int choice = -1;
        //    while (choice != 6)
        //    {
        //        choice = -1;
        //        while (choice < 1 || choice > 6)
        //        {
        //            Console.Clear();
        //            Console.WriteLine($"1 | Add");
        //            Console.WriteLine($"2 | remove");
        //            Console.WriteLine($"3 | modify");
        //            Console.WriteLine($"4 | Search project with type");
        //            Console.WriteLine($"5 | report");
        //            Console.WriteLine($"6 | CFolder");
        //            Console.WriteLine($"7 | Exit");
        //            try
        //            {
        //                choice = int.Parse(Console.ReadLine());
        //            }
        //            catch (FormatException)
        //            {

        //                choice = -1;
        //            }

        //        }
        //        switch (choice)
        //        {
        //            case 1:
        //                AddMenu(dataService);
        //                break;
        //            case 2:
        //                DeleteMenu(dataService);
        //                break;
        //            case 3:
                        
        //                break;
        //            case 4:
        //                SearchWorkerWithType(dataService);
        //                break;
        //            case 5:
        //                Getreport(dataService);
        //                break;
        //            case 6:
        //                FolderCreater(dataService);
        //                break;

        //        }
        //    }

        //}
        //public void Getreport(IDataService dataService)
        //{
        //    dataService.GetReport();
        //}
        //void SearchWorkerWithType(IDataService dataService)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Please enter a worker type");
        //    string type = Console.ReadLine();
        //    string[] data = dataService.SearchForWorkerTypes(type);
        //    Console.Clear();
        //    foreach (string s in data)
        //    {
        //        Console.WriteLine(s);
        //    }
        //    if (data.Length == 0)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("We do not found any project with this worker type");
        //        Thread.Sleep(3000);
        //    }
        //}
        //void AddMenu(IDataService dataService)
        //{
        //    string[] add = new string[] { "Add new project", "Add new worker" };
        //    int choice = -1;
        //    string[]? answers;
        //    string[] project = new string[] { "project name",
        //                                      "project start date (YYYY.MM.DD)",
        //                                      "project end date (YYYY.MM.DD)",
        //                                      "pharao name" };

        //    string[] projectType = new string[] { "string",
        //                                      "date",
        //                                      "date",
        //                                      "string" };

        //    string[] workers = new string[] { "worker name",
        //                                      "worker age (0-59)",
        //                                      "worker type",
        //                                      "project name" };

        //    string[] workersType = new string[] { "string",
        //                                          "age",
        //                                          "string",
        //                                          "string" };
        //    while (choice != add.Length)
        //    {
        //        choice = MenuShow(add, string.Empty, dataService);

        //        if (choice == 0)
        //        {
        //            answers = InputMenu(project, projectType, dataService);
        //            if (answers != null)
        //            {
        //                dataService.AddProPah(answers, "Project");
        //            }
        //        }
        //        else if (choice == 1)
        //        {
        //            answers = InputMenu(workers, workersType, dataService);
        //            if (answers != null)
        //            {
        //                dataService.AddProPah(answers, "Worker");
        //            }
        //        }
        //    }
        //}

        //string[]? InputMenu(string[] questions, string[] types, IDataService dataService)
        //{
        //    string[]? answers = new string[questions.Length];
        //    string error = string.Empty;
        //    int i = 0;
        //    int check = 0;
        //    while (i < questions.Length && !answers.Contains("exit"))
        //    {
        //        Console.Clear();
        //        if (error != string.Empty)
        //        {
        //            Console.WriteLine("Error");
        //            Console.WriteLine();
        //            Console.WriteLine(error);
        //            Console.WriteLine();
        //        }

        //        Console.WriteLine($"Please enter");
        //        Console.WriteLine();
        //        Console.Write($"{questions[i]} : ");
        //        answers[i] = Console.ReadLine();
        //        check = dataService.Check(answers[i], types[i], ref error);
        //        if (check == 1 || types[i] == "notrequired")
        //        {
        //            i++;
        //            error = string.Empty;
        //        }
        //    }
        //    i--;
        //    if (answers[i] != "exit")
        //    {
        //        return answers;
        //    }
        //    else
        //    {
        //        return answers = null;
        //    }



        //}


        //public static int MenuShow(string[] menuitems, string Bonus_text, IDataService dataService)
        //{
        //    int choice = -1;
        //    string notconverted;
        //    string error = string.Empty;
        //    while (choice < 1 || choice > menuitems.Length + 1)
        //    {
        //        Console.Clear();
        //        if (Bonus_text != string.Empty)
        //            Console.WriteLine(Bonus_text);
        //        for (int i = 0; i < menuitems.Length; i++)
        //        {
        //            Console.WriteLine($" {i + 1} | {menuitems[i]}");
        //        }
        //        Console.WriteLine($" {menuitems.Length + 1} | Exit");

        //        notconverted = Console.ReadLine();
        //        if (dataService.Check(notconverted, "int", ref error) == 1)
        //        {
        //            choice = int.Parse(notconverted);
        //        }
        //    }
        //    return choice - 1;
        //}


        //void DeleteMenu(IDataService dataService)
        //{
        //    int choice = -1;
        //    string error = string.Empty;
        //    string[] options = new string[] { "Id", "Name" };


        //    choice = MenuShow(options, string.Empty, dataService);

        //    if (choice == 0)
        //    {
        //        string[] id = InputMenu(new string[] { "Id" }, new string[] { "int" },dataService);
        //        if (id.Length != 0)
        //        {
        //            Workers[] workers = dataService.SearchWorkerBy("Id", id[0]);
        //            if (workers.Length != 0) 
        //            dataService.DeleteWorkers(workers[0]);
        //            else
        //                Console.WriteLine("The worker not found");
        //        }
                
                
        //    }
        //    else if (choice == 1)
        //    {
        //        string[] name = InputMenu(new string[] { "Name" }, new string[] { "string" }, dataService);
        //        if (name.Length != 0)
        //        {
        //            Workers[] workers = dataService.SearchWorkerBy("Name", name[0]);
        //            int i = 0;
        //            string[] suboptions = new string[workers.Length];
        //            foreach (var item in workers)
        //            {
        //                suboptions[i] = ($"{item.Id} | {item.Name} | {item.Age} | {item.Type}");
        //                i++;
        //            }

        //            int subchoice = MenuShow(suboptions, $"Worker Id, Name, Age, Type", dataService);
        //            if (subchoice != workers.Length)
        //            {
        //                dataService.DeleteWorkers(workers[subchoice]);
        //            }
        //        }
                
        //    }



        //}
        //public void FolderCreater(IDataService dataService)
        //{
        //    dataService.CFolder();
        //}

        //void ModifyMenu(IDataService dataService)
        //{
        //    string[] options = new string[] { "Pharao", "Worker" };
        //    int choice = -1;
        //    int subchoice = -1;
        //    string error = "";
        //    string answer = string.Empty;
        //    choice = MenuShow(options, string.Empty, dataService);

        //    if (choice != options.Length)
        //    {


        //        if (choice == 0)
        //        {
        //            string[] pharaolist = dataService.();
        //            subchoice = MenuShow(pharaolist.ToArray(), string.Empty);
        //            string[] changeoptions = new string[] { "Name", "Start_Date", "End_Date" };
        //            string[] changeoptionstypes = new string[] { "string", "date", "date" };
        //            subchoice = MenuShow(changeoptions, string.Empty);
        //            Console.WriteLine("Please enter the new");
        //            Console.Write($"Pharaoh {changeoptions[subchoice]}: ");
        //            answer = Console.ReadLine();
        //            if (Convert.ToBoolean(Application.Checker.Check(answer, changeoptionstypes[subchoice], ref error)))
        //            {
        //                //feltöltés
        //            }
        //            else
        //            {
        //                Console.WriteLine("Something went wrong, please try again");
        //            }


        //        }
        //        else if (choice == 1)
        //        {
        //            string[] projectlist = dataService.GetProjects();
        //            subchoice = MenuShow(projectlist.ToArray(), string.Empty);

        //        }

        //    }
        //}
        void SearchOptions()
        {

        }

        //void Report()
        //{
        //    int choice = -1;
        //    string[] reporstOptions = new string[] { "Current or Future projects", "Workers Sorted By Age", "Pharaoh periods" };
        //    choice = MenuShow(reporstOptions, string.Empty);
        //    switch (choice)
        //    {
        //        case 0:

        //    }
        //}
    }
}
