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
            do
            {
                System.Console.Clear();
                System.Console.WriteLine($"[0] Pharaoh");
                System.Console.WriteLine($"[1] Project");
                System.Console.WriteLine($"[2] Worker");
                choice = int.Parse(System.Console.ReadLine());
            } while (choice < 0 || choice > 3);
            switch (choice)
            {
                case 0:
                    PharaohMenu.GetPharaohs();
                    PharaohMenu.PharaohAddMenu();
                    PharaohMenu.PharaohRemoveMenu();
                    PharaohMenu.PharaohUpdateOptionsMenu2();
                    PharaohMenu.GetPharaohs();
                    break;
            }


        }
    }
}
