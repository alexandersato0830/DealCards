using System;

namespace DealCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Card[] cards;
            string command;
            int numDrawn;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter a number to draw cards, S to shuffle, or x to exit:");
                command = Console.ReadLine();
                if (command.ToLower() == "s")
                {
                    deck.Shuffle();
                }
                else if (command.ToLower() == "x")
                {
                    exit = true;
                }
                else if (Int32.TryParse(command, out numDrawn))
                {
                    cards = deck.Draw(numDrawn);

                    for (int x = 0; x < cards.Length; x++)
                        Console.WriteLine(cards[x].ToString());
                }
            }
        }
    }
}

public class Card
{
    private string suit;
    private string face;

    public Card(string cardFace, string cardSuit)
    {
        face = cardFace;
        suit = cardSuit;
    }

    public override string ToString()
    {
        return(face + " of " + suit);
    }
}

public class Deck
{
    private Card[] deck;
    private int position;
    private const int deckSize = 52;
    private Random rand;
  
    public Deck()
    {
        deck = new Card[deckSize];
        string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        string[] suits = { "Hearts", "Clubs", "Spades", "Diamonds"};
        position = 0;
        rand = new Random();

        for(int numSuit = 0; numSuit < 4; numSuit++)
        {
            for (int numFace = 0; numFace < 13; numFace++) 
            {
                deck[position] = new Card(faces[numFace], suits[numSuit]);
                position++;
            }
        }

        position = 0;
    }

    public void Shuffle()
    {
        position = 0;
        for(int x = 0; x < deck.Length; x++)
        {
            Card temp = deck[x];
            deck[x] = deck[rand.Next(deckSize)];
            deck[rand.Next(deckSize)] = temp;
        }
    }

    public Card[] Draw(int n)
    {
        Card[] cardsDrawn = new Card[n];

        for(int x = 0; x < n; x++)
        {
            if (position < 52)
            {
                cardsDrawn[x] = deck[position];
                position++;
            }
            else
                cardsDrawn[x] = new Card("Out", "Cards!");
        }

        return (cardsDrawn);
    }
}
