string input = Console.ReadLine();


List<Persons> persons = new List<Persons>();    

while(input != "End")
{
    string[] personInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    string personName = personInfo[0];  
    int personID = int.Parse(personInfo[1]);
    int personAge  = int.Parse(personInfo[2]);

    Persons person = new Persons(personName, personID, personAge);

    persons.Add(person);

    input = Console.ReadLine();
}


foreach(var person in persons.OrderBy(x => x.Age))
{
   Console.WriteLine(person);
}

class Persons
{
    public Persons(string personName, int personID, int personAge)
    {
        Name = personName;  
        ID = personID;
        Age = personAge;
    }
    

    public string Name { get; set; }    

    public int ID { get; set; }

    public int Age { get; set; }


    public override string ToString()
    {
        return $"{Name} with ID: {ID} is {Age} years old.";
    }
}