using BenchmarkDotNet.Attributes;

namespace BenchmarkPlayground;

[MemoryDiagnoser]
public class CombinationTest
{
    public class SCard
    {
        private static readonly Random random = new Random();
        public static readonly string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static readonly string[] suits = { "\u2660", "\u2665", "\u2666", "\u2663" };

        public string Rank { get; set; }
        public string Suit { get; set; }

        public SCard()
        {
            int rankIndex = random.Next(0, 13); // случайный индекс для значения
            int suitIndex = random.Next(0, 4);  // случайный индекс для масти

            Rank = ranks[rankIndex];
            Suit = suits[suitIndex];
        }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }
    }

    public class DCard
    {
        public string Rank { get; }

        public string Suit { get; }

        public DCard(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank}\t{Suit}";
        }
    }

    [Benchmark]
    public string Combination()
    {
        var cards = new DCard[] { new("A", "♣"), new("K", "♣"), new("Q", "♦"), new("J", "♣"), new("10", "♣") };

        var suitCounter  = 0;
        var rankCounter  = 0;
        var currentSuit  = cards[0].Suit;
        var powerCounter = 0;


        foreach (var card in cards)
        {
            powerCounter += power[card.Rank];
            var currentRank = card.Rank;

            if (card.Suit.Equals(currentSuit))
                suitCounter++;

            foreach (var c in cards)
            {
                if (currentRank.Equals(c.Rank))
                    rankCounter++;
            }
        }

        if (suitCounter == 5 && powerCounter == 15867)
        {
            Console.WriteLine("\nУ вас ройял флеш.");
        }
        else if (suitCounter == 5
                 && (powerCounter == 7931
                     || powerCounter == 3963
                     || powerCounter == 1979
                     || powerCounter == 987
                     || powerCounter == 491
                     || powerCounter == 243
                     || powerCounter == 119
                     || powerCounter == 57
                     || powerCounter == 8217))
        {
            return "\nУ вас стрит флеш.";
        }
        else
            switch (rankCounter)
            {
                case 17:
                    return "\nУ вас каре.";


                case 13:
                    return "\nУ вас фулл-хаус.";


                default:
                {
                    if (suitCounter == 5)
                    {
                        return "\nУ вас флеш.";
                    }

                    if (powerCounter == 15867 || powerCounter == 7931 || powerCounter == 3963 || powerCounter == 1979 || powerCounter == 987 || powerCounter == 491 || powerCounter == 243 ||
                        powerCounter == 119 || powerCounter == 57 || powerCounter == 8217)
                    {
                        return "\nУ вас стрит.";
                    }

                    switch (rankCounter)
                    {
                        case 11:
                            return "\nУ вас тройка.";


                        case 9:
                            return "\nУ вас две пары";


                        case 7:
                            return "\nУ вас пара.";
                    }

                    break;
                }
            }

        return "У вас ничего";
    }

    [Benchmark(Baseline = true)]
    public string EvaluateHand()
    {
        var hand = new List<SCard>
        {
            new() { Rank = "A", Suit  = "\u2660" },
            new() { Rank = "K", Suit  = "\u2660" },
            new() { Rank = "Q", Suit  = "\u2666" },
            new() { Rank = "J", Suit  = "\u2660" },
            new() { Rank = "10", Suit = "\u2660" }
        };

        if (IsRoyalFlush(hand)) return "Роял Флэш";
        if (IsStraightFlush(hand)) return "Стрит Флэш";
        if (IsFourOfAKind(hand)) return "Каре";
        if (IsFullHouse(hand)) return "Фулл Хаус";
        if (IsFlush(hand)) return "Флэш";
        if (IsStraight(hand)) return "Стрит";
        if (IsThreeOfAKind(hand)) return "Тройка";
        if (IsTwoPairs(hand)) return "Две пары";
        if (IsOnePair(hand)) return "Одна пара";

        return "Ничего";
    }

    private bool IsRoyalFlush(List<SCard> hand)
    {
        var royalFlush = new[] { "10", "J", "Q", "K", "A" };
        return hand.All(card => royalFlush.Contains(card.Rank)) && IsFlush(hand);
    }

    private bool IsStraightFlush(List<SCard> hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    private bool IsFourOfAKind(List<SCard> hand)
    {
        var grouped = hand.GroupBy(card => card.Rank);
        return grouped.Any(group => group.Count() == 4);
    }

    private bool IsFullHouse(List<SCard> hand)
    {
        var grouped = hand.GroupBy(card => card.Rank);
        return grouped.Any(group => group.Count() == 3) && grouped.Any(group => group.Count() == 2);
    }

    private bool IsFlush(List<SCard> hand)
    {
        return hand.Select(card => card.Suit).Distinct().Count() == 1;
    }

    private bool IsStraight(List<SCard> hand)
    {
        var ranks = hand.Select(card => card.Rank).Distinct().OrderBy(rank => Array.IndexOf(SCard.ranks, rank)).ToList();
        if (ranks.Count < 5) return false;
        for (int i = 0; i < ranks.Count - 1; i++)
        {
            if (Array.IndexOf(SCard.ranks, ranks[i + 1]) - Array.IndexOf(SCard.ranks, ranks[i]) != 1)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsThreeOfAKind(List<SCard> hand)
    {
        var grouped = hand.GroupBy(card => card.Rank);
        return grouped.Any(group => group.Count() == 3);
    }

    private bool IsTwoPairs(List<SCard> hand)
    {
        var grouped = hand.GroupBy(card => card.Rank);
        return grouped.Count(group => group.Count() == 2) == 2;
    }

    private bool IsOnePair(List<SCard> hand)
    {
        var grouped = hand.GroupBy(card => card.Rank);
        return grouped.Any(group => group.Count() == 2);
    }


    //тут я еще не знал о хешах)
    private static readonly Dictionary<string, int> power = new()
    {
        { "2", 1 },
        { "3", 3 },
        { "4", 7 },
        { "5", 15 },
        { "6", 31 },
        { "7", 63 },
        { "8", 127 },
        { "9", 255 },
        { "10", 511 },
        { "J", 1023 },
        { "Q", 2047 },
        { "K", 4095 },
        { "A", 8191 }
    };
}