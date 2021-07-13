using CSharp.Activity.Datastore;
using System;
using CSharp.Activity.CardGame;

namespace CSharp.Activity.CardGame
{
    public abstract class CardDeck
    {
        private static readonly Random random = new();

        public const int DEFAULT_SIZE = 32;

        private readonly ArrayStore<ICard> Storage;

        /// <summary>
        /// Default constructor that creates a deck of cards.
        /// A deck can hold some default number of cards.
        /// The constructor will call the method InitializeDeck()
        /// to populate the deck.
        /// </summary>
        public CardDeck() : this(DEFAULT_SIZE) { }

        /// <summary>
        /// Constructor that creates a deck of cards.
        /// A deck can hold provided number of cards.
        /// The constructor must call the method InitializeDeck()
        /// to populate the deck.
        /// </summary>
        /// <param name="number">number of cards to hold</param>
        public CardDeck(int number)
        {
            Storage = new ArrayStore<ICard>(number);
            InitializeDeck();
        }

        /// <summary>
        /// Fill the deck with specific cards depending on the subclass's requirements.
        /// </summary>
        public abstract void InitializeDeck();

        /// <summary>
        /// Current number of cards in the deck.
        /// </summary>
        public int CardCount { get => Storage.Count; }

        /// <summary>
        /// Removes and returns a random card from the deck
        /// or returns null if the deck is empty. 
        /// </summary>
        /// <returns>random card, or null if deck is empty</returns>
        public ICard GetCard()
        {
            if (CardCount <= 0)
            {
                return null;
            }

            int i = random.Next(CardCount);
            ICard card = Storage[i];
            Storage.RemoveAt(i);
            return card;
        }

        /// <summary>
        /// Removes and returns a card from the deck that is equal
        /// to the specified card. Returns null if the deck is empty
        /// or if there is no matching card.
        /// </summary>
        /// <param name="card">card to get</param>
        /// <returns>specified card, or null there is no matching card in deck</returns>
        public ICard GetCard(ICard card)
        {
            try
            {
                Storage.Remove(card);
                return card;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds the specified card into the list and returns true.
        /// If the argument is null, it throws an exception of type ArgumentNullException.
        /// </summary>
        /// <param name="card">card to add to the list</param>
        /// <returns>whether adding the card was successful</returns>
        public bool PutCard(ICard card)
        {
            return Storage.Add(card) != ArrayStore<ICard>.NOT_IN_STRUCTURE;
        }
    }
}