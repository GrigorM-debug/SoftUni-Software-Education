using _02.Facade;

var car = new CarBuilderFacade()
    .Info
        .WithType("BMW")
        .WithColor("Black")
        .WithNumberOfDoors(5)
    .Built
        .InCity("Leipzin ");
        .AtAddress("Some address 254")
    .Build();


Console.WriteLine(car);