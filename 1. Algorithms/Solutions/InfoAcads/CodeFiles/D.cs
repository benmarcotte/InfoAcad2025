using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Hands
    {
        FLUSH_FIVE,
        FLUSH_HOUSE,
        FIVE_OF_A_KIND,
        ROYAL_FLUSH,
        STRAIGHT_FLUSH,
        FOUR_OF_A_KIND,
        FULL_HOUSE,
        FLUSH,
        STRAIGHT,
        THREE_OF_A_KIND,
        TWO_PAIR,
        PAIR,
        HIGH_CARD
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Suits
    {
        HEARTS,
        DIAMONDS,
        SPADES,
        CLUBS
    }
    public class D(List<(int, Suits)> cards, Hands hand) : Question<D>
    {
        [JsonInclude]
        public List<(int, Suits)> cards = cards;
        [JsonInclude]
        public Hands answer = hand;

        public static List<D> GenerateSolutions(int numberOfSolutions)
        {
            List<D> returnal = [];
               
            var hands = GenerateHands(numberOfSolutions);

            foreach (var h in hands)
            {
                returnal.Add(new D(h, DetermineHand(h)));
            }
            //for (int i = 0; i< numberOfSolutions; i++)
            //{
            //    var cards = new List<(int, Suits)> ();
            //    var rand = new Random();
            //    var suitarr = Enum.GetValues(typeof(Suits));
            //    //var tdeck = new List<(int, Suits)>(deck);

            //    //for (int j = 0; j < 5; j++)
            //    //{
            //    //    //cards.Add((rand.Next(12) + 1, (Suits)suitarr.GetValue(rand.Next(suitarr.Length))));
            //    //    int t = rand.Next(tdeck.Count);
            //    //    cards.Add(tdeck[t]);
            //    //    tdeck.RemoveAt(t);
            //    //}
            //    returnal.Add(new D(cards, DetermineHand(cards)));
            //} 
            return returnal;
        }

        public static List<List<(int, Suits)>> GenerateHands(int numberOfSolutions)
        {
            List<(int, Suits)> deck = new List<(int, Suits)>
            ([
                (1, Suits.HEARTS),
                (2, Suits.HEARTS),
                (3, Suits.HEARTS),
                (4, Suits.HEARTS),
                (5, Suits.HEARTS),
                (6, Suits.HEARTS),
                (7, Suits.HEARTS),
                (8, Suits.HEARTS),
                (9, Suits.HEARTS),
                (10, Suits.HEARTS),
                (11, Suits.HEARTS),
                (11, Suits.HEARTS),
                (13, Suits.HEARTS),
                (1, Suits.SPADES),
                (2, Suits.SPADES),
                (3, Suits.SPADES),
                (4, Suits.SPADES),
                (5, Suits.SPADES),
                (6, Suits.SPADES),
                (7, Suits.SPADES),
                (8, Suits.SPADES),
                (9, Suits.SPADES),
                (10, Suits.SPADES),
                (11, Suits.SPADES),
                (11, Suits.SPADES),
                (13, Suits.SPADES),
                (1, Suits.DIAMONDS),
                (2, Suits.DIAMONDS),
                (3, Suits.DIAMONDS),
                (4, Suits.DIAMONDS),
                (5, Suits.DIAMONDS),
                (6, Suits.DIAMONDS),
                (7, Suits.DIAMONDS),
                (8, Suits.DIAMONDS),
                (9, Suits.DIAMONDS),
                (10, Suits.DIAMONDS),
                (11, Suits.DIAMONDS),
                (11, Suits.DIAMONDS),
                (13, Suits.DIAMONDS),
                (1, Suits.CLUBS),
                (2, Suits.CLUBS),
                (3, Suits.CLUBS),
                (4, Suits.CLUBS),
                (5, Suits.CLUBS),
                (6, Suits.CLUBS),
                (7, Suits.CLUBS),
                (8, Suits.CLUBS),
                (9, Suits.CLUBS),
                (10, Suits.CLUBS),
                (11, Suits.CLUBS),
                (11, Suits.CLUBS),
                (13, Suits.CLUBS),
            ]);
            List<List<(int, Suits)>> returnal = [];
            var rand = new Random();
            var handarr = Enum.GetValues(typeof(Hands));
            var suitarr = Enum.GetValues(typeof(Suits));

            var hands = new List<Hands>([ Hands.FLUSH_FIVE,
                                            Hands.FLUSH_HOUSE,
                                            Hands.FIVE_OF_A_KIND,
                                            Hands.ROYAL_FLUSH,
                                            Hands.STRAIGHT_FLUSH,
                                            Hands.FOUR_OF_A_KIND,
                                            Hands.FULL_HOUSE,
                                            Hands.FLUSH,
                                            Hands.STRAIGHT,
                                            Hands.THREE_OF_A_KIND,
                                            Hands.TWO_PAIR,
                                            Hands.PAIR,
                                            Hands.HIGH_CARD]);
            
            for (int i = 0; i < numberOfSolutions - hands.Count; i++)
            {
                hands.Add((Hands)handarr.GetValue(rand.Next(12)));
            }
            foreach (var hand in hands)
            {
                if(hand == Hands.FLUSH_FIVE)
                {
                    var card = deck[rand.Next(deck.Count)];
                    var h = new List<(int, Suits)>([card, card, card, card, card]);
                    returnal.Add(h);
                }
                else if (hand == Hands.FLUSH_HOUSE)
                {
                    var card = deck[rand.Next(deck.Count)];
                    deck.Remove(card);
                    var h = new List<(int, Suits)>();
                    h.Add(card);
                    h.Add(card);
                    h.Add(card);
                    var s = card.Item2;
                    card = deck[rand.Next(deck.Count)];
                    card.Item2 = s;
                    h.Add(card);
                    h.Add(card);
                    returnal.Add(h);
                }
                else if (hand == Hands.FIVE_OF_A_KIND)
                {
                    var card = deck[rand.Next(deck.Count)];
                    var h = new List<(int, Suits)>
                    {
                        card
                    };
                    for (int i = 0; i < 4; i++)
                    {
                        if(card.Item2 == Suits.HEARTS) { card = (card.Item1,  Suits.DIAMONDS); }
                        else if(card.Item2 == Suits.DIAMONDS) { card = (card.Item1, Suits.CLUBS); }
                        else if(card.Item2 == Suits.CLUBS) { card = (card.Item1, Suits.SPADES); }
                        else if(card.Item2 == Suits.SPADES) { card = (card.Item1, Suits.HEARTS); }
                        h.Add(card);
                    }
                    returnal.Add(h);
                }
                else if (hand == Hands.ROYAL_FLUSH)
                {
                    var suit = (Suits)suitarr.GetValue(rand.Next(suitarr.Length));
                    returnal.Add([(1, suit), (10, suit), (11, suit), (12, suit), (13, suit)]);
                }
                else if (hand == Hands.STRAIGHT_FLUSH)
                {
                    var suit = (Suits)suitarr.GetValue(rand.Next(suitarr.Length));
                    int firstInt = rand.Next(1, 10);
                    returnal.Add([(firstInt, suit), (firstInt+1, suit), (firstInt+2, suit), (firstInt+3, suit), (firstInt+4, suit)]);
                }
                else if (hand == Hands.FOUR_OF_A_KIND)
                {
                    int k = rand.Next(1, 14);
                    var h = new List<(int, Suits)>([(k, Suits.HEARTS), (k, Suits.DIAMONDS), (k, Suits.CLUBS), (k, Suits.SPADES), (14 - k, (Suits)suitarr.GetValue(rand.Next(suitarr.Length)))]);
                    returnal.Add(h);
                }
                else if (hand == Hands.FULL_HOUSE)
                {
                    int k = rand.Next(1, 14);
                    var h = new List<(int, Suits)>([(k, Suits.HEARTS), (k, Suits.DIAMONDS), (k, Suits.CLUBS), (14 - k, Suits.CLUBS), (14 - k, Suits.HEARTS)]);
                    returnal.Add(h);
                }
                else if (hand == Hands.FLUSH)
                {
                    var s = (Suits)suitarr.GetValue(rand.Next(suitarr.Length));

                    returnal.Add([(rand.Next(1, 14), s), (rand.Next(1, 14), s), (rand.Next(1, 14), s), (rand.Next(1, 14), s), (rand.Next(1, 14), s),]);
                }
                else if (hand == Hands.STRAIGHT)
                {
                    var suit = (Suits)suitarr.GetValue(rand.Next(suitarr.Length));
                    int firstInt = rand.Next(1, 11);
                    returnal.Add([(firstInt, suit), (firstInt + 1, suit), (firstInt + 2, suit), (firstInt + 3, suit), (firstInt + 4 > 13 ? 1 : firstInt + 4, suit)]);
                }
                else if (hand == Hands.THREE_OF_A_KIND)
                {
                    int k = rand.Next(1, 14);
                    var h = new List<(int, Suits)>([(k, Suits.HEARTS), (k, Suits.DIAMONDS), (k, Suits.CLUBS), (14 - k, (Suits)suitarr.GetValue(rand.Next(suitarr.Length))), (14 - k, (Suits)suitarr.GetValue(rand.Next(suitarr.Length)))]);
                    returnal.Add(h);
                }
                else if (hand == Hands.TWO_PAIR)
                {
                    int k = rand.Next(1, 14);
                    int v = 14 - k;
                    int p = 6;
                    if (k == 6 || v == 6) p = rand.Next(5);
                    var s1 = (Suits)suitarr.GetValue(rand.Next(suitarr.Length));
                    Suits s2 = Suits.HEARTS;
                    if (s1 == Suits.HEARTS) { s2 = Suits.DIAMONDS; }
                    if (s1 == Suits.DIAMONDS) { s2 = Suits.CLUBS; }
                    if (s1 == Suits.CLUBS) { s2 = Suits.SPADES; }
                    if (s1 == Suits.SPADES) { s2 = Suits.HEARTS; }

                    returnal.Add(new List<(int, Suits)>([(k, s1), (v, s1), (k, s2), (v, s2), (p, (Suits)suitarr.GetValue(rand.Next(suitarr.Length)))]));
                }
                else if (hand == Hands.HIGH_CARD)
                {
                    var tdeck = new List<(int, Suits)>(deck);
                    var h = new List<(int, Suits)>();
                    for (int j = 0; j < 5; j++)
                    {
                        int t = rand.Next(tdeck.Count);
                        h.Add(tdeck[t]);
                        tdeck.RemoveAt(t);
                    }
                    returnal.Add(h);
                }
            }
            return returnal;
        }

        public static Hands DetermineHand(List<(int, Suits)> cards)
        {
            //Flush five
            if(cards.Distinct().ToList().Count == 1)
            {
                return Hands.FLUSH_FIVE;
            }
            //Flush house
            else if(cards.Distinct().ToList().Count == 2)
            {
                int count = 0;
                var cardChecking = cards.First();
                foreach(var card in cards)
                {
                    if (cards.Contains(card) && card.Equals(cardChecking))
                    {
                        count++;
                    }
                }
                if (count == 3 || count == 2)
                {
                    return Hands.FLUSH_HOUSE;
                }
            }
            else
            {
                List<int> numerics = [];
                List<Suits> suits = [];
                foreach(var card in cards)
                {
                    numerics.Add(card.Item1);
                    suits.Add(card.Item2);
                }
                //five of a kind
                var t = numerics.Distinct().ToList();
                if (numerics.Distinct().ToList().Count == 1) return Hands.FIVE_OF_A_KIND;
                
                //royal flush
                var royalnums = new List<int>(numerics);
                royalnums.Sort();
                List<int> royal = [1, 10, 11, 12, 13];
                if (royalnums.SequenceEqual(royal) && suits.Distinct().ToList().Count == 1) return Hands.ROYAL_FLUSH;

                //straight flush
                var straightnums = new List<int>(numerics);
                straightnums.Sort();
                bool isStraight = true;
                int prev = 0;
                foreach (var current in straightnums)
                {
                    if (prev != 0)
                    {
                        if (!(current - prev == 1 || (current == 10 && prev == 1)))
                        {
                            isStraight = false;
                        }
                    }
                    prev = current;
                }
                if (isStraight && suits.Distinct().ToList().Count == 1) return Hands.STRAIGHT_FLUSH;

                //Four of a kind
                if (numerics.Distinct().ToList().Count == 2)
                {
                    int count = 0;
                    var cardChecking = numerics.First();
                    foreach (var card in numerics)
                    {
                        if (numerics.Contains(card) && card == cardChecking)
                        {
                            count++;
                        }
                    }
                    if (count == 1 || count == 4)
                    {
                        return Hands.FOUR_OF_A_KIND;
                    }
                }

                //full house
                if (numerics.Distinct().ToList().Count == 2)
                {
                    int count = 0;
                    var cardChecking = numerics.First();
                    foreach (var card in numerics)
                    {
                        if (numerics.Contains(card) && card == cardChecking)
                        {
                            count++;
                        }
                    }
                    if (count == 2 || count == 3)
                    {
                        return Hands.FULL_HOUSE;
                    }
                }

                //flush
                if (suits.Distinct().ToList().Count == 1) return Hands.FLUSH;

                //straight
                if (isStraight) return Hands.STRAIGHT;

                //three of a kind
                if (numerics.Distinct().ToList().Count == 3)
                {
                    var count = numerics
                        .GroupBy(e => e)
                        .Where(e => e.Count() == 3)
                        .Select(e => e.First());
                    if (count.Any())
                    {
                        return Hands.THREE_OF_A_KIND;
                    }
                    //two pair
                    else return Hands.TWO_PAIR;
                }
                //pair
                if (numerics.Distinct().ToList().Count == 4) return Hands.PAIR;
            }
            // high card
            return Hands.HIGH_CARD;
        }
    }
}
