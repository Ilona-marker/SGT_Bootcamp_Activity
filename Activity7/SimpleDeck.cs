namespace CSharp.Activity.CardGame
{
    public class SimpleDeck : CardDeck
    {
        public SimpleCard[] Cards { get; protected set; }

        public SimpleDeck() : base(52) { }

        public override void InitializeDeck()
        {
            Cards = new SimpleCard[52];

            for (int num = 0; num < Cards.Length; num++)
            {
                SimpleCard card = new() { CardAttribute = num };
                Cards[num] = card;
                PutCard(card);
            }
        }
    }
}
