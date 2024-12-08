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


    public static Workers WorkerWithGoodData = new Workers
    {
        Id = 1,
        Name = "Lajos",
        Age = 38,
        Type = "Basic",
        ProjectId = 1
    };
    public static Workers WorkerWithBadAge = new Workers
    {
        Id = 2,
        Name = "Istvan",
        Age = 60,
        Type = "Basic",
        ProjectId = 1,
    };
    public static Workers WorkerWithBadId = new Workers
    {
        Id = 2,
        Name = "Karoly",
        Age = 30,
        Type = "Basic",
        ProjectId = 6,
    };
    public static ICollection<Workers> WorkersList = [
        new()
        {
            Id = 1,
            Name = "Lajos",
            Age = 38,
            Type = "Basic",
            ProjectId = 1,
            subWorkers =
            [
                new()
                {
                    Id = 3,
                    Name = "Istvan",
                    Age = 12,
                    Type = "Basic",
                    ProjectId = 1,
                    subWorkers =
                        [
                        new()
                            {
                                Id = 4,
                                Name = "Geza",
                                Age = 13,
                                Type = "Basic",
                                ProjectId = 1,
                            }
                        ]
                },
                
            ]
        },
        new ()
        {
            Id = 2,
            Name = "Janos",
            Age = 18,
            Type = "Basic",
            ProjectId = 1,
            subWorkers =
            [
                new()
                {
                    Id = 3,
                    Name = "Peti",
                    Age = 12,
                    Type = "Basic",
                    ProjectId = 1,
                }

            ]
        },
        new ()
        {
            Id = 5,
            Name = "Jozsi",
            Age = 18,
            Type = "Basic",
            ProjectId = 1,
        }

    ];

    public static WorkerRelationShip relationShipGoodWithoutManager = new WorkerRelationShip()
    {
        Id = 1,
        ManagerId = 1,
        WorkerId = 2
    };
    public static WorkerRelationShip relationShipWitManager = new WorkerRelationShip()
    {
        Id = 2,
        ManagerId = 5,
        WorkerId = 3
    };
    public static WorkerRelationShip relationShipSameId = new WorkerRelationShip()
    {
        Id = 3,
        ManagerId = 1,
        WorkerId = 1
    };
    public static ICollection<WorkerRelationShip> workerRelationShipsList =
        [
            new()
            {
                Id = 1,
                ManagerId = 1,
                WorkerId = 2

            },
            new()
            {
                Id = 2,
                ManagerId = 5,
                WorkerId = 3

            }

        ];
}