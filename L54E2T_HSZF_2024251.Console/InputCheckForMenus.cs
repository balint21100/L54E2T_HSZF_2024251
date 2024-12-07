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
            if (string.IsNullOrEmpty(input)) return false;
            return true;
        }
        public static bool DateTimeCheck(string input)
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
    }
}
