string[] input = Console.ReadLine().Split(", ");

List<Card> cards = new List<Card>();

foreach (string item in input)
{
    string[] currCard = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);


    try
    {
        string face = currCard[0];
        char suit = char.Parse(currCard[1]);

        Card card = new Card(face, suit);

        cards.Add(card);
    }
    catch (InvalidCardException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch
    {
        Console.WriteLine("Invalid card!");
    }
}

Console.WriteLine(string.Join(" ", cards));

public class Card
{
    private string face;
    private char suit;

    public Card(string face, char suit)
    {
        Face = face;
        Suit = suit;
    }

    //Properties
    private string Face
    {
        get => face;

        set => face = FaceChecker(value);
    }

    private char Suit
    {
        get => suit;

        set => suit = SuitChecker(value);
    }

    private string FaceChecker(string value)
    {
        if (value == "10")
        {
            return value;
        }

        if (value.Length != 1)
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }

        if (char.IsDigit(Convert.ToChar(value)))
        {
            return value;
        }

        if (!char.IsLetter(Convert.ToChar(value)))
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }

        if (value == "J" || value == "Q" || value == "K" || value == "A")
        {
            return value;
        }
        else
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }
    }

    private char SuitChecker(char value)
    {
        switch (value)
        {
            case 'S':
                return '\u2660';
            case 'H':
                return '\u2665';
            case 'D':
                return '\u2666';
            case 'C':
                return '\u2663';
            default:
                throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}

public class InvalidCardException : Exception
{
    public const string InvalidCardExceptionMessage = "Invalid card!";

    public InvalidCardException(string invalidCardExceptionMessage) : base(invalidCardExceptionMessage) { }
}