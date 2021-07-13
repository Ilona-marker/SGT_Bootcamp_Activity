using CSharp.Activity.Datastore;
using CSharp.Activity.Profile;
using System;

namespace CSharp.Activity.CardGame
{
    public class CardPlayer : PlayerProfile
    { 
        readonly ArrayStore<ICard> handOfCards;

        //constructor that creates a player with a specified name, gender, date of birth
        //and the maximum number of cards that the player can have in his/her hand. 
        public CardPlayer(string name, char gender, DateTime birthDate, int numberOfCards)
            : base(name, gender, birthDate)
        {
            handOfCards = new ArrayStore<ICard>(numberOfCards);
        }

        // Adds the specified Card object into the player’s hand.
        // Returns true if the add is successful, and returns false otherwise.
        // Throws a new ArgumentNullException if the argument is null. 

        public bool AddCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            // failure if Add(card) == NOT_IN_STRUCTURE (-1)
            // successs if Add(card) != NOT_IN_STRUCTURE (-1)
            return handOfCards.Add(card) != ArrayStore<ICard>.NOT_IN_STRUCTURE;
        }

        // Removes the specified Card object from the player’s hand
        // that is Equal() to the Card specified in the argument.
        // Returns true if the remove is successful and false otherwise.
        // If the argument is null, throw an ArgumentNullException. 

        public bool RemoveCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            try
            {
                handOfCards.Remove(card);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

         // Returns true if the hand is full, false otherwise.  

         public bool IsFull()
            {
                return handOfCards.IsFull();
            }

        //  Returns the card at the specified index but does not remove it.
        //  No validation on the index is expected from this method.

        public ICard GetCard(int index)
        {
            return handOfCards[index];
        }

        //  Property to return the number of cards on hand.  
        public int CardCount { get => handOfCards.Count;  }
        // public int CardCount
        // {
        //  get
        //  {
        //      return handOfCards.Count;
        //  }
        // }

        // Property to return the maximum number of cards the hand can hold

        public int MaxSize { get => handOfCards.Capacity; }

    }
}

        











    



