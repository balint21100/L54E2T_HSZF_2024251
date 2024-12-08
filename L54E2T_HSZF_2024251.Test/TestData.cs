using L54E2T_HSZF_2024251.Model;

namespace L54E2T_HSZF_2024251.Test;

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
        Id = 2,
        Name = "Ramses23",
        Reign_Start = Convert.ToDateTime("2002-08-12"),
        Reign_End = Convert.ToDateTime("2002-02-12"),


    };
    public static Projects ProjectWithGoodDate = new Projects
    {
        Id = 1,
        Name = "Nothing",
        Start_date = Convert.ToDateTime("2002-08-12"),
        End_date = Convert.ToDateTime("2002-08-12"),
        PharaoId = 1
    };
    public static Projects ProjectWithBadId = new Projects
    {
        Id = 1,
        Name = "Nothing",
        Start_date = Convert.ToDateTime("2002-08-12"),
        End_date = Convert.ToDateTime("2002-06-12"),
        PharaoId = 1
    };
    public static Projects ProjectWithBadDate = new Projects
    {
        Id = 1,
        Name = "Nothing",
        Start_date = Convert.ToDateTime("2002-08-12"),
        End_date = Convert.ToDateTime("2002-08-12"),
        PharaoId = 6
    };
    public static ICollection<Projects> ProjectsList = [
        new()
        {
            Id = 1,
            Name = "Nothing",
            Start_date = Convert.ToDateTime("2002-08-12"),
            End_date = Convert.ToDateTime("2002-09-12"),
            PharaoId = 1
        },
        new ()
        {
            Id = 2,
            Name = "Nothing2",
            Start_date = Convert.ToDateTime("2002-08-12"),
            End_date = Convert.ToDateTime("2002-10-12"),
            PharaoId = 1
        }

    ];
    public static ICollection<Pharaohs> PharaohList = [
        new(){
            Id = 1,
            Name = "Ramses",
            Reign_Start = Convert.ToDateTime("2002-02-12"),
            Reign_End = Convert.ToDateTime("2002-08-12"),
        },
        new(){
            Id = 2,
            Name = "Ramses2",
            Reign_Start = Convert.ToDateTime("2002-03-12"),
            Reign_End = Convert.ToDateTime("2002-07-12"),
        }
        ];
}