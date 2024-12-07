using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public static class WorkerMenu
    {

        public static IWorkerService workerService;
        public static IWorkerRelationShipService workerRelationShipService;
        //kinda finished
        public static void WorkerAddMenu()
        {
            string[] workerdata = new string[4];
            ///// new tech
            string pleaseEnter = "Please Enter";
            string Worker = "Worker ";
            string name = "name: ";
            string age = "Age: ";
            string type = "Type: ";
            string projectid = "Project id: ";

            workerdata[0] = GetInput(pleaseEnter, Worker + name, InputCheckForMenus.StringEmptyCheck); // test approved
            if (!workerdata.Contains("exit"))
                workerdata[1] = GetInput(pleaseEnter, Worker + age, InputCheckForMenus.IntChecker);// test approved
            if (!workerdata.Contains("exit"))
                workerdata[2] = GetInput(pleaseEnter, Worker + type, InputCheckForMenus.StringEmptyCheck);// test approved
            if (!workerdata.Contains("exit"))
                workerdata[3] = GetInput(pleaseEnter, Worker + projectid, InputCheckForMenus.IntChecker);// test approved

            if (!workerdata.Contains("exit"))
            {
                Workers w = new Workers();
                w.Name = workerdata[0];
                w.Age = Convert.ToInt32(workerdata[1]);
                w.Type = workerdata[2];
                w.ProjectId = Convert.ToInt32(workerdata[3]);
                try
                {
                    workerService.AddWorker(w);
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
        public static void WorkerUpdate()
        {
            string workerId = string.Empty;
            Workers oldworker = null;
            workerId = GetInput("Please Enter the worker's id, you want to update", "Worker Id: ", InputCheckForMenus.IntChecker);
            if (workerId != "exit")
            {
                oldworker = GetWorkerById(Convert.ToInt32(workerId));
            }
            if (oldworker != null)
            {
                WorkerUpdateMenu(oldworker);
            }
            else
            {
                System.Console.Clear();
                System.Console.WriteLine("Worker not found");
                Task.Delay(3000).Wait();
            }




        }
        public static void WorkerUpdateMenu(Workers oldWorker) // 1. what should  and its correct or not
        {
            int choiceToUpdate = -1;
            string input = string.Empty;
            bool success = false;
            while ((choiceToUpdate < 0 || choiceToUpdate > 4) && input != "exit")
            {
                string Headline = "Please choose which you want to update\n[0] Worker Name\n[1] Worker age\n[2] Worker type\n[3] Worker projectId\n[4] Exit";
                System.Console.Write("Choice: ");
                input = GetInput(Headline, "choice: ", InputCheckForMenus.IntChecker); // need to check for int
                if (input != "exit")
                    choiceToUpdate = Convert.ToInt32(input);
            }
            if (choiceToUpdate < 4 && choiceToUpdate > -1)
                success = InsertWorkerNewDataForUpdate(choiceToUpdate, oldWorker);

            if (success)
                System.Console.WriteLine("Project successfully updated");


        }

        public static bool InsertWorkerNewDataForUpdate(int choiceToUpdate, Workers oldworker)
        {
            string answer = string.Empty;
            Workers newworker = oldworker;
            switch (choiceToUpdate)
            {
                case 0:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the worker new name", "Worker new name: ", InputCheckForMenus.StringEmptyCheck);
                        if (answer != "exit")
                            newworker.Name = answer;
                    }
                    break;
                case 1:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the worker new age", "Worker new age: ", InputCheckForMenus.IntChecker);
                        if (answer != "exit")
                            newworker.Age = Convert.ToInt32(answer);
                    }
                    break;
                case 2:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the worker new type", "Worker new type: ", InputCheckForMenus.StringEmptyCheck);
                        if (answer != "exit")
                            newworker.Type = answer;

                    }
                    break;
                case 3:
                    while (answer == string.Empty)
                    {
                        answer = GetInput("Please Enter the worker's worker id ", "Worker's new projectid: ", InputCheckForMenus.IntChecker);
                        if (answer != "exit")
                            newworker.ProjectId = Convert.ToInt32(answer);

                    }
                    break;
            }
            if (answer != "exit")
            {
                try
                {
                    workerService.UpdateWorker(newworker.Id, newworker);
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
        public static void WorkerRemoveMenu()
        {
            string answer = string.Empty;
            answer = GetInput($"Please Enter the worker id you wanna delete", "Worker id: ", InputCheckForMenus.IntChecker);
            if (answer != "exit" && answer != string.Empty)
            {
                int id = Convert.ToInt32(answer);
                Workers wanttodelete = GetWorkerById(id);
                try
                {
                    workerService.DeleteWorker(wanttodelete);
                }
                catch (ArgumentException e)
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"{e.Message}");
                    Task.Delay(3000).Wait();
                }

            }
        }
        public static void SetWorkerManager()
        {
            string answer = string.Empty;
            answer = GetInput($"Please Enter a worker id you wanna set a manager", "Worker id: ", InputCheckForMenus.IntChecker);
            if (answer != "exit" && answer != string.Empty)
            {
                int workerid = Convert.ToInt32(answer);

                Workers worker = GetWorkerById(workerid);
                if (worker != null)
                {
                    answer = GetInput($"Please Enter a manager id you wanna set a worker", "Manager id: ", InputCheckForMenus.IntChecker);
                    if (answer != "exit" && answer != string.Empty)
                    {
                        int managerid = Convert.ToInt32(answer);
                        Workers manager = GetWorkerById(managerid);
                        if (manager != null)
                        {
                            WorkerRelationShip workerRelationShip = new WorkerRelationShip()
                            {
                                WorkerId = workerid,
                                ManagerId = managerid
                            };
                            workerRelationShipService.AddWorkerRelationShip(workerRelationShip);
                        }
                    }


                }
            }
        }
        public static Workers GetWorkerById(int id)
        {
            Workers worker = workerService.GetWorkersByFilter(x => x.Id == id).FirstOrDefault();
            return worker;
        }
        public static void GetWorkers()
        {
            ICollection<Workers> workers = workerService.GetWorker();
            System.Console.Clear();
            System.Console.WriteLine($"Worker Id | Worker Name | Age | Type | Worker's project id");
            System.Console.WriteLine(string.Join("\n", workers));
            //foreach (var item in projects)
            //{
            //    System.Console.WriteLine($"{item}");
            //}
            System.Console.WriteLine("\nPress any key");
            System.Console.ReadKey();

        }

    }
}
