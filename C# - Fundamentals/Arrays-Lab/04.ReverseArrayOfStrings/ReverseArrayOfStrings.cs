string[] arrayOfStrings = Console.ReadLine().Split().ToArray();

string[] reversed = arrayOfStrings.Reverse().ToArray(); 

for ( int i = 0; i < reversed.Length; i++)
{
    Console.Write(reversed[i] + " ");
}

