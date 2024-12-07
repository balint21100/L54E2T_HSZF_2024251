using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public class InputCheckForMenus
    {
        public static bool StringEmptyCheck(string input)
        {
            if (input.ToLower() != "exit")
            {
                if (string.IsNullOrEmpty(input)) return false;
            }
            return true;
        }
        public static bool DateTimeCheck(string input)
        {
            if (input.ToLower() != "exit")
            {
                try
                {
                    Convert.ToDateTime(input);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }
        public static bool IntChecker(string input)
        {
            if (input.ToLower() != "exit")
            {
                try
                {
                    Convert.ToInt32(input);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
