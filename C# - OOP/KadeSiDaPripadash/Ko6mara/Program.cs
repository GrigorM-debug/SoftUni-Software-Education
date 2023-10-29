using Microsoft.CognitiveServices.Speech;
using NAudio.Wave;
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
        string text = "Къде си да припадаш? \r\nЕ на Сточна гара, тука да ям.\r\nИдвай пред гаража, идвай приготвил съм ти Кошмара, идвай!\r\nОтивам към тва... до Хаджи Димитър и после отивам до Бояна там да гледам бегачките.\r\nТъкмо на Бояна ше има състезание довечера, чакам те. \r\nНямам пари за бензин.\r\nЩе ти дам 2.50 да има да си харчиш, айде.\r\n2.50, няма как да стане. Ще идваш ли нагоре да гледаме.\r\nШе дойдем аре ше се чуем горе. \r\nНали щеше да ходиш до тва бе?\r\nС Мката ли ше си или? \r\nНяма бе с голфа.\r\nЕ да та еба и тебе, аре извади я, аз ши ходим с Астрата.\r\nКво да извадиме, брат!\r\nЕ ше ходиме да си караме, кво? \r\nА!\r\nШе ходиме да караме, айде. \r\nЕ кво ши карам кат немам пари.\r\nШе сипеш 20 лева бе да еба нямам пари.\r\nБаща ти ще ти свали едно звено от ланеца. От ланеца ще свали едно да продаде. \r\nИмам некви пари дет не ми се дават за бензин ся.\r\nДобре, добре айде, айде пробит гъз, айде пробит гъз айде.";

        byte[] audioData = File.ReadAllBytes("ko6mara.wav");
        MemoryStream audioStream = new MemoryStream(audioData);

        SoundPlayer player = new SoundPlayer();
        Thread.Sleep(70);
        player.Stream = audioStream;
        Thread.Sleep(70);
        player.Play();

        for (int i = 0; i < text.Length; i++)
        {
            //Thread.Sleep(100);
            Console.Write($"{text[i]}");
            Thread.Sleep(60);
        }
        //Thread.Sleep(100);
        Console.ReadLine();

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
}
