using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public static class ProjectMenu
    {

        public static IProjectService projectService;
        //kinda finished
        public static void ProjectAddMenu()
        {
            string[] projectdata = new string[4];
            ///// new tech
            string pleaseEnter = "Please Enter";
            string Project = "Project ";
            string name = "name: ";
            string reignStart = "Project start date (correct format: YYYY.MM.DD): ";
            string reignEnd = "Project end date (correct format: YYYY.MM.DD): ";
            string pharaoId = "Pharaoh id: ";

            projectdata[0] = GetInput(pleaseEnter, Project + name, InputCheckForMenus.StringEmptyCheck); // test approved
            if (!projectdata.Contains("exit"))
                projectdata[1] = GetInput(pleaseEnter, Project + reignStart, InputCheckForMenus.DateTimeCheck);// test approved
            if (!projectdata.Contains("exit"))
                projectdata[2] = GetInput(pleaseEnter, Project + reignEnd, InputCheckForMenus.DateTimeCheck);// test approved
            if (!projectdata.Contains("exit"))
                projectdata[3] = GetInput(pleaseEnter, Project + pharaoId, InputCheckForMenus.IntChecker);// test approved

            if (!projectdata.Contains("exit"))
            {
                Projects p = new Projects();
                p.Name = projectdata[0];
                p.Start_date = Convert.ToDateTime(projectdata[1]);
                p.End_date = Convert.ToDateTime(projectdata[2]);
                p.PharaoId = Convert.ToInt32(projectdata[3]);
                try
                {
                    projectService.AddProjects(p);
                }
                catch (ArgumentException e)
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"{e.Message} Please try again");
                    Task.Delay(3000).Wait();
                }

            }

        }

        public static string GetInput(string HeadLine, string text, Func<string, bool> requeriment)
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
        
        //public static List<string> Titles() // show the options
        //{

        //}
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
        public static void ProjectUpdate()
        {
            string projectId = string.Empty;
            Projects oldproject = null;
            projectId = GetInput("Please Enter the project's id, you want to update", "Project Id: ", InputCheckForMenus.IntChecker);
            if (projectId != "exit")
            {
                oldproject = GetProjectById(Convert.ToInt32(projectId));
            }
            if (oldproject != null)
            {
                ProjectUpdateMenu(oldproject);
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("Project not found");
                Task.Delay(3000).Wait();
            }




        }
        public static void ProjectUpdateMenu(Projects oldproject) // 1. what should  and its correct or not
        {
            int choiceToUpdate = -1;
            string input = string.Empty;
            bool success = false;
            while ((choiceToUpdate < 0 || choiceToUpdate > 4) && input != "exit")
            {
                string Headline = "Please choose which you want to update\n[0] Project Name\n[1] Project start date\n[2] Project end date\n[3] Project PharaohId\n[4] Exit";
                System.Console.Write("Choice: ");
                input = GetInput(Headline, "choice: ", InputCheckForMenus.IntChecker); // need to check for int
                if (input != "exit")
                    choiceToUpdate = Convert.ToInt32(input);
            }
            if (choiceToUpdate < 4 && choiceToUpdate > -1)
                success = InsertProjectNewDataForUpdate(choiceToUpdate, oldproject);

            if (success)
                System.Console.WriteLine("Project successfully updated");


        }

        public static bool InsertProjectNewDataForUpdate(int choiceToUpdate, Projects oldproject)
        {
            string answer = string.Empty;
            Projects newproject = oldproject;
            switch (choiceToUpdate)
            {
                case 0:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the project new name", "Project new name: ", InputCheckForMenus.StringEmptyCheck);
                        if (answer != "exit")
                            newproject.Name = answer;
                    }
                    break;
                case 1:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the project new start date (correct format: YYYY.MM.DD)", "Project new start date: ", InputCheckForMenus.DateTimeCheck);
                        if (answer != "exit")
                            newproject.Start_date = Convert.ToDateTime(answer);
                    }
                    break;
                case 2:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the project new end date (correct format: YYYY.MM.DD)", "Project new end date: ", InputCheckForMenus.DateTimeCheck);
                        if (answer != "exit")
                            newproject.End_date = Convert.ToDateTime(answer);

                    }
                    break;
                case 3:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the project's project id ", "Project's new pharaohid: ", InputCheckForMenus.IntChecker);
                        if (answer != "exit")
                            newproject.End_date = Convert.ToDateTime(answer);

                    }
                    break;
            }
            if (answer != "exit")
            {
                try
                {
                    projectService.UpdateProjects(newproject.Id, newproject);
                    return true;
                }
                catch (ArgumentException e)
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"{e.Message} Please try again");
                    Task.Delay(3000).Wait();
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        public static void ProjectRemoveMenu()
        {
            string answer = string.Empty;
            answer = GetInput($"Please Enter the project id you wanna delete", "Project id: ", InputCheckForMenus.IntChecker);
            if (answer != "exit" && answer != string.Empty)
            {
                int id = Convert.ToInt32(answer);
                Projects wanttodelete = GetProjectById(id);
                try
                {
                    projectService.DeleteProjects(wanttodelete);
                }
                catch (ArgumentException e)
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"{e.Message}");
                    Task.Delay(3000).Wait();
                }

            }
        }
        public static Projects GetProjectById(int id)
        {
            Projects project = projectService.GetProjectsByFilter(x => x.Id == id).FirstOrDefault();
            return project;
        }
        public static void GetProjects()
        {
            ICollection<Projects> projects = projectService.GetProjects();
            System.Console.Clear();
            System.Console.WriteLine($"Project Id | Project Name | Start Date  | End Date | Project's pharaoh id");
            System.Console.WriteLine(string.Join("\n", projects));
            //foreach (var item in projects)
            //{
            //    System.Console.WriteLine($"{item}");
            //}
            System.Console.WriteLine("\nPress any key");
            System.Console.ReadKey();

        }
    }
}
