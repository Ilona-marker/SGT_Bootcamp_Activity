using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.CardGame;

namespace Activity7.Test
{
    [TestClass]
    public class SimpleDeckTest
    {
        //Declare an object of SimpleDeck
        private SimpleDeck simpleDeck;

        /// <summary>
        /// Method to initialize the variables.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            simpleDeck = new SimpleDeck();
        }

        [TestMethod]
        public void TestMethod1()
        {
            ICard secondCard = simpleDeck.GetCard();

            ICard[] tempCard = new ICard[simpleDeck.CardCount];

            //Declare a variable to hold the deal count.
            int dealCount = 0;

            for (int cardCounter = 0; cardCounter < tempCard.Length; cardCounter++)
            {
                //Fetch a random card from the deck.
                tempCard[cardCounter] = simpleDeck.GetCard();

                //If the card was a random card then increment the deal count.
                if (cardCounter < simpleDeck.Cards.Length && tempCard[cardCounter] != simpleDeck.Cards[cardCounter])
                {
                    dealCount++;
                }
            }

            Assert.IsTrue(dealCount > 2);

        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestGetNullCardException()
        {
            simpleDeck.GetCard(null);
        }
    }
}
