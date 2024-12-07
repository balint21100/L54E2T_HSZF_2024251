using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;

namespace L54E2T_HSZF_2024251.Test
{
    public class TestData
    {
        public static Pharaohs p = new Pharaohs
        {
            Id = 1,
            Name = "Ramses",
            Reign_Start = Convert.ToDateTime("2002-02-12"),
            Reign_End = Convert.ToDateTime("2002-08-12"),
            
            
        };
        public static Pharaohs wrongp = new Pharaohs
        {
            Id = 1,
            Name = "Ramses23",
            Reign_Start = Convert.ToDateTime("2002-08-12"),
            Reign_End = Convert.ToDateTime("2002-02-12"),


        };
    }
}
