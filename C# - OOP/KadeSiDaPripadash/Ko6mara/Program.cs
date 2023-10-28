using Microsoft.CognitiveServices.Speech;
using System.Media;
using System.Reflection.PortableExecutable;
using System.Speech.Recognition;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Car car = new Car("Astra", "Ko6mara", 1996);
        Racer racer = new Racer("Angel", car, "Краля на нощните гонки");

        Console.WriteLine($"Racer name: {racer.Name}");
        Console.WriteLine($"The legendary car: {racer.Car.Make} {racer.Car.Model} {racer.Car.Year}");

        
        Console.OutputEncoding = Encoding.UTF8;
        ManualResetEvent soundFinishedEvent = new ManualResetEvent(false);

        // Start a thread for reading and printing words from the text file.
        Thread textThread = new Thread(() =>
        {
            using (StreamReader reader = new StreamReader("ko6mara.txt"))
            {
                string[] words = reader.ReadToEnd().Split(' ');
                foreach (var word in words)
                {
                    Thread.Sleep(900);
                    Console.Write($"{word} ");
                    Thread.Sleep(70);
                }
                reader.Close();
                soundFinishedEvent.Set(); // Signal that text reading is finished.
            }
        });

        // Start a thread for playing the sound.
        Thread soundThread = new Thread(() =>
        {
            racer.MakeSound();
        });

        // Start both threads.
        textThread.Start();
        soundThread.Start();

        // Wait for the text reading to finish before continuing.
        soundFinishedEvent.WaitOne();
    }
}


public class Car
{
    private string make;
    private string model;
    private int year;

    public Car(string make, string model, int year)
    {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    public string Make => this.make;

    public string Model => this.model;

    public int Year => this.year;
}

public class Racer
{
    private string name;
    private Car car;
    private string title;

    public Racer(string name, Car car, string title)
    {
        this.name = name;
        this.car = car;
        this.title = title;
    }

    public string Name => this.name;

    public Car Car => this.car;

    public string Title => this.title;

    public void MakeSound()
    {
        SoundPlayer player = new SoundPlayer("ko6mara.wav");

        player.PlaySync();
    }
}
