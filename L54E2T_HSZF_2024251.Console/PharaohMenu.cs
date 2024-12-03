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
            pharaohdata[0] = Console.ReadLine(); // need check
            Console.Write($"{pleaseEnter} Regin start date (correct format: YYYY.MM.DD): ");
            pharaohdata[1] = Console.ReadLine(); // need check
            Console.Write($"{pleaseEnter} Regin end date (correct format: YYYY.MM.DD): ");
            pharaohdata[2] = Console.ReadLine(); // need check // How to make a pharaoh
                                                 // call for the pharaoh add method
        }
    }
}
